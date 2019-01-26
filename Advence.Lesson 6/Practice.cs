using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Advence.Lesson_6
{
    public partial class Practice
    {
        /// <summary>
        /// AL6-P1/7-DirInfo. Вывести на консоль следующую информацию о каталоге “c://Program Files”:
        /// Имя
        /// Дата создания
        /// </summary>
        public static void AL6_P1_7_DirInfo()
        {
            var dirPath = "c:/windows";
            var newDir = new DirectoryInfo(dirPath);
            var dirName = newDir.Name;
            var dirCreationTime = newDir.CreationTime;
            Console.WriteLine($"{dirName}\n{dirCreationTime}");
        }


        /// <summary>
        /// AL6-P2/7-FileInfo. Получить список файлов каталога и для каждого вывести значение:
        /// Имя
        /// Дата создания
        /// Размер 
        /// </summary>
        public static void AL6_P2_7_FileInfo()
        {
            var dirPath = "c:/windows";
            var newDir = new DirectoryInfo(dirPath);
            var dirFileList = newDir.GetFiles("*.exe");
            foreach (var file in dirFileList)
            {
                Console.WriteLine($"Name: {file.Name}");
                Console.WriteLine($"Created at: {file.CreationTime}");
                Console.WriteLine($"Size: {file.Length}\n");
            }
        }

        /// <summary>
        /// AL6-P3/7-CreateDir. Создать пустую директорию “c://Program Files Copy”.
        /// </summary>
        public static void AL6_P3_7_CreateDir()
        {
            var dirPath = "d:/newTmpDir";
            if (Directory.Exists(dirPath))
            {
                Directory.Delete(dirPath);
            }
            var newDir = Directory.CreateDirectory(dirPath);
            Console.WriteLine(newDir.CreationTime);
        }


        /// <summary>
        /// AL6-P4/7-CopyFile. Скопировать первый файл из Program Files в новую папку.
        /// </summary>
        public static void AL6_P4_7_CopyFile()
        {
            var fileDir = "c:/windows";
            var copyDir = "d:/newTmpDir";
            var newDir = new DirectoryInfo(fileDir);
            var fileList = newDir.GetFiles("*.exe");
            if (File.Exists($"{copyDir}/{fileList[0].Name}"))
            {
                File.Delete($"{copyDir}/{fileList[0].Name}");
            }
            fileList[0].CopyTo($"{copyDir}/{fileList[0].Name}");

            Console.WriteLine("File copied");
        }

        /// <summary>
        /// AL6-P5/7-FileChat. Написать программу имитирующую чат. 
        /// Пускай в ней будут по очереди запрашивается реплики для User 1 и User 2 (используйте цикл из 5-10 итераций).  Сохраняйте данные реплики с ником пользователя и датой в файл на диске.
        /// </summary>
        public static void AL6_P5_7_FileChat()
        {
            var filePath = "d:/newTmpDir/newChat.txt";
            using (var fileAdapter = new StreamWriter(filePath, true))
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("User1: ");
                    fileAdapter.WriteLine($"[{DateTime.Now.ToString()}] User1: {Console.ReadLine()}");
                    Console.Write("User2: ");
                    fileAdapter.WriteLine($"[{DateTime.Now.ToString()}] User2: {Console.ReadLine()}");
                }
            }
        }

        /// <summary>
        /// AL6-P6/7-ConsoleSrlz. (Демонстрация). 
        /// Сериализовать обьект класса Song в XML.Вывести на консоль.
        /// Десериализовать XML из строковой переменной в объект.
        /// </summary>
        public static void AL6_P6_7_ConsoleSrlzn()
        {
            Song song = new Song()
            {
                Title = "Title 1",
                Duration = 247,
                Lyrics = "Lyrics 1"
            };
            Console.WriteLine(song.Title);

            string strToPrint, newStr;
            int firstIndex, lastIndex, xmlTagLen = "<Title>".Length;
            var newSrlzr = new XmlSerializer(typeof(Song));

            using (StringWriter newText = new StringWriter())
            {
                newSrlzr.Serialize(newText, song);
                strToPrint = newText.ToString();
            }
            Console.WriteLine(strToPrint);

            firstIndex = xmlTagLen + strToPrint.IndexOf("<Title>");
            lastIndex = strToPrint.IndexOf("</Title>");

            newStr = strToPrint.Substring(0, firstIndex) + "New title" + strToPrint.Substring(lastIndex);
            Console.WriteLine(newStr);

            using (StringReader newText = new StringReader(newStr))
            {
                song = (Song)newSrlzr.Deserialize(newText);
            }
            Console.WriteLine(song.Title);
        }

        /// <summary>
        /// AL6-P7/7-FileSrlz.
        /// Отредактировать предыдущий пример для поддержки сериализации и десериализации в файл.
        /// </summary>
        public static void AL6_P7_7_FileSrlz()
        {
            Song song = new Song()
            {
                Title = "Title 1",
                Duration = 247,
                Lyrics = "Lyrics 1"
            };
            var xmlFilePath = @"d:\newTmpDir\song.xml";

            Console.WriteLine(song.Duration);

            var newSrlzr = new XmlSerializer(typeof(Song));

            Console.WriteLine("Serializing");
            using (var xmlWriter = XmlWriter.Create(xmlFilePath))
            {
                newSrlzr.Serialize(xmlWriter, song);
            }
            song.Duration = 300;
            Console.WriteLine(song.Duration);

            Console.WriteLine("Deserializing");
            using (var xmlReader = XmlReader.Create(xmlFilePath))
            {
                song = (Song)newSrlzr.Deserialize(xmlReader);
            }
            Console.WriteLine(song.Duration);
        }

    }
}
