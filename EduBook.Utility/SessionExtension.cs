using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EduBook.Utility
{
    // tạo class SessionExtension
    public static class SessionExtension
    {
        // phương thức set session truyền (key, value) -> không trả về
        public static void setObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        // phương thức get session truyền (key) ->  trả về object
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }    
    }
}