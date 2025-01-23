using Akka.Actor;

namespace AkkaTests;

public class TestActor : ReceiveActor
{
    public TestActor()
    {
        ReceiveAsync<TestUsing>(HandleTestUsingAsync);
    }

    private async Task HandleTestUsingAsync(TestUsing arg)
    {
        using (UsingCounter.Instance.Using())
        {
            await Task.Delay(100);
        }
    }
}