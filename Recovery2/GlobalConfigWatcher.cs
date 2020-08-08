using System;
using System.Configuration;
using System.IO;
using System.Threading;
using NLog;
using Recovery2.Models;

namespace Recovery2
{
    public class GlobalConfigWatcher
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private FileSystemWatcher _watcher;
        private GlobalConfig _config;
        private bool _isWatching;

        
        public GlobalConfigWatcher(ref GlobalConfig config)
        {
            _config = config;
        }

        ~GlobalConfigWatcher()
        {
            Stop();
        }

        public void Start()
        {
            if (_isWatching)
            {
                return;
            }

            _isWatching = true;

            _watcher = new FileSystemWatcher
            {
                Filter = "*.exe.config",
                Path = AppDomain.CurrentDomain.BaseDirectory,
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };


            _watcher.Changed += OnChanged;

            _log.Info($"Начато отслеживание изменений в файле конфигурвции");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(350);
            ConfigurationManager.RefreshSection("AppSettings");
            _config = GlobalConfigLoader.Load();
        }

        public void Stop()
        {
            if (!_isWatching)
            {
                return;
            }
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
            _isWatching = false;
            _log.Info($"Изменения в файле настроек больше не отслеживаются");
        }
    }
}