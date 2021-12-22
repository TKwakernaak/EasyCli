using System;
using System.Threading.Tasks;

namespace EasyCli.SampleData
{
    public class TestCommandHandlerImpl : ITestCommandHandler
    {
        public Task RunAsync(TestCommand command)
        {
            Console.WriteLine($"Inside {nameof(TestCommandHandlerImpl)}");
            return Task.CompletedTask;
        }
    }
}
