using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PathService
{
    public class MyPathService : IMyPathService
    {
        /// <summary>
        /// Метод, который может вызывать клиент.
        /// </summary>
        /// <param name="path"></param>
        public void GetFolderСontents(string path)
        {
            // Член типа контракта обратного вызова. Используется для доступа к каналу обратного вызова, от службы к клиенту.
            IClientCallback callback = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            
            if (Directory.Exists(path))
            {
                string contents = "";
                foreach (var directory in Directory.GetDirectories(path))
                {
                    contents += directory + "\n";
                }
                foreach (var file in Directory.GetFiles(path))
                {
                    contents += file + "\n";
                }
                callback.GiveFolderContents(contents);
            }
            else callback.GiveFolderContents("Каталога по указанному пути не существует");
        }
    }
}
