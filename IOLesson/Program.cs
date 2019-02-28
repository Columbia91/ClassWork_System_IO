using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            Console.WriteLine("Программа для создания файла.");

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if(drives[i].IsReady)
                Console.WriteLine($"{i}.{drives[i].Name}");
            }
            Console.WriteLine("Выберите диск, в котором хотите создать файл, написав его порядковый номер: ");
            var number = int.Parse(Console.ReadLine());

            path = drives[number].Name;
            Console.WriteLine($"Выбран диск {path}");

            foreach(var directory in drives[number].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine($"Папка {directory.Name}");
            }

            Console.WriteLine("Напишите название папки, которую хотите создать: ");
            var directoryName = Console.ReadLine();
            path += directoryName;

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Console.WriteLine("Напишите название файла, который хотите создать: ");

            var fileName = Console.ReadLine();
            path += @"\" + fileName;
            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
            }

            string data = "Какой-то текст"; // источник
            // нашим потребителем является file, который мы до этого создали
            // который можно получить через переменную FileInfo или через path до файла

            //using(var fileStream = new FileStream(path, FileMode.Open))
            //{
            //    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            //    fileStream.Write(dataBytes, 0, dataBytes.Length);
            //}

            //using (var fileStream = new FileStream(path, FileMode.Open))
            //{
            //    byte[] buffer = new byte[fileStream.Length];
            //    fileStream.Read(buffer, 0, buffer.Length);
            //    string newData = Encoding.UTF8.GetString(buffer);
            //    Console.WriteLine(newData);
            //}

            using(var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(data);
            }

            using (var streamReader = new StreamReader(path))
            {
                string result = streamReader.ReadToEnd();
            }
        }
    }
}
