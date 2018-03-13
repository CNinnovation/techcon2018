using SampleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkClientApp
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
