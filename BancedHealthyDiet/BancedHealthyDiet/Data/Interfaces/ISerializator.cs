using System;
using System.Collections.Generic;
using System.Text;

namespace BancedHealthyDiet.Data.Interfaces
{
    public interface ISerializator
    {
        void SerializeObjectToFile<T>(T obj, string fileName);
        void SerializeObjectToFile<T>(List<T> listOfObjects, string fileName);
        T DeserializeObjectFromFile<T>(string filename);
        List<T> DeserializeListFromFile<T>(string filename);

    }
}
