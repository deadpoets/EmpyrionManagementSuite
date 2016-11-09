using EMS.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace EMS.Core.Yaml
{
    /// <summary>
    /// Serializes/Deserializes YAML files into class objects
    /// </summary>
    public static class YamlConverter
    {
        public static T DeserializeFile<T>(string PATH)
        {
            try
            {
                var txt = File.ReadAllText(PATH);

                var deserializer = new Deserializer();
                var obj = deserializer.Deserialize<T>(txt);

                return obj;
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return (T)(new object());
        }
    }
}