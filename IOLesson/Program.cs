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
            string drName = null; 
            string path = @"C:/new folder";
            Directory.CreateDirectory(@"C:/new folder/myDir");
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var innerDirectories= directoryInfo.GetDirectories();
            foreach( var dir in innerDirectories)
            {
                Console.WriteLine(dir.FullName);
            }
            //File.Create($"{path}/file.txt");
            File.AppendAllText($"{path}/file.txt", "mama asdas");
            var drives = DriveInfo.GetDrives();
            foreach(var drq in drives)
            {
                Console.WriteLine(drq.Name); 
            }



            FileStream fileStream = null;
            try
            {
               fileStream = new FileStream(@"C:/new folder/file.txt", FileMode.Append);
                fileStream.Close();
            }
            catch(FileNotFoundException e){
                Console.WriteLine(e.Message);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { fileStream.Close(); }

            try
            {
                using (FileStream stream = new FileStream(@"C:/new folder/file.txt", FileMode.Append))
                {
                    string fileName = "blahblah.jpeg";
                    byte[] fileInfo = Encoding.ASCII.GetBytes(fileName);
                    stream.Write(fileInfo,0,fileInfo.Length);
                }


                using (FileStream stream = new FileStream(@"C:/new folder/file.txt", FileMode.Open))
                {
                    byte[] buf = new byte[stream.Length];
                    foreach(byte a in buf)
                    {
                        Console.Write(a);
                    }
                    Console.WriteLine();
                    stream.Read(buf, 0, (int)stream.Length);
                    string result = Encoding.ASCII.GetString(buf);
                    Console.WriteLine(result);
                }
            }
            catch { /*   */}


            Console.WriteLine("-----------------------------------------");
            string directoryPath = @"data/docs/";
            string fileName2 = "file.txt";

            DriveInfo[] dr = DriveInfo.GetDrives();
           
            for(int i = 0; i<dr.Length; i++)
            {
                Console.WriteLine($"{i}.{dr[i].Name}");
                
            }
            Console.WriteLine("введите номер  дика ,  на которой будет записн файл: ");
            string driveNumberAsString = Console.ReadLine();
            int driveNumber = 0;
            if (!int.TryParse(driveNumberAsString, out driveNumber))
            {
                Console.WriteLine("Ошибка ввода, будет произведена запись на первый указаный диск.");
            }
            else
            {
                drName = dr[driveNumber].Name;
            }
            if (!Directory.Exists(drName + directoryPath))
            {
                Directory.CreateDirectory(drName + directoryPath);
            }


            if(!File.Exists(drName + directoryPath + fileName2))
            {
                File.Create(drName + directoryPath + fileName2);
            }
            try
            {
                using(StreamWriter streamWriter=new StreamWriter(drName + directoryPath + fileName2))
                {
                    string text = "Олег Сергеевич \\n самый крутой";
                    streamWriter.WriteLine(text);
                }

                using (StreamReader streamReader = new StreamReader(drName + directoryPath + fileName2))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
