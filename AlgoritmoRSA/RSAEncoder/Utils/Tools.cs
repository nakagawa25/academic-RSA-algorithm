using System.Collections.Generic;
using System.Text;

namespace RSAEncoder.Utils
{
    public static class Tools
    {
        public static byte[] GetByteArray(object input)
        {
            var objToString = System.Text.Json.JsonSerializer.Serialize(input);
            return Encoding.ASCII.GetBytes(objToString);
        }

        public static object GetObjectFromByteArray(byte[] bytes)
        {
            var stringObj = Encoding.ASCII.GetString(bytes);
            return System.Text.Json.JsonSerializer.Deserialize<object>(stringObj);
        }

        public static List<long> GetLongListFromByteArray(byte[] bytes)
        {
            var stringObj = Encoding.ASCII.GetString(bytes);
            return System.Text.Json.JsonSerializer.Deserialize<List<long>>(stringObj);
        }
    }
}
