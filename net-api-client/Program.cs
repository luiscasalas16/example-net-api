using Newtonsoft.Json;

namespace net_api_client
{
    internal class Program
    {
        static string url = "http://localhost:5000";

        static async Task Main(string[] args)
        {
            Console.WriteLine("net");

            //Console.Write("press enter key to start");
            //Console.ReadLine();

            Thread.Sleep(2000);

            try
            {
                await Test("1 - A", "Test1", "TestA");
                await Test("1 - B", "Test1", "TestB");
                await Test("1 - C", "Test1", "C");
                await Test("1 - D", "Test1", "D");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
            }

            Console.Write("press enter key to finish");
            Console.ReadLine();
        }

        static async Task Test(string inputMessage, string controller, string action)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}/{controller}/{action}")
            {
                Content = new MultipartFormDataContent
                {
                    { new StringContent(inputMessage), "InputMessage" }
                }
            };

            var response = await new HttpClient().SendAsync(request);

            if (response.IsSuccessStatusCode) {
                var responseText = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText)!;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{inputMessage} - {responseObject["outputMessage"]}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{inputMessage} - {response.StatusCode}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}