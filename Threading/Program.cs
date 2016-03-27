namespace Threading
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            ////Thread.Sleep(5000);
            //// when debugging, AppDomain is Text.vshost.exe, otherwise Text.exe
            Console.WriteLine($"AppDomain: {System.AppDomain.CurrentDomain.FriendlyName}");
            Console.WriteLine($"Num of processor: {Environment.ProcessorCount}");
            Console.WriteLine($"CurrentManagedThreadId:  {Environment.CurrentManagedThreadId}");
            Console.WriteLine($"CurrentDirectory:  {Environment.CurrentDirectory}");
            Console.WriteLine($"GetCurrentProcess.Threads.Count:  {Process.GetCurrentProcess().Threads.Count}");

            int workers;
            int io;
            ThreadPool.GetMinThreads(out workers, out io);
            Console.WriteLine($"{workers}, {io}");

            ThreadPool.GetMaxThreads(out workers, out io);
            Console.WriteLine($"{workers}, {io}");

            if (ThreadPool.SetMaxThreads(8, 8))
            {
                Console.WriteLine("Set max successfully");
            }
            else
            {
                Console.WriteLine("Set max failed");
            }

            ThreadPool.GetMaxThreads(out workers, out io);
            Console.WriteLine($"after set, max: {workers}, {io}");

            Console.ReadLine();
        }
    }
}
