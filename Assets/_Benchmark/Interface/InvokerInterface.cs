using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace StinkySteak.Benchmark.Observer
{
    public class InvokerInterface : MonoBehaviour
    {
        private List<IListener> _listeners;

        public void Setup()
        {
            int size = BenchmarkConst.IterationSize;

            _listeners = new(size);

            for (int i = 0; i < size; i++)
            {
                _listeners.Add(new ListenerInterface());
            }
        }

        private void RemoveAllSubscribers()
        {
            _listeners.Clear();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Profiler.BeginSample("Invoker Interface - Invoke");
                foreach (var listener in _listeners)
                    listener.Invoke();
                Profiler.EndSample();
                Debug.Break();
                BenchmarkUtility.ExtremeGCAlloc();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Profiler.BeginSample("Invoker Interface - Remove");
                RemoveAllSubscribers();
                Profiler.EndSample();
                Debug.Break();

                BenchmarkUtility.ExtremeGCAlloc();
            }
        }
    }
}