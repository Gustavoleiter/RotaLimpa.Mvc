﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services
{
    public class Request
    {

        public async Task<int> PostReturnIntAsync<TResult>(string uri, TResult data)
        {
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);
            string serialized = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return int.Parse(serialized);
            else
                throw new Exception(serialized);
                
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    var content = new StringContent(JsonConvert.SerializeObject(data));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(uri, content);

                    string serialized = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        
                        return JsonConvert.DeserializeObject<TResult>(serialized);
                    }
                    else
                    {
                        // Tratar códigos de erro específicos aqui e lançar exceções apropriadas se necessário
                        throw new HttpRequestException($"Erro ao chamar a API: {response.StatusCode} - {serialized}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Trate exceções aqui, registre ou lance para cima conforme necessário
                throw new Exception(ex.Message);
            }
        }


        public async Task<int> PutAsync<TResult>(string uri, TResult data)
        {
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uri, content);
            string serialized = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return int.Parse(serialized);
            else
                return 0;
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized));
            return result;
        }

        public async Task<int> DeleteAsync(string uri)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);
            string serialized = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return int.Parse(serialized);
            else
                return 0;
        }

    }
}
