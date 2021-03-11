using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ExpressData
{
    public static class DataRacks
    {
        public static string Export<T>(T obj, List<Meta> meta = null)
        {
            var appName = AppDomain.CurrentDomain.FriendlyName;
            string appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            string libVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var data = new DataRack<T>
            {
                ApplicationName = appName,
                ApplicationVersion = appVersion,
                Created = DateTime.UtcNow,
                RackId = Guid.NewGuid(),
                ExpressVersion = libVersion,
                Meta = meta,
                Data = obj
            };
            var result = JsonConvert.SerializeObject(data);
            return result.ToString();
        }

        public static DataRack<T> Import<T>(string xml)
        {
            var result = JsonConvert.DeserializeObject<DataRack<T>>(xml);
            return result;
        }

        public static void DataRackXMLToFile<T>(string xml, string directory)
        {
            var dataRack = Import<T>(xml);
            File.WriteAllText($"{directory}/BAK{dataRack.Created.ToString("yyyyddMM")}.xml", xml);
        }
    }
}

public class DataRack<T>
{
    public Guid RackId { get; set; }
    public DateTime Created { get; set; }
    public string ApplicationName { get; set; }
    public string ApplicationVersion { get; set; }
    public string ExpressVersion { get; set; }
    public List<Meta> Meta { get; set; }
    public T Data { get; set; }
}

public class Meta
{
    public Meta(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; set; }
    public string Value { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public Guid Session { get; set; }
    public string Name { get; set; }
    public DateTime DOB { get; set; }
    public Student Students { get; set; }
}