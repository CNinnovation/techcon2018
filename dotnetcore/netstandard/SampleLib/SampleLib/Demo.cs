using DotnetFrameworkLib;
using System;

namespace SampleLib
{
    public class Demo
    {
        public string Greeting(string name) => $"Hello, {name}";

        public void ShowMessage(string message)
        {
            var dlg = new DialogService();
            dlg.ShowMessage(message);
        }
    }
}
