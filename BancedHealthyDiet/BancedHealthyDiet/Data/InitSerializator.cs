using Jukebox.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jukebox.Models
{
    public class InitSerializator
    {
        private readonly ISerializator serializator;

    
        public InitSerializator(TypeOfSerialization typeOfSerialization)
        {
            switch (typeOfSerialization)
            {
                case TypeOfSerialization.Binary:
                    serializator = new BinarySerializator();
                    break;

                case TypeOfSerialization.Json:
                    serializator = new JsonSerializator();
                    break;

                case TypeOfSerialization.Xml:
                    serializator = new XmlSerializator();
                    break;
            }


        }

        

        public List<T> DeserializeList<T>(string value)
        {
            return serializator.DeserializeList<T>(value);
        }

        public List<T> DeserializeListFromFile<T>(string filename)
        {
            return serializator.DeserializeListFromFile<T>(filename);
        }

        public T DeserializeObject<T>(string value)
        {
            return serializator.DeserializeObject<T>(value);
        }

        public T DeserializeObjectFromFile<T>(string filename)
        {
            return serializator.DeserializeObjectFromFile<T>(filename);
        }


        public string SerializeObject<T>(T obj)
        {
            return serializator.SerializeObject(obj);
        }

        public string SerializeObject<T>(List<T> listOfobj)
        {
            return serializator.SerializeObject(listOfobj);
        }

        public void SerializeObjectToFile<T>(T obj, string fileName)
        {
            serializator.SerializeObjectToFile(obj, fileName);
        }

        public void SerializeObjectToFile<T>(List<T> listOfObjects, string fileName)
        {
            serializator.SerializeObjectToFile(listOfObjects, fileName);
        }
    }
}
