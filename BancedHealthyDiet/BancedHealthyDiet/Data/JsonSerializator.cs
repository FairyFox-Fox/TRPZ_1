
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BancedHealthyDiet.Data
{
    public class JsonSerializator:ISerializator
    {
        const string FILE_END = ".json";

        public System.Collections.Generic.List<T> DeserializeListFromFile<T>(string filename)
        {
            var filePath = filename + FILE_END;
            using (StreamReader strReader = new StreamReader(filePath))
            {
                var stringValue = strReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(stringValue);
            }
        }

        public T DeserializeObjectFromFile<T>(string filename)
        {
            var filePath = filename + FILE_END;
            using (StreamReader strReader = new StreamReader(filePath))
            {
                var stringValue = strReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(stringValue);
            }
        }

        public void SerializeObjectToFile<T>(T obj, string fileName)
        {

            var filePath = fileName + FILE_END;
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                var stringValue = JsonConvert.SerializeObject(obj);
                sw.WriteLine(stringValue);
            }
        }

        public void SerializeObjectToFile<T>(List<T> listOfObjects, string fileName)
        {
            var filePath = fileName + FILE_END;
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                var stringValue = JsonConvert.SerializeObject(listOfObjects);
                sw.WriteLine(stringValue);
            }
        }
    }
}