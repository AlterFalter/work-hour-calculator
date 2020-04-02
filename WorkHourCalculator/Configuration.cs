using System;
using System.Collections.Generic;
using System.Xml;

namespace WorkHourCalculator
{
    public static class Configuration
    {
        public static string Filepath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static void AddOrSetField(string name, object value)
        {
            XmlDocument document = new XmlDocument();
            document.Load(Filepath);
            //document.
            using (XmlWriter writer = XmlWriter.Create(Filepath))
            {
                
                //writer.sele
                writer.WriteElementString(name, value.ToString());
            }
        }

        public static string ReadField(string name)
        {
            using (XmlReader reader = XmlReader.Create(Filepath))
            {
                return reader.GetAttribute(name);
            }
        }

        public static IList<string[]> GetAllFields()
        {
            IList<string[]> valuePairs = new List<string[]>();
            using (XmlReader reader = XmlReader.Create(Filepath))
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
