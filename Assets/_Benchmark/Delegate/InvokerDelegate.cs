using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Profiling;

namespace StinkySteak.Benchmark.Observer
{
    public class InvokerDelegate : MonoBehaviour
    {
        private List<ListenerDelegate> _listeners;
        public event Action Delegate;

        public void Setup()
        {
            int size = BenchmarkConst.IterationSize;

            _listeners = new(size);

            for (int i = 0; i < size; i++)
            {
                var listener = new ListenerDelegate();
                listener.Initialize(this);

                _listeners.Add(listener);
            }
        }

        private void RemoveAllSubscribers()
        {
            Delegate = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Profiler.BeginSample("Invoker Delegate - Invoke");
                Delegate?.Invoke();
                Profiler.EndSample();
                Debug.Break();

                BenchmarkUtility.ExtremeGCAlloc();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Profiler.BeginSample("Invoker Delegate - Remove");
                RemoveAllSubscribers();
                Profiler.EndSample();
                Debug.Break();

                BenchmarkUtility.ExtremeGCAlloc();

            }
        }
    }
}