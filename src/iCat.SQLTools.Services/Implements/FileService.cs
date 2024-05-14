using iCat.SQLTools.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Services.Implements
{
    public class FileService : IFileService
    {

        public string Category { get; private set; }
        public string Folder => _folder;

        private readonly string _folder;

        public FileService(string category, string folder)
        {
            Category = category;
            _folder = folder ?? throw new ArgumentNullException(nameof(folder));
        }

        public bool CheckFileExist(string fileName)
        {
            return File.Exists(Path.Combine(_folder, fileName));
        }

        public async Task<string> ReadStringFileAsync(string fileName)
        {
            var result = "";
            using (var sr = new StreamReader(Path.Combine(_folder, fileName)))
            {
                result = await sr.ReadToEndAsync();
            }
            return result;
        }

        public async Task SaveStringFileAsync(string fileName, string content)
        {
            using (var sw = new StreamWriter(Path.Combine(_folder, fileName)))
            {
                await sw.WriteLineAsync(content);
                await sw.FlushAsync();
            }
        }
    }
}
