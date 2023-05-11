using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;

namespace SimpleBrokeredMessaging.Sender
{
    internal class SenderConsole
    {

        //ToDo: Enter a valid Service Bus connection string
        static string ConnectionString = "";
        static string QueueName = "demoqueue";

        static string Sentance = "The quick brown fox jumps over the lazy dog";


        static async Task Main(string[] args)
        {
            // Create a service bus client
            var client = new ServiceBusClient(ConnectionString);

            // Create a service bus sender
            var sender = client.CreateSender(QueueName);

            // Send some messages
            Console.WriteLine("Sending messages...");
            foreach (var character in Sentance)
            {               
                var message = new ServiceBusMessage(character.ToString());
                await sender.SendMessageAsync(message);
                Console.WriteLine($"    Sent: { character }");
            }

            // Close the sender
            await sender.CloseAsync();
            Console.WriteLine("Sent messages.");
            Console.ReadLine();
        }
    }
}
