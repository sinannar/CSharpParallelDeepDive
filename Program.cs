
// Parallel.Invoke(
//     () => { Console.WriteLine("Hello"); },
//     () => { Console.WriteLine("World"); });
ParallelInvoke(
    () => { Console.WriteLine("Hello"); },
    () => { Console.WriteLine("World"); });

Console.WriteLine("done!");

static void ParallelInvoke(params Action[] actions)
{
    var tasks = from action in actions select Task.Run(action);
    Task.WaitAll(tasks.ToArray());
}