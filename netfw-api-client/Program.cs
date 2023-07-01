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
                await TestGet("1 - 0", "Test1", "Get");
                await TestGet("1 - A", "Test1", "GetA");
                await TestGet("1 - B", "Test1", "GetB");
                await TestGet("1 - C", "Test1", "CGet");
                await TestGet("1 - D", "Test1", "DGet");
                await TestPost("1 - 0", "Test1", "Post");
                await TestPost("1 - A", "Test1", "PostA");
                await TestPost("1 - B", "Test1", "PostB");
                await TestPost("1 - C", "Test1", "CPost");
                await TestPost("1 - D", "Test1", "DPost");

                await Test2GetAll();
                await Test2GetId();
                await Test2Insert();
                await Test2Update();
                await Test2Delete();

                await TestGet("1 - A", "Test3", "ErrorGet");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
            }

            Console.Write("press enter key to finish");
            Console.ReadLine();
        }

        static async Task TestGet(string test, string controller, string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{controller}/{action}");

            await TestExecute(test, request);
        }

        static async Task TestPost(string test, string controller, string action)
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

            await TestExecute(test, request);
        }

        static async Task Test2GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/Test2");

            await TestExecute("Test2GetAll", request);
        }

        static async Task Test2GetId()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/Test2/1");

            await TestExecute("Test2GetId", request);
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

            await TestExecute("Test2Insert", request);
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

            await TestExecute("Test2Update", request);
        }

        static async Task Test2Delete()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}/Test2/1");

            await TestExecute("Test2Delete", request);
        }

        static async Task TestExecute(string test, HttpRequestMessage request)
        {
            var client = new HttpClient();

            var response = await client.SendAsync(request);

            var responseText = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{test} - {response.StatusCode} - {(!string.IsNullOrWhiteSpace(responseText) ? responseText : "empty")}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{test} - {response.StatusCode} - {(!string.IsNullOrWhiteSpace(responseText) ? responseText : "empty")}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
;