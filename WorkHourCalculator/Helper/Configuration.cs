using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace WorkHourCalculator.Helper
{
    public abstract class Configuration<T> : Singleton<T>
        where T : Singleton<T>, new()
    {
        public string ConfigurationFilepath { get; protected set; }

        protected Configuration()
        {
            this.ConfigurationFilepath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Configuration.whc";
            if (!File.Exists(this.ConfigurationFilepath))
            {
                using (File.CreateText(this.ConfigurationFilepath));
            }
        }

        public void AddOrSetField(string name, object value)
        {
            using (XmlWriter writer = XmlWriter.Create(this.ConfigurationFilepath))
            {
                writer.WriteElementString(name, value.ToString());
            }
        }

        public string ReadField(string name)
        {
            using (XmlReader reader = XmlReader.Create(this.ConfigurationFilepath))
            {
                try
                {
                    return reader.GetAttribute(name);
                }
                catch
                {
                    return "";
                }
            }
        }

        public IList<string[]> GetAllFields()
        {
            IList<string[]> valuePairs = new List<string[]>();
            using (XmlReader reader = XmlReader.Create(this.ConfigurationFilepath))
            {
                while (reader.Read())
                {
                    valuePairs.Add(new string[] { reader.Name, reader.Value });
                }
            }
            return valuePairs;
        }
    }
}
