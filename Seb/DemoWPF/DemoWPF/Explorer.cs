using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.IO;
using System.Diagnostics;

namespace DemoWPF
{
    public class FileData
    {
        public string Name { get; private set; }
        public string FilePath { get; private set; }
        public string Extension { get; private set; }
        public FileData(string _path)
        {
            FilePath= _path;
            Extension = Path.GetExtension(_path);
            Name =Path.GetFileNameWithoutExtension(_path);
        }
        public void Open() => Process.Start(FilePath);
        public static bool operator !(FileData _this) => _this == null;
    }
    internal class Explorer
    {
        public void GetAllDirectories(string _path)
        {
            string[] _files = Directory.GetDirectories(_path);
          
        }
        public FileData[] GetAllFiles(string _path)
        {
            bool _isValid = Directory.Exists(_path);
            if (!_isValid) return null;

            string[] _files = Directory.GetFiles(_path, "*.*");//GetFiles(_path, search patern "*" =>all patern)
            FileData[] _data = new FileData[_files.Length];

            for (int i = 0; i < _files.Length; i++)
                _data[i] = new FileData(_files[i]);

            return _data;
                
        }
    }
}
