namespace AkkaTests;

public class UsingCounter
{
    private int _counter;

    private UsingCounter()
    {
    }

    public static readonly UsingCounter Instance = new();

    public int Counter => Volatile.Read(ref _counter);

    public IDisposable Using()
    {
        Console.WriteLine("Start using");

        Interlocked.Increment(ref _counter);

        return new Disposer(this);
    }

    private class Disposer : IDisposable
    {
        private readonly UsingCounter _counter;

        public Disposer(UsingCounter counter)
        {
            _counter = counter;
        }

        public void Dispose()
        {
            Console.WriteLine("End using");

            Interlocked.Decrement(ref _counter._counter);
        }
    }
}