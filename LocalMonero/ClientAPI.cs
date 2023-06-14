using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ClientAPI
{


    class ClientHTTP
    {

        protected readonly HttpClient Http;
        protected ClientHTTP(string baseAddress)
        {
            Http = new()
            {
                BaseAddress = new Uri(baseAddress)
            };           
        }

        protected HttpClient ReturnHttpClient()
        {
            return Http;
        }

        protected async Task<string> GetResponse(string url)
        {
            string responseString = string.Empty;
            try
            {
                HttpResponseMessage responseMessage = await Http.GetAsync(url);
                responseString = responseMessage.Content.ReadAsStringAsync().Result;
            }

            catch (HttpRequestException ex)
            {
                if (ex.StatusCode != null)
                {
                    Console.WriteLine($"HTTP error: {ex.Message}");
                    throw new Exception(ex.Message, ex);
                }
                else
                {
                    Console.WriteLine($"HTTP error: {ex.Message}");
                    throw new Exception("lol");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception error: {ex.Message}");
            }
            return responseString;

        }



        protected async Task<TReturn> GetResponse<TReturn>(string url) where TReturn : IGetResponse, new()
        {
            TReturn? t = new();
            try
            {

                JsonSerializerOptions options = new()
                {
                    Converters = { new JsonStringEnumConverter() }
                };
                t = await Http.GetFromJsonAsync<TReturn>(url, options);
            }

            catch (HttpRequestException ex)
            {
                    Console.WriteLine($"HTTP error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception error: {ex.Message}");
            }
            return t ?? new TReturn();           
            
        }

        protected async Task<TReturn> PostResponse<TReturn, TRequest>(string url, TRequest request) where TReturn : IGetResponse, new()
        {
            TReturn? t = new();
            try
            {
                JsonSerializerOptions options = new() 
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    Converters = {new JsonStringEnumConverter()}
                };
                
                t = await Http.PostAsJsonAsync<TRequest>(url, request, options).Result.Content.ReadFromJsonAsync<TReturn>();
            }

            catch (HttpRequestException ex)
            {
                
                    Console.WriteLine($"HTTP error: {ex.Message}");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception error: {ex.Message}");
            }
            return t ?? new TReturn();

        }

      

    }
}
