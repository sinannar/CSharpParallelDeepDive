
// Parallel.Invoke(
//     () => { Console.WriteLine("Hello"); },
//     () => { Console.WriteLine("World"); });
ParallelInvoke(
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("World"); });

Console.WriteLine("done!");

static void ParallelInvoke(params Action[] actions)
{
    if (actions.Length < 10)
    {
        var tasks = from action in actions select Task.Run(action);
        Task.WaitAll(tasks.ToArray());
    }
    else
    {
        ParallelForEach(actions, action => action());
    }
}

static void ParallelForEach<T>(IEnumerable<T> source, Action<T> action)
{
    var tasks = from item in source select Task.Run(() => action(item));
    Task.WaitAll(tasks.ToArray());
}