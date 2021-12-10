using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var asd2 = new List<Task>();
            for (int i = 0; i < int.Parse(args[0]); i++)
            {
                Console.WriteLine($"task{i} elindult");
                asd2.Add(Task.Run(asd));
            }
            //Parallel.For(0, int.Parse(args[0]), new ParallelOptions { MaxDegreeOfParallelism = 6 }, (i) => { asd(); Debug.WriteLine($"task{i} elindult"); });
            Task.WaitAll(asd2.ToArray());
        }

        private async static Task asd()
        {
            var connection = new HubConnectionBuilder()
                        .WithUrl(new Uri("https://localhost:44340/chathub"), options =>
                        {
                            options.CloseTimeout = TimeSpan.FromSeconds(1000);
                        })
                        .Build();
            connection.ServerTimeout = TimeSpan.FromSeconds(1000);
            connection.HandshakeTimeout = TimeSpan.FromSeconds(1000);
            connection.Closed += (error) =>
            {
                return Task.CompletedTask;
            };
            connection.Reconnecting += async (asd) =>
            {
                await connection.StopAsync();
            };
            await connection.StartAsync();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await connection.InvokeAsync("NewMessage", new ChatMessageDTO { Text = "SZIA BAZDMEG KUTYAIDAT SETALTATOD", User = new UserDTO { Id = new Guid("3cb0a7e1-0d4c-4236-1071-08d9967d6cc7") } }, "TesztLobby");
            Console.WriteLine($"task vege {stopwatch.ElapsedMilliseconds} alatt");
        }
    }
    public class ChatMessageDTO
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public UserDTO User { get; set; }

        public DateTime TimeStamp { get; set; }
    }

    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Sub { get; set; }

        public int AccountType { get; set; }

        public string LobbyName { get; set; }

        public int Side { get; set; }
    }
}
