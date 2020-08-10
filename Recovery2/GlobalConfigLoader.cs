using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NLog;
using Recovery2.Models;

namespace Recovery2
{
    public static class GlobalConfigLoader
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static GlobalConfig Load()
        {
            Log.Debug("Begin app settings loading");
            var res = new GlobalConfig();
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                res.Title = config.AppSettings.Settings[$"{nameof(res.Title)}"].Value;
                Log.Trace($"{nameof(res.Title)}='{res.Title}'");

                res.Count = uint.Parse(ConfigurationManager.AppSettings[$"{nameof(res.Count)}"]);
                Log.Trace($"{nameof(res.Count)}='{res.Count}'");

                res.DefaultDelay = int.Parse(ConfigurationManager.AppSettings[$"{nameof(res.DefaultDelay)}"]);
                Log.Trace($"{nameof(res.DefaultDelay)}='{res.DefaultDelay}'");

                res.Random = Convert.ToBoolean(ConfigurationManager.AppSettings[$"{nameof(res.Random)}"]);
                Log.Trace($"{nameof(res.Random)}='{res.Random}'");

                res.Blackscreen = Convert.ToBoolean(ConfigurationManager.AppSettings[$"{nameof(res.Blackscreen)}"]);
                Log.Trace($"{nameof(res.Blackscreen)}='{res.Blackscreen}'");

                res.BlackscreenItem = LoadContestItem($"{nameof(res.BlackscreenItem)}.");

                var dictionary = ConfigurationManager.AppSettings.AllKeys
                    .Where(k => k.StartsWith("Items.") && k.EndsWith(".Color"))
                    .ToDictionary(k => k.Replace(".Color", string.Empty),
                        v =>
                        {
                            var tmp = v.Replace(".Color", string.Empty);
                            return ConfigurationManager.AppSettings.AllKeys
                                .Where(x => x.StartsWith(tmp))
                                .ToDictionary(q => q.Replace($"{tmp}.", string.Empty),
                                    y => ConfigurationManager.AppSettings[y]);
                        });

                res.Items = dictionary.Keys.Select(key => LoadContestItem($"{key}.")).ToList();;
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Error settings loading");
            }
            finally
            {
                Log.Debug("End app settings loading");
                Log.Info("Настройки успешно загружены!");
            }

            return res;
        }

        private static ContestItem LoadContestItem(string prefix)
        {
            var res = new ContestItem();
            var raw = ConfigurationManager.AppSettings.AllKeys
                .Where(k => k.StartsWith(prefix))
                .ToDictionary(k => k.Replace(prefix, string.Empty),
                    v => ConfigurationManager.AppSettings[v]);

            res.Delay = uint.Parse(raw[$"{nameof(res.Delay)}"]);
            Log.Trace($"{prefix}{nameof(res.Delay)}='{res.Delay}'");

            var colorStr = raw[$"{nameof(res.Color)}"];
            res.Color = Color.FromArgb(Convert.ToInt32(colorStr, 16));
            Log.Trace($"{prefix}{nameof(res.Color)}='{res.Color}'");

            var tmpKeyStr = raw[$"{nameof(res.Key)}"];
            if (Enum.TryParse<Keys>(tmpKeyStr, out var key))
            {
                res.Key = key;
                Log.Trace($"{prefix}{nameof(res.Key)}='{res.Key}'");
            }
            else
            {
                throw new ArgumentException(nameof(res.Key));
            }

            return res;
        }

        public static void Save(GlobalConfig config)
        {
        }
    }
}