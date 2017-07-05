using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MyDiskInfo
{
    [ServiceContract]
    public interface IDriveSpace
    {
        [OperationContract]
        string FreeSpace(string str);
        [OperationContract]
        string TotalSpace(string str);
    }
    public class DriveSpace : IDriveSpace
    {
        public string FreeSpace(string str)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(Char.ToString(str[0]));
                return driveInfo.AvailableFreeSpace.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string TotalSpace(string str)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(Char.ToString(str[0]));
                return driveInfo.TotalSize.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(DriveSpace));

            ServiceMetadataBehavior behavior = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (behavior == null)
            {
                behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(behavior);
            }
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            
            serviceHost.Open();
            Console.WriteLine("Для завершения нажмите <ENTER>\n");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
