namespace EasyCli.SampleData
{
    public class TestCommand
    {
        public int OrderId { get; private set; }

        public TestCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
