using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace DirectoryCountTask
{
    class Program
    {
        /// <summary>
        /// Class for count and total_size variable
        /// </summary>
        public class CountAndSize
        {
            public int count;
            public double total_size;
        }
        static void Main(string[] args)
        {
            
            string directoryPath; 
            long size = 0;

            
            directoryPath = Console.ReadLine(); //Read the user input

            Console.WriteLine("Directory Path: " + @directoryPath); // Display user input

            int files = System.IO.Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories).Count(); // Get count of all files in the directory and subdirectory

            var dirInfo = new DirectoryInfo(directoryPath); //Initialization of Directory Info

            //Iterate through files and add all file size
            foreach (FileInfo fi in dirInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }

            //Initialization of the result object
            var resultObj = new CountAndSize
            {
                count = files,
                total_size = ((size / 1024f) / 1024f) //converting bytes to megabytes
            };

            var jsonResult = new JavaScriptSerializer().Serialize(resultObj); //convert object to json

            Console.WriteLine(jsonResult); //display json output

            Console.ReadKey();
        }
    }
}
