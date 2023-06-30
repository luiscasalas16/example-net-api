using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace netfw_api_client
{
    internal class Program
    {
        static string url = "http://localhost:5002";

        static async Task Main(string[] args)
        {
            Console.WriteLine("netfw");
            Console.Write("press enter key to start");
            Console.ReadLine();

            try
            {
                Console.WriteLine(await Test("A", "TestA"));
                Console.WriteLine(await Test("B", "TestB"));
                Console.WriteLine(await Test("C", "C"));
                Console.WriteLine(await Test("D", "D"));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
            }

            Console.Write("press enter key to finish");
            Console.ReadLine();
        }

        static async Task<string> Test(string inputMessage, string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/Test/{action}")
            {
                Content = new MultipartFormDataContent
                {
                    { new StringContent(inputMessage), "InputMessage" }
                }
            };

            var response = await new HttpClient().SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

            return responseObject["OutputMessage"];
        }
    }
}
