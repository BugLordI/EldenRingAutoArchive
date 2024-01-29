using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tools
{
    public static class Objects
    {
        public static T DeepCopyByBinary<T>(this T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

    }
}
