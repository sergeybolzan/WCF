using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client1
{
    [ServiceContract]
    public interface IDriveSpace
    {
        [OperationContract]
        string FreeSpace(string str);
        [OperationContract]
        string TotalSpace(string str);
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IDriveSpace> factory = new ChannelFactory<IDriveSpace>(new WSHttpBinding(), new EndpointAddress("http://localhost:80/Temporary_Listen_Addresses/MyDiskInfoService"));
            IDriveSpace channel = factory.CreateChannel();
            
            Console.WriteLine("Введите имя диска: ");
            string diskName = Console.ReadLine();

            string freeSpace = channel.FreeSpace(diskName);
            if (String.IsNullOrEmpty(freeSpace)) Console.WriteLine("Wrong disk!");
            else Console.WriteLine("Свободно места на диске: {0} байт", freeSpace);

            string totalSpace = channel.TotalSpace(diskName);
            if (String.IsNullOrEmpty(totalSpace)) Console.WriteLine("Wrong disk!");
            else Console.WriteLine("Общий объем диска: {0} байт", totalSpace);

            Console.WriteLine("Для завершения нажмите <ENTER>\n");
            Console.ReadLine();
            factory.Close();
        }
    }
}
