using System;
using Patterns.Singleton;
using UnityEngine;

namespace Tools.Logger
{
    public class Logger : PersistentSingleton<Logger>
    {
        #region Fields and Properties

        private const char _period = '.';
        private const string _openColor = "]: <color={0}><b>";
        private const string _closeColor = "</b></color>";
        [SerializeField] private bool _areLogsEnabled = true;

        #endregion

        #region Log

        public void Log<T>(object log, string colorName = "black", Type param = null)
        {
            if (_areLogsEnabled)
            {
                var context = GetTypeName(typeof(T));
                log = string.Format("[" + context + _openColor + log + _closeColor + GetTypeName(param), colorName);
            }
        }

        #endregion
        
        #region Util

        private static string GetTypeName(Type type)
        {
            if (type == null)
                return string.Empty;

            var split = type.ToString().Split(_period);
            var last = split.Length - 1;
            return last > 0 ? split[last] : string.Empty;
        }

        #endregion
    }
}