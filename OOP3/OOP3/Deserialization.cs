using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Builds;

namespace OOP3
{
    class Deserialization
    {
        private List<Type> types = new List<Type>(); 
        public object Deserialize(List<Type> listOfTypes,StreamReader fileReader)
        {
            types = listOfTypes;
            List<Build> Result = new List<Build>();
            int Count = int.Parse(fileReader.ReadLine());
            for (int i = 0; i < Count; i++)
            {
                String temp = fileReader.ReadLine();
                Type itemType = listOfTypes.FirstOrDefault(x => x.Name == temp);
                object item = (object)Activator.CreateInstance((Type)(itemType));
                item = DeserializeProperties(fileReader, item);
                Result.Add((Build)item);
            }
            return Result;
        }

        private object DeserializeProperties(StreamReader deserializationStream, object item)
        {
            Type itemType = item.GetType();
            PropertyInfo[] prInfo = itemType.GetProperties();
            int Count = prInfo.Length;
            string temp = deserializationStream.ReadLine();
            while (temp != itemType.Name)
            {
                for (int j = 0; j < Count; j++)
                    if (temp == prInfo[j].Name)
                        item = DefineType(deserializationStream, item, prInfo[j]);
                temp = deserializationStream.ReadLine();
            }
            return item;
        }



        private object DefineType(StreamReader deserializationStream, object item, PropertyInfo prInfo)
        {
            Type itemType = item.GetType();
            Type prType = prInfo.PropertyType;
            string temp;
            if (prType.IsPrimitive || prType == typeof(String))
            {
                object value = prInfo.GetValue(item);
                if (value is int)
                {
                    temp = deserializationStream.ReadLine();
                    prInfo.SetValue(item, int.Parse(temp));
                }
                else if (value is String || value == null)
                {
                    temp = deserializationStream.ReadLine();
                    prInfo.SetValue(item, temp);
                }
            }
            else if (prType.IsEnum)
            {
                temp = deserializationStream.ReadLine();
                Array arr = Enum.GetNames(prType);
                int index = Array.IndexOf(arr, temp);
                prInfo.SetValue(item, index);
            }
            else if (prType.IsClass)
            {
                prInfo.SetValue(item, DeserializeClass(deserializationStream));
            }

            return item;
        }

        private object DeserializeClass(StreamReader deserializationStream)
        {
            String temp = deserializationStream.ReadLine();
            Type itemType = types.FirstOrDefault(
                x => x.Name == temp);
            object item = (object)Activator.CreateInstance((Type)(itemType));
            item = DeserializeProperties(deserializationStream, item);
            return item;
        }
    }
}
