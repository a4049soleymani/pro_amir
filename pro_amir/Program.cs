using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace pro_amir
{
    class Program
    {
        static void Main(string[] args)
        {
            Drive_Selector();
            
        }
        //..........drive select......
        static void Drive_Selector()
        {
            Console.Clear();
            DriveInfo[] drivers = DriveInfo.GetDrives().Where(d => d.IsReady).ToArray();
            for (int i = 0; i < drivers.Length; i++)
            {
                // Console.WriteLine($"{i+1}.{drivers[i]}[{drivers[i].VolumeLabel}]");
                Console.WriteLine(+i + "." + drivers[i].Name);
                Console.WriteLine("  Drive type:  " + drivers[i].DriveType);
                if (drivers[i].IsReady == true)
                {
                    Console.WriteLine("  Volume label:  " + drivers[i].VolumeLabel);
                    Console.WriteLine("  File system:   " + drivers[i].DriveFormat);
                    Console.WriteLine("  Available space to current user:   " + drivers[i].AvailableFreeSpace + "byte");

                    Console.WriteLine("  Total available space:    " + drivers[i].TotalFreeSpace + "byte");

                    Console.WriteLine("  Total size of drive:   " + drivers[i].TotalSize + "byte");

                }
                Console.WriteLine("....................................");
            }
            Console.WriteLine("...............selected a drive via number");
            int y;
            String r;
            r = System.Console.ReadLine();
            y = Convert.ToInt32(r);
            switch(y)
            {
                case 0:
                DirectoryBrowzer("c:\\");
                break;
                case 1:
                DirectoryBrowzer("d:\\");
                break;
                case 2:
                DirectoryBrowzer("e:\\");
                break;
                case 3:
                DirectoryBrowzer("f:\\");
                break;
                case 4:
                DirectoryBrowzer("g:\\");
                break;
                default:
                break;
        }
            //............
        }
        //..........directory.......................
        static void DirectoryBrowzer(String path)
        {
            Console.Clear();
            DirectoryInfo di = new DirectoryInfo(path);

            // Get a reference to each directory in that directory.
            DirectoryInfo[] SubDirectory = di.GetDirectories();
            for (int i = 0; i < SubDirectory.Length;i++ )
            {
                Console.WriteLine(+i + "." + SubDirectory[i].Name + "     " + SubDirectory[i].LastWriteTime);

            }
            // select file...................
            FileInfo[] files = di.GetFiles();
            for (int i = 0; i < files.Length;i++ )
            {
                Console.WriteLine( + i + "." + files[i].Name);
            }
            Console.WriteLine("...........................................");
            Console.WriteLine("..........................select item number");
            var selectedItem = int.Parse(Console.ReadLine());
            // if selected number 50->return drivers
            if (selectedItem == 50)
            {
                if (di.Parent != null)
                {
                    DirectoryBrowzer(di.Parent.FullName);
                    Console.WriteLine(" if selected number 50->return ");
                }
                else
                    Drive_Selector();

            }
            else if (selectedItem <= SubDirectory.Length)
            {
                DirectoryBrowzer(SubDirectory[selectedItem].FullName);
            }
            else {
                var filepath = files[selectedItem - SubDirectory.Length].FullName;
                Process.Start(filepath);
               
                DirectoryBrowzer(di.FullName);
            }
        
        }
        //............
    }
}
