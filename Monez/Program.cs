using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Monez
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public Program()
        {

        }

        public async Task StartNServiceBus()
        {
            var endpointConfiguration = new EndpointConfiguration("ConsoleUI");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();


        } 
    }
}
