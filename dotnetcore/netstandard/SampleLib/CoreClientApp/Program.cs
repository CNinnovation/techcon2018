using SampleLib;
using System;

namespace CoreClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();
            Console.WriteLine(demo.Greeting("Katharina"));
            demo.ShowMessage("real?");
        }
    }
}
