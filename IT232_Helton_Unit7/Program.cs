using System;
using System.IO;

namespace IT232_Helton_Unit7
{
    class Program
    {
        public static void divideByZero()
        {
            int num1 = 15;
            int num2 = 0;
            int sum = num1 / num2;
        }
        public static void FileDoesNotExist()
        {
            int lineCounter = 0;
            string line;
            using (StreamReader file = new StreamReader("NoFileNamedThis.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    lineCounter++;
                }
            }
        }
        public static void arrayOutOfBounds()
        {
            string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };
            for (int i = 0; i <= names.Length; i++)
            {
                string SomeName = names[i];
            }
        }
        public static void arrayIsNull()
        {
            string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };
            names = null;
            string SomeName = names[2];
        }
        static string logFileName;
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 7 - Logging excepetions to a file.");
            Console.WriteLine("");
            Console.WriteLine("Testing Try/Catch for Divide by Zero, File does not exist, Array Out of Bounds, and Array is Null Scenario");
            Console.WriteLine("All further console error messages are printed from error log file");

            logFileName = @"log.txt";
            TextWriter errStream = new StreamWriter(logFileName);

            Console.SetError(errStream);

            try
            {
                divideByZero();
            }
            catch (Exception e)
            {
                string err = e.Message.ToString();
                Console.Error.WriteLine(err);
            }
            try
            {
                FileDoesNotExist();
            }
            catch (Exception  e)
            {
                string err = e.Message.ToString();
                Console.Error.WriteLine(err);
            }
            try
            {
                arrayOutOfBounds();
            }
            catch (Exception e)
            {
                string err = e.Message.ToString();
                Console.Error.WriteLine(err);
            }
            try
            {
                arrayIsNull();
            }
            catch (Exception e)
            {
                string err = e.Message.ToString();
                Console.Error.WriteLine(err);
            }
            DisplayLogFile(logFileName);
            Console.ReadLine();

        }
        public static void DisplayLogFile(string logFileName)
        {
            Console.Error.Close();
            string path = (logFileName);
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader streamReader = new StreamReader(fileStream))
            {
                while (streamReader.EndOfStream == false)
                {
                    Console.WriteLine(streamReader.ReadLine());
                }
            }
        }
    }
}
