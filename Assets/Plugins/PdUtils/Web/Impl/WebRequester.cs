using System;
using System.Net.Http;
using Unity.Plastic.Newtonsoft.Json;

namespace PdUtils.Web.Impl
{
    public class WebRequester<T> : IWebRequester<T>
    {
        public async void Get(string url, Action<WebResponse<T>> callback)
        {
            using var client = new HttpClient();
            var resp = await client.GetAsync(url);
            var response = new WebResponse<T>((long)resp.StatusCode);
            try
            {
                var body = await resp.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(body))
                {
                    var result = JsonConvert.DeserializeObject<T>(body);
                    response.Value = result;
                }
                callback?.Invoke(response);
            } 
            catch (HttpRequestException e)
            {
                response.Error = e.Message;
                callback?.Invoke(response);
            }
        }

        public async void Get(string url, Action<WebResponse<string>> callback)
        {
            using var client = new HttpClient();
            var resp = await client.GetAsync(url);
            var response = new WebResponse<string>((long)resp.StatusCode);
            try
            {
                response.Value = await resp.Content.ReadAsStringAsync();
                callback?.Invoke(response);
            } 
            catch (HttpRequestException e)
            {
                response.Error = e.Message;
                callback?.Invoke(response);
            }
        }
    }
}