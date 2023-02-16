using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EduBook.Utility
{
    public static class SessionExtension
    {
        // set session truyền (key, value) -> không trả về
        public static void setObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        // get session truyền (key) ->  trả về object
        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }    
    }
}