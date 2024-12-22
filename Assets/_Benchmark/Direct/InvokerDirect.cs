using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
namespace StinkySteak.Benchmark.Observer
{
    public class InvokerDirect : MonoBehaviour
    {
        private List<ListenerDirect> _listeners;

        public void Setup()
        {
            int size = BenchmarkConst.IterationSize;

            _listeners = new(size);

            for (int i = 0; i < size; i++)
            {
                ListenerDirect listener = new ListenerDirect();

                _listeners.Add(listener);
            }
        }

        private void RemoveAllSubscribers()
        {
            _listeners.Clear();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Profiler.BeginSample("Invoker Direct - Invoke");
                foreach (ListenerDirect listener in _listeners)
                    listener.Invoke();
                Profiler.EndSample();
                Debug.Break();

                BenchmarkUtility.ExtremeGCAlloc();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Profiler.BeginSample("Invoker Direct - Remove");
                RemoveAllSubscribers();
                Profiler.EndSample();
                Debug.Break();

                BenchmarkUtility.ExtremeGCAlloc();

            }
        }
    }
}