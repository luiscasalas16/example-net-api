using Newtonsoft.Json;

namespace net_api_client
{
    internal class Program
    {
        static string url = "http://localhost:5000";

        static async Task Main(string[] args)
        {
            Console.WriteLine("net");
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

                await TestGetAll("Test2");
                await TestGetId("Test2");
                await TestInsert("Test2");
                await TestUpdate("Test2");
                await TestDelete("Test2");

                await TestGetAll("Test3");
                await TestGetId("Test3");
                await TestInsert("Test3");
                await TestUpdate("Test3");
                await TestDelete("Test3");

                await TestGet("1 - A", "Test4", "ErrorGet");
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

        static async Task TestGetAll(string controller)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{controller}");

            await TestExecute($"{controller}GetAll", request);
        }

        static async Task TestGetId(string controller)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{controller}/1");

            await TestExecute($"{controller}GetId", request);
        }

        static async Task TestInsert(string controller)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/{controller}");

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

            await TestExecute($"{controller}Insert", request);
        }

        static async Task TestUpdate(string controller)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{url}/{controller}/1");

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

            await TestExecute($"{controller}Update", request);
        }

        static async Task TestDelete(string controller)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}/{controller}/1");

            await TestExecute($"{controller}Delete", request);
        }

        static async Task TestExecute(string test, HttpRequestMessage request)
        {
            var client = new HttpClient();

            var response = await client.SendAsync(request);

            var responseText = await response.Content.ReadAsStringAsync();

            var responseTextPrint = responseText;

            if (responseTextPrint == null)
                responseTextPrint = "*null*";
            else if (string.IsNullOrEmpty(responseTextPrint))
                responseTextPrint = "*empty*";
            else if (string.IsNullOrWhiteSpace(responseTextPrint))
                responseTextPrint = "*whiteSpace*";

            Console.ForegroundColor = response.IsSuccessStatusCode ? ConsoleColor.Green : ConsoleColor.Red;

            Console.WriteLine($"{test} - {response.StatusCode} - {responseTextPrint}");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
        }
    }
}