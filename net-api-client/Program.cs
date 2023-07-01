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

            Thread.Sleep(2000);

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
                Content = new MultipartFormDataContent
                {
                    { new StringContent(test), "InputMessage" }
                }
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
                Console.WriteLine($"{test} - {responseObject["outputMessage"]}");
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