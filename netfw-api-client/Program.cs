using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
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
            Console.WriteLine();

            //Console.Write("press enter key to start");
            //Console.ReadLine();

            Thread.Sleep(2000);

            try
            {
                //await Test1("1 - A", "Test1", "TestA");
                //await Test1("1 - B", "Test1", "TestB");
                //await Test1("1 - C", "Test1", "C");
                //await Test1("1 - D", "Test1", "D");

                await Test2GetAll();
                await Test2GetId();
                await Test2Insert();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
            }

            Console.Write("press enter key to finish");
            Console.ReadLine();
        }

        static async Task Test1(string inputMessage, string controller, string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/{controller}/{action}")
            {
                Content = new MultipartFormDataContent
                {
                    { new StringContent(inputMessage), "InputMessage" }
                }
            };

            var response = await new HttpClient().SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{inputMessage} - {responseObject["OutputMessage"]}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{inputMessage} - {response.StatusCode}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        static async Task Test2GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/Test2");

            await Test2Execute("Test2GetAll", request);
        }

        static async Task Test2GetId()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/Test2/1");

            await Test2Execute("Test2GetId", request);
        }

        static async Task Test2Insert()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/Test2");

            var collection = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string> ("fistName", "Hello"),
                new KeyValuePair<string, string> ("lastName", "World"),
                new KeyValuePair<string, string> ("email", "hello@world.com")
            };

            var content = new FormUrlEncodedContent(collection);

            request.Content = content;

            await Test2Execute("Test2Insert", request);
        }

        static async Task Test2Update()
        {
        }

        static async Task Test2Delete()
        {
        }

        static async Task Test2Execute(string test, HttpRequestMessage request)
        {
            var client = new HttpClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{test} - {responseText}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{test} - {response.StatusCode}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
;