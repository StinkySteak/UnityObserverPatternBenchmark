using StinkySteak.Benchmark.Observer;
using UnityEngine;
using UnityEngine.Profiling;

public class BenchmarkLauncher : MonoBehaviour
{
    [SerializeField] private bool _enableAutoKill;
    [SerializeField] private int _autoKillAfterFrame = 100;

    [Space]
    [SerializeField] private int _targetFPS;
    [SerializeField] private bool _autoSetup;
    
    [Space]
    [SerializeField] private InvokerDelegate _invokerDelegate;
    [SerializeField] private InvokerDirect _invokerDirect;
    [SerializeField] private InvokerInterface _invokerInterface;
    [SerializeField] private InvokerVirtual _invokerVirtual;

    private void Start()
    {
        Application.targetFrameRate = _targetFPS;

        if (_autoSetup)
            Setup();
    }

    private void Setup()
    {
        Profiler.BeginSample("Invoker Delegate");
        _invokerDelegate.Setup();
        Profiler.EndSample();
        
        Profiler.BeginSample("Invoker Direct");
        _invokerDirect.Setup();
        Profiler.EndSample();
        
        Profiler.BeginSample("Invoker Interface");
        _invokerInterface.Setup();
        Profiler.EndSample();
        
        Profiler.BeginSample("Invoker Virtual");
        _invokerVirtual.Setup();
        Profiler.EndSample();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Setup();
        }

        if (!_enableAutoKill) return;

        if (Time.frameCount >= _autoKillAfterFrame)
        {
            Application.Quit();
        }
    }
}
