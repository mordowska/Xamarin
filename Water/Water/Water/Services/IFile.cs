using System;
using System.Collections.Generic;
using System.Text;
using Water.Models;

namespace Water.Services
{
    public interface IFile
    {
        void WriteData(string file, string data);
        string ReadData(string file);
        void DeleteFile(string file);
        List<User> GetAll();
    }
}
