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
        private bool _loadBroken = false;

        private readonly GlobalConfig _defaultConfig = new GlobalConfig
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

        private void SetAppSetting(string key, object value)
        {
            try
            {
                _config.AppSettings.Settings[key].Value = value.ToString();
            }
            catch
            {
                _config.AppSettings.Settings.Add(key, value.ToString());
            }
        }

        private void SetProp<T>(out T dest, string key, Func<string, T> convert, T def)
        {
            try
            {
                dest = convert(GetAppSetting(key));
                _log.Trace($"{key}='{dest}'");
            }
            catch
            {
                _log.Warn(
                    $"Ошибка при загрузке значения {key}, использовано значение по умолчанию: '{def}'");
                dest = def;
                _log.Trace($"{key}='{dest}'");
            }
        }

        public void Load()
        {
            _log.Info("Загрузка настроек...");
            if (_config.GetSection("framesSettings") is FramesConfigSection frames)
            {
                if (frames.FrameItems.Count == 0)
                {
                    _log.Warn("Не обнаружены настройки для фреймов, используются стандартные настройки");
                    LoadDefaults();
                    return;
                }

                _globalConfig = new GlobalConfig();


                SetProp(out var title, nameof(_globalConfig.Title), s => s, _defaultConfig.Title);
                _globalConfig.Title = title;

                SetProp(out var count, nameof(_globalConfig.Count), uint.Parse, _defaultConfig.Count);
                _globalConfig.Count = count;

                SetProp(out var defdelay, nameof(_globalConfig.DefaultDelay), int.Parse, _defaultConfig.DefaultDelay);
                _globalConfig.DefaultDelay = defdelay;

                SetProp(out var random, nameof(_globalConfig.Random), Convert.ToBoolean, _defaultConfig.Random);
                _globalConfig.Random = random;

                SetProp(out var blscreen, nameof(_globalConfig.Blackscreen), Convert.ToBoolean,
                    _defaultConfig.Blackscreen);
                _globalConfig.Random = blscreen;

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

                if (_loadBroken)
                {
                    Save();
                }
            }
            else
            {
                _log.Warn("Не обнаружены настройки для фреймов, используются стандартные настройки");
                LoadDefaults();
            }
            _log.Info("Загрузка настроек завершена");
        }

        public void LoadDefaults()
        {
            _log.Info("Установка стандартных настроек...");
            _globalConfig = _defaultConfig.Copy();
            Save();
            _log.Info("Установка стандартных настроек завершена");
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
            _log.Info("Сохранение настроек завершено");
        }
    }
}