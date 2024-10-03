using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using StudentBrain.Common;
using System.Globalization;

namespace StudentBrain.Utilities
{
    public static class MessageExtender
    {
        /// <summary>
        /// Metodo para deserializar objetos, tiene un parametro de tipo T para que pueda deserealizar cualquier tipo de objeto (Message)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xMessage"></param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(this Message xMessage)
        {
            return JsonConvert.DeserializeObject<T>(xMessage.MessageInfo, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
        }
        /// <summary>
        /// Metodo para deserializar objetos, tiene un parametro de tipo T para que pueda deserealizar cualquier tipo de objeto (String)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonParameter"></param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(this String jsonParameter)
        {
            return JsonConvert.DeserializeObject<T>(jsonParameter, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
        }
        /// <summary>
        /// Metodo para serializar objetos, tiene un parametro de tipo T para que pueda serealizar cualquier tipo de objeto (String)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputObject"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T inputObject)
        {
            var returnValue = new Message();
            CultureInfo culture = new CultureInfo("es-ES");
            var culture2 = CultureInfo.CurrentCulture;

            return JsonConvert.SerializeObject(inputObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
        }
        /// <summary>
        /// Metodo para serializar objetos, tiene un parametro de tipo OBJECT para que pueda serealizar cualquier tipo de objeto (String)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object DeSerializeObject(string value)
        {
            return JsonConvert.DeserializeObject(value);
        }
    }
}
