using StripsClientWPFReeksView.Exceptions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using StripsREST.Model;

namespace StripsClientWPFReeksView.Services
{
    public class StripServiceClient
    {
        private HttpClient client;

        public StripServiceClient()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5044/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }   
        public async Task<ReeksOutputDto> GetStripAsync(string path) {
            try {
                ReeksOutputDto strip = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if(response.IsSuccessStatusCode) {
                    strip = await response.Content.ReadAsAsync<ReeksOutputDto>();
                }
                return strip;
            } catch (Exception ex) {

                Console.WriteLine(ex); 
                return null;
            }
        }
    }
}
