using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkheartWeb.Common
{
    public static class JsonHelper
    {

        /// <summary>
        /// 将实体序列化为json
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ModelToJson<T>(this T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 将json转化为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToModel<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将Json转化为对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static object JsonToObject(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }



    }
}
