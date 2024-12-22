using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace StinkySteak.Benchmark.Observer
{
    public class InvokerVirtual : MonoBehaviour
    {
        private List<ListenerVirtual> _listeners;

        public void Setup()
        {
            int size = BenchmarkConst.IterationSize;

            _listeners = new(size);

            for (int i = 0; i < size; i++)
            {
                _listeners.Add(new ListenerVirtual());
            }
        }

        private void RemoveAllSubscribers()
        {
            _listeners.Clear();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Profiler.BeginSample("Invoker Virtual - Invoke");
                foreach (var listener in _listeners)
                    listener.Invoke();
                Profiler.EndSample();
                Debug.Break();

                BenchmarkUtility.ExtremeGCAlloc();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Profiler.BeginSample("Invoker Virtual - Remove All");
                RemoveAllSubscribers();
                Profiler.EndSample();
                Debug.Break();

                BenchmarkUtility.ExtremeGCAlloc();

            }
        }
    }
}