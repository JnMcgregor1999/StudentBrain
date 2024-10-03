using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StudentBrain.Utilities
{
    public class SendRequest //para enviar peticiones a la aplicacion de seguridad 7SS0
    {
        /// <summary>
        ///  Metodo para invocar API de terceros mediante el verbo http POST recibe los parametros  (url, metodo, parametros <T>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="entityParameter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string InvokePost<T>(string url, string method, T entityParameter)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync(method, entityParameter).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                return jsonResult;
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        /// <summary>
        /// Metodo para invocar API de terceros mediante el verbo http POST recibe los parametros  (url, metodo, parametros OBJECT)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="entityParameter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string InvokePost<T>(string url, string method, object entityParameter)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync(method, entityParameter).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = response.Content.ReadAsStringAsync().Result;
                return jsonResult;
            }
            else
                throw new Exception(response.ReasonPhrase);
        }
        /// <summary>
        /// Metodo para invocar API de terceros mediante el verbo http POST recibe los parametros  (url, metodo, parametros string)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="entityParameter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string InvokePost(string url, string method, string entityParameter)
        {

            var client = new RestClient(url);
            var request = new RestRequest("Post");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", entityParameter, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var jsonResult = response.Content;
                return jsonResult;
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

    }
}
