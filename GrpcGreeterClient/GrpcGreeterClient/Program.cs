using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //Console.WriteLine("Hello World!");

        //}
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                                    new HelloRequest { Name = "GreeterClient111" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
