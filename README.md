# UnityObserverPatternBenchmark

### Tested Approaches
- Delegates
- List of Interfaces
- List of Virtual Calls
- List of Direct Call

## Tested Scripting Backend
- Mono
- IL2CPP

## Device Specifications
- Dell G15
- i7 11700H, RTX 3050, 32GB RAM

## Measurement
- CPU Time
- Memory Usage

## Benchmarks
### Memory Usage (PreAlloc List)

| Method       | Count | Allocated |
|--------------|-------|-----------|
| Delegates    | 1000   |    4.1MB       |
| Interface    | 1000   |       23.5kB    |
| Virtual Call | 1000   |       23.5kB    |
| Direct Call  | 1000   |     23.5kB      |
<!--
### CPU Time

#### 1 - Editor
##### Subscribe
| Method       | Count | CPU Time |
|--------------|-------|----------|
| Delegates    | 1000   |    2.11ms      |
| Interface    | 1000   |   0.20ms       |
| Virtual Call | 1000   |    0.20ms      |
| Direct Call  | 1000   |    0.20ms      |

##### Invoke (WIP)
| Method       | Count | CPU Time |
|--------------|-------|----------|
| Delegates    | 1000   |          |
| Interface    | 1000   |          |
| Virtual Call | 1000   |          |
| Direct Call  | 1000   |          |

#### 2 - Mono (WIP)
| Method       | Count | CPU Time |
|--------------|-------|----------|
| Delegates    | 1000   |          |
| Interface    | 1000   |          |
| Virtual Call | 1000   |          |
| Direct Call  | 1000   |          |

#### 3 - IL2CPP
| Method       | Count | CPU Time |
|--------------|-------|----------|
| Delegates    | 1000   |    5.49ms      |
| Interface    | 1000   |     0.49ms     |
| Virtual Call | 1000   |    0.30ms      |
| Direct Call  | 1000   |    0.48ms      |
->