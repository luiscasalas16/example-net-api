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

            Thread.Sleep(1000);

            try
            {
                await Test1Get("1 - 0", "Test1", "Get");
                await Test1Get("1 - A", "Test1", "GetA");
                await Test1Get("1 - B", "Test1", "GetB");
                await Test1Get("1 - C", "Test1", "CGet");
                await Test1Get("1 - D", "Test1", "DGet");

                await Test1Post("1 - 0", "Test1", "Post");
                await Test1Post("1 - A", "Test1", "PostA");
                await Test1Post("1 - B", "Test1", "PostB");
                await Test1Post("1 - C", "Test1", "CPost");
                await Test1Post("1 - D", "Test1", "DPost");

                await Test2GetAll();
                await Test2GetId();
                await Test2Insert();
                await Test2Update();
                await Test2Delete();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
            }

            Console.Write("press enter key to finish");
            Console.ReadLine();
        }

        static async Task Test1Get(string test, string controller, string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{controller}/{action}");

            await Test1Execute(test, request);
        }

        static async Task Test1Post(string test, string controller, string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/{controller}/{action}")
            {
                Content = new StringContent
                (
                    @"{
                        ""InputMessage"":""" + test + @"""
                    }",
                    null,
                    "application/json"
                )
            };

            await Test1Execute(test, request);
        }

        static async Task Test1Execute(string test, HttpRequestMessage request)
        {
            var response = await new HttpClient().SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{test} - {responseObject["OutputMessage"]}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{test} - {response.StatusCode}");
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

            request.Content = new StringContent
            (
                @"{
                    ""fistName"":""Hello"",
                    ""lastName"":""World"",
                    ""email"":""hello@world.com""
                }",
                null,
                "application/json"
            );

            await Test2Execute("Test2Insert", request);
        }

        static async Task Test2Update()
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{url}/Test2/1");

            request.Content = new StringContent
            (
                @"{
                    ""fistName"":""Hello"",
                    ""lastName"":""World"",
                    ""email"":""hello@world.com""
                }",
                null,
                "application/json"
            );

            await Test2Execute("Test2Update", request);
        }

        static async Task Test2Delete()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}/Test2/1");

            await Test2Execute("Test2Delete", request);
        }

        static async Task Test2Execute(string test, HttpRequestMessage request)
        {
            var client = new HttpClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseText = await response.Content.ReadAsStringAsync();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{test} - {(!string.IsNullOrWhiteSpace(responseText) ? responseText : "empty")}");
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