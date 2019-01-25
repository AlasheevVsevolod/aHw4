using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var newDir = new DirectoryInfo("C:/Users/user/Source/Repos/03-12-2018/A-4(6)-Files, Streams, Serialziation/Advence.Lesson 6");
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
            var newDir = new DirectoryInfo("C:/Users/user/Source/Repos/03-12-2018/A-4(6)-Files, Streams, Serialziation/Advence.Lesson 6");
            var dirFileList = newDir.GetFiles("*.cs");
            foreach (var file in dirFileList)
            {
                Console.WriteLine($"Name: {file.Name}");
                Console.WriteLine($"Created at: {file.CreationTime}");
                Console.WriteLine($"Size: {file.Length}");
            }
        }

        /// <summary>
        /// AL6-P3/7-CreateDir. Создать пустую директорию “c://Program Files Copy”.
        /// </summary>
        public static void AL6_P3_7_CreateDir()
        {
            var newDir = Directory.CreateDirectory(@"C:\Users\user\Source\Repos\03-12-2018/A-4(6)-Files, Streams, Serialziation\Advence.Lesson 6\newTmpDir\");
            Console.WriteLine(newDir.CreationTime);
//            newDir.Delete();
        }


        /// <summary>
        /// AL6-P4/7-CopyFile. Скопировать первый файл из Program Files в новую папку.
        /// </summary>
        public static void AL6_P4_7_CopyFile()
        {
            var newDir = new DirectoryInfo(@"C:\Users\user\Source\Repos\03-12-2018/A-4(6)-Files, Streams, Serialziation\Advence.Lesson 6");
            var fileList = newDir.GetFiles("*.cs");
            fileList[0].CopyTo(@"C:\Users\user\Source\Repos\03-12-2018/A-4(6)-Files, Streams, Serialziation\Advence.Lesson 6\newTmpDir\" + fileList[0].Name);
        }

        /// <summary>
        /// AL6-P5/7-FileChat. Написать программу имитирующую чат. 
        /// Пускай в ней будут по очереди запрашивается реплики для User 1 и User 2 (используйте цикл из 5-10 итераций).  Сохраняйте данные реплики с ником пользователя и датой в файл на диске.
        /// </summary>
        public static void AL6_P5_7_FileChat()
        {
            string filePath = @"C:\Users\user\Source\Repos\03-12-2018\A-4(6)-Files, Streams, Serialziation\Advence.Lesson 6\newChat.txt";
            using (var fileAdapter = new StreamWriter(filePath, true))
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("user1: ");
                    fileAdapter.WriteLine($"[{DateTime.Now.ToString()}] User1: {Console.ReadLine()}");
                    Console.Write("user2: ");
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

           
        }

        /// <summary>
        /// AL6-P7/7-FileSrlz.
        /// Отредактировать предыдущий пример для поддержки сериализации и десериализации в файл.
        /// </summary>
        public static void AL6_P7_7_FileSrlz()
        {

        }

    }
}
