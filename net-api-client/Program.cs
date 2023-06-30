using Newtonsoft.Json;

namespace net_api_client
{
    internal class Program
    {
        static string url = "http://localhost:5000";

        static async Task Main(string[] args)
        {
            Console.Write("net");
            Console.Write("press enter key to start");
            Console.ReadLine();

            try
            {
                Console.WriteLine(await TestA("test method"));
                Console.WriteLine(await TestB("test method"));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
            }

            Console.Write("press enter key to finish");
            Console.ReadLine();
        }

        static async Task<string> TestA(string inputMessage)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/Test/TestA")
            {
                Content = new MultipartFormDataContent
                {
                    { new StringContent(inputMessage), "InputMessage" }
                }
            };

            var response = await new HttpClient().SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText)!;

            return responseObject["outputMessage"];
        }

        static async Task<string> TestB(string inputMessage)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/Test/B")
            {
                Content = new MultipartFormDataContent
                {
                    { new StringContent(inputMessage), "InputMessage" }
                }
            };

            var response = await new HttpClient().SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText)!;

            return responseObject["outputMessage"];
        }
    }
}