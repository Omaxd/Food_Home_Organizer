using PresentationLayer;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Shell
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        //static async Task Main(string[] args)
        {
            string mode = (args.Length == 0) ? null : args[0];

            RunManager.RunApplication(mode);
        }
    }
}
