using System;
using System.Collections.Generic;
using System.IO;
using Water.Droid;
using Water.Models;
using Water.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileDS))]

namespace Water.Droid
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
            var users = new List<User>();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var files = Directory.GetFiles(documentsPath);
            foreach (var file in files)
            {
                var allData = ReadData(file);
                var lines = allData.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
                var user = new User
                {
                    Id = lines[0],
                    Name = lines[1],
                    PhoneNumber = lines[2],
                    Email = lines[3],
                    WaterBalance = lines[4],
                    Consultation = lines[5]
                };
                users.Add(user);
            }

            return users;
        }
    }
}