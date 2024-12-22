namespace StinkySteak.Benchmark.Observer
{
    public static class BenchmarkUtility
    {
        public static void ExtremeGCAlloc()
        {
            int[] a = new int[10_000_000];
        }
    }
}