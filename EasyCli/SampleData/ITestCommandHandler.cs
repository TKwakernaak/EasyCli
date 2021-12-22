using System.Threading.Tasks;

namespace EasyCli.SampleData
{
    public interface ITestCommandHandler
    {
        public Task RunAsync(TestCommand command);
    }
}
