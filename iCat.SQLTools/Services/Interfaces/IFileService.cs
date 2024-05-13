using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Services.Interfaces
{
    public interface IFileService
    {
        string Category { get; }
        string Folder { get; }
        bool CheckFileExist(string fileName);
        Task<string> ReadStringFileAsync(string fileName);
        Task SaveStringFileAsync(string fileName, string content);
    }
}
