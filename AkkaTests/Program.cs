using Akka.Actor;
using AkkaTests;

var system = ActorSystem.Create("test", """
akka {
    stdout-loglevel = DEBUG
    loglevel = DEBUG
    loggers = ["Akka.Event.StandardOutLogger"]
    actor.debug.unhandled = on
    
    actor {
      debug {
        receive = on
        autoreceive = on
        lifecycle = on
        event-stream = on
        unhandled = on
      }
    }
}
""");

var test = system.ActorOf<ForwardActor>();
test.Tell(new TestUsing());
test.Tell(PoisonPill.Instance);

await Task.Delay(1000);

Console.WriteLine($"Remaining count: {UsingCounter.Instance.Counter}");