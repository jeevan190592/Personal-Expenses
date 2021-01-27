using System;
using System.IO;
using System.Windows;
using System.Runtime.Serialization.Json; //needs system.runtime.serilization in references if its not their aadd references.
using System.Xml.Serialization;

namespace PersonalExpenses
{
    internal class MyStorage
    {
        internal static void WriteXml<T>(T data, string file)
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));

                FileStream stream;

                stream = new FileStream(file, FileMode.Create);

                sr.Serialize(stream, data);
                stream.Close(); // MAking sure that file is closed and doesnt cause any issue while deleting

            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
                throw;
            }

        }

        internal static T ReadXML<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    //(T) cast it
                    return (T)serializer.Deserialize(sr);

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
                return default(T);
            }
        }
    }
}