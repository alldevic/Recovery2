using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NLog;
using Recovery2.Extensions;
using Recovery2.Models;

namespace Recovery2.Configs
{
    public class ConfigLoader
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly Configuration _config;
        private GlobalConfig _globalConfig;

        private readonly GlobalConfig _defaultConfig = new GlobalConfig()
        {
            Title = @"Как нестандартно можно использовать карандаш?",
            Count = 30,
            Random = true,
            DefaultDelay = 1000,
            Blackscreen = true,
            BlackscreenItem = new ContestItem
            {
                Color = Color.Black,
                Delay = 0,
                Key = 0,
                Name = @"Blackscreen"
            },
            Items = new ObservableCollection<ContestItem>(new[]
            {
                new ContestItem
                {
                    Name = @"Красный",
                    Color = Color.Red,
                    Delay = 0,
                    Key = Keys.Space,
                },
                new ContestItem()
                {
                    Name = @"Желтый",
                    Color = Color.Yellow,
                    Delay = 0,
                    Key = Keys.None,
                },
                new ContestItem()
                {
                    Name = @"Зеленый",
                    Color = Color.Green,
                    Delay = 0,
                    Key = Keys.Enter,
                },
            })
        };

        public ConfigLoader()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public GlobalConfig GlobalConfig => _globalConfig;


        private string GetAppSetting(string key) =>
            _config.AppSettings.Settings[key].Value;

        private void SetAppSetting(string key, object value) =>
            _config.AppSettings.Settings[key].Value = value.ToString();

        public void Load()
        {
            if (_config.GetSection("framesSettings") is FramesConfigSection frames)
            {
                _globalConfig = new GlobalConfig();
                _globalConfig.Title = GetAppSetting(nameof(_globalConfig.Title));
                _log.Trace($"{nameof(_globalConfig.Title)}='{_globalConfig.Title}'");

                _globalConfig.Count = uint.Parse(GetAppSetting(nameof(_globalConfig.Count)));
                _log.Trace($"{nameof(_globalConfig.Count)}='{_globalConfig.Count}'");

                _globalConfig.DefaultDelay = int.Parse(GetAppSetting(nameof(_globalConfig.DefaultDelay)));
                _log.Trace($"{nameof(_globalConfig.DefaultDelay)}='{_globalConfig.DefaultDelay}'");

                _globalConfig.Random = Convert.ToBoolean(GetAppSetting(nameof(_globalConfig.Random)));
                _log.Trace($"{nameof(_globalConfig.Random)}='{_globalConfig.Random}'");

                _globalConfig.Blackscreen = Convert.ToBoolean(GetAppSetting(nameof(_globalConfig.Blackscreen)));
                _log.Trace($"{nameof(_globalConfig.Blackscreen)}='{_globalConfig.Blackscreen}'");

                _globalConfig.Items = new ObservableCollection<ContestItem>();
                foreach (FrameElement frameItem in frames.FrameItems)
                {
                    if (string.Equals(frameItem.Name, "Blackscreen"))
                    {
                        _globalConfig.BlackscreenItem = new ContestItem
                        {
                            Name = frameItem.Name,
                            Color = frameItem.Color,
                            Delay = frameItem.Delay,
                            Key = frameItem.Key
                        };

                        _log.Trace(
                            $"BlackscreenItem.{nameof(frameItem.Color)}='{_globalConfig.BlackscreenItem.Color}'");
                        _log.Trace(
                            $"BlackscreenItem.{nameof(frameItem.Delay)}='{_globalConfig.BlackscreenItem.Delay}'");
                        _log.Trace(
                            $"BlackscreenItem.{nameof(frameItem.Key)}='{_globalConfig.BlackscreenItem.Key}'");

                        continue;
                    }

                    var tmpItem = new ContestItem
                    {
                        Name = frameItem.Name,
                        Color = frameItem.Color,
                        Delay = frameItem.Delay,
                        Key = frameItem.Key
                    };
                    _globalConfig.Items.Add(tmpItem);

                    var last = _globalConfig.Items.Last();
                    _log.Trace($"Items.{last.Name}.{nameof(last.Color)}='{last.Color}'");
                    _log.Trace($"Items.{last.Name}.{nameof(last.Delay)}='{last.Delay}'");
                    _log.Trace($"Items.{last.Name}.{nameof(last.Key)}='{last.Key}'");
                }
            }
        }

        public void LoadDefaults()
        {
            _globalConfig = _defaultConfig.Copy();
            Save();
        }

        public void Save()
        {
            _log.Info("Сохранение настроек...");

            SetAppSetting(nameof(_globalConfig.Title), _globalConfig.Title);
            _log.Trace($"{nameof(_globalConfig.Title)}='{_globalConfig.Title}'");

            SetAppSetting(nameof(_globalConfig.Count), _globalConfig.Count);
            _log.Trace($"{nameof(_globalConfig.Count)}='{_globalConfig.Count}'");

            SetAppSetting(nameof(_globalConfig.DefaultDelay), _globalConfig.DefaultDelay);
            _log.Trace($"{nameof(_globalConfig.DefaultDelay)}='{_globalConfig.DefaultDelay}'");

            SetAppSetting(nameof(_globalConfig.Random), _globalConfig.Random);
            _log.Trace($"{nameof(_globalConfig.Random)}='{_globalConfig.Random}'");

            SetAppSetting(nameof(_globalConfig.Blackscreen), _globalConfig.Blackscreen);
            _log.Trace($"{nameof(_globalConfig.Blackscreen)}='{_globalConfig.Blackscreen}'");

            if (_config.GetSection("framesSettings") is FramesConfigSection frames)
            {
                frames.FrameItems.Clear();
                frames.FrameItems.Add(new FrameElement
                {
                    Name = _globalConfig.BlackscreenItem.Name,
                    Color = _globalConfig.BlackscreenItem.Color,
                    Delay = _globalConfig.BlackscreenItem.Delay,
                    Key = _globalConfig.BlackscreenItem.Key
                });
                foreach (var item in _globalConfig.Items)
                {
                    frames.FrameItems.Add(new FrameElement
                    {
                        Name = item.Name,
                        Color = item.Color,
                        Delay = item.Delay,
                        Key = item.Key
                    });
                }
            }

            _config.Save(ConfigurationSaveMode.Modified);
            _log.Info("Настройки успешно сохранены");
        }
    }
}