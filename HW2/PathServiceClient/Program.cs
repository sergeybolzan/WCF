using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathServiceClient.ServiceReference1;
namespace PathServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyPathServiceClient proxy = new MyPathServiceClient())
            {
                Console.WriteLine(proxy.GetFolderСontents(@"D:\"));
            }
        }
    }
}
