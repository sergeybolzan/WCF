using Client2.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DriveSpaceClient proxy = new DriveSpaceClient())
            {
                Console.WriteLine("Введите имя диска: ");
                string diskName = Console.ReadLine();

                string freeSpace = proxy.FreeSpace(diskName);
                if (String.IsNullOrEmpty(freeSpace)) Console.WriteLine("Wrong disk!");
                else Console.WriteLine("Свободно места на диске: {0} байт", freeSpace);

                string totalSpace = proxy.TotalSpace(diskName);
                if (String.IsNullOrEmpty(totalSpace)) Console.WriteLine("Wrong disk!");
                else Console.WriteLine("Общий объем диска: {0} байт", totalSpace);

                Console.WriteLine("Для завершения нажмите <ENTER>\n");
                Console.ReadLine();
            }
        }
    }
}
