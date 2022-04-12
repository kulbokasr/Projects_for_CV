using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdroitiWordCount.Services
{
    public class FileService : IFileService
    {
        public string ReadFile()
        {
            string allText = File.ReadAllText("TextFile.txt");
            return allText;
        }
    }
}
