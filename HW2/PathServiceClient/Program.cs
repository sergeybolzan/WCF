using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathServiceClient.ServiceReference1;
using System.ServiceModel;

namespace PathServiceClient
{
    /// <summary>
    /// Класс, который наследует интерфейсу, определяющему на стороне службы контракт обратного вызова (callback).
    /// </summary>
    public class CallbackHandler: IMyPathServiceCallback
    {
        /// <summary>
        /// Метод, получающий сообщения от службы.
        /// </summary>
        /// <param name="contents"></param>
        public void GiveFolderContents(string contents)
        {
            Console.WriteLine(contents);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /* Для создания среды выполнения (хостинга) для объекта типа контракта обратного вызова используется объект класса InstanceContext. 
             * Другими словами, клиент хостит объект типа контракта обратного вызова с помощью объекта класса InstanceContext.
             * При создании объекта InstanceContext его конструктору надо передать объект класса, наследующего интерфейс обратного вызова. 
             * Также объект InstanceContext обрабатывает сообщения, приходящие от службы.*/
            InstanceContext site = new InstanceContext(new CallbackHandler());
            MyPathServiceClient proxy = new MyPathServiceClient(site);
            proxy.GetFolderСontents(@"C:\");
            Console.ReadKey();
        }
    }
}
