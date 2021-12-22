using System;
using System.Threading.Tasks;
using EasyCli.Extensions;
using EasyCli.SampleData;

namespace EasyCli.Menu.Actions
{
    public class SampleAction : ICliAction
    {
        public string Description => "Execute a test command that creates a new order";

        private readonly ITestCommandHandler _messageHandler;

        public SampleAction(ITestCommandHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("\n for which orderId do you wish to run this action? \n");

            var selectedOrderId = Console.ReadLine();
            var selectedEvent = new TestCommand(int.Parse(selectedOrderId));
            selectedEvent.WriteToConsole();

            await _messageHandler.RunAsync(selectedEvent);

            Console.WriteLine($"\n finished {nameof(SampleAction)} \n");
        }
    }
}
