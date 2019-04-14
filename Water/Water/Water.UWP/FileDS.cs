using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Water.Models;
using Water.Services;
using Water.UWP;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(FileDS))]
namespace Water.UWP
{
    public class FileDS : IFile
    {
        public void WriteData(string file, string data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(documentsPath, file);
            File.WriteAllText(filePath, data);
        }

        public string ReadData(string file)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(documentsPath, file);
            return File.ReadAllText(filePath);
        }
    

        public void DeleteFile(string file)
        {
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var filePath = Path.Combine(documentsPath, file);
        File.Delete(filePath);
    }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var files = Directory.GetFiles(documentsPath);
            foreach (var file in files)
            {
                string allData = ReadData(file);
                string[] lines = allData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                User user = new User
                {
                    Id = lines[0],
                    Name = lines[1],
                    Email = lines[2],
                    PhoneNumber = lines[3],
                    WaterBalance = lines[4],
                    Consultation = lines[5]
                };
                users.Add(user);
            }
            return users;
        }
    }
}
