using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class Serialization
    {
        public void Serialize(object list, StreamWriter fileStream)
        {
            fileStream.WriteLine(((IList)list).Count);
            Type listType = list.GetType();
            if (listType.IsGenericType)
            {
                Type[] objectType = listType.GenericTypeArguments;
                if (objectType[0] != null)
                {
                    if (objectType[0].IsClass)
                    {
                        foreach (var item in (IList)list)
                            SerializeClass(item, fileStream);
                    }
                }
            }
        }

        private void SerializeClass(object item, StreamWriter fileStream)
        {
            Type itemType = item.GetType();
            PropertyInfo[] prInfo;
            prInfo = itemType.GetProperties();
            fileStream.WriteLine(itemType.Name);
            foreach (var pr in prInfo)
            {
                fileStream.WriteLine(pr.Name);
                DefineType(pr.GetValue(item), fileStream);
            }
            fileStream.WriteLine(itemType.Name);
        }

        private void DefineType(object item, StreamWriter serializationStream)
        {
            Type itemtype = item.GetType();
            if (itemtype.IsPrimitive || item is String)
                SerializePrimitive(item, serializationStream);
            else if (itemtype.IsClass)
                SerializeClass(item, serializationStream);
        }
        private void SerializePrimitive(object item, StreamWriter serializationStream)
        {
            if (item is int)
                serializationStream.WriteLine((int)item);
            else if (item is String)
                serializationStream.WriteLine((String)item);
        }
    }
}
