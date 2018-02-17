using NServiceBus;
using Shared;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Monez
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var program = new Program();
            ImportService.ImportService.Start();

            Console.ReadLine();

            program.StartNServiceBus();

            program.ImportFile();

            Console.ReadLine();
        }

        public Program()
        {
            endpointConfiguration = new EndpointConfiguration("ConsoleUI");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(ImportFile), "ImportService");
        }

        EndpointConfiguration endpointConfiguration;
        IEndpointInstance endpointInstance;

        public async Task StartNServiceBus()
        {
            endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
        } 

        public void ImportFile()
        {
            var importFileCommand = new ImportFile(@"C:\Users\Robin\Source\Repos\monez\20180217-6010039906-umsatz.CSV");

            endpointInstance.Send(importFileCommand);
        }
    }
}
