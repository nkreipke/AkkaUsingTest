using Akka.Actor;

namespace AkkaTests;

public class ForwardActor : ReceiveActor
{
    private IActorRef? _innerActor;

    public ForwardActor()
    {
        ReceiveAny(HandleAny);
    }

    private void HandleAny(object obj)
    {
        if (_innerActor == null)
            _innerActor = Context.ActorOf<TestActor>();

        _innerActor.Forward(obj);
    }
}