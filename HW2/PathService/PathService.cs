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
        public string GetFolderСontents(string path)
        {
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
                return contents;
            }
            else return "Каталога по указанному пути не существует";
        }
    }
}
