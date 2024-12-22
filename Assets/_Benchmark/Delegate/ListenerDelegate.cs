namespace StinkySteak.Benchmark.Observer
{
    public class ListenerDelegate
    {
        public void Initialize(InvokerDelegate invoker)
        {
            invoker.Delegate += Delegate;
        }

        private void Delegate()
        {

        }
    }
}