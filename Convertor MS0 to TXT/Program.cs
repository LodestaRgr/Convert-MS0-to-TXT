﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        public static object MessageBox { get; private set; }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n=[ Convertor MS0 to TXT ]====[ 2016 Zemlyakov Jurij (LodestaRgr@yandex.ru) ]==\n");

            if (args.Length == 2)
            {
                //Console.WriteLine("Arguments: " + string.Join(",", args));
                var in_name = args[0];
                var out_name = args[1];

                if (File.Exists(in_name))
                {
                    long in_count = System.IO.File.ReadAllLines(in_name).Length;
                    long i = 1;
                    bool j = false;

                    //открывает файл для чтения
                    FileStream in_file = new FileStream(in_name, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(in_file, Encoding.Default);

                    //открывает файл для записи
                    FileStream out_file = new FileStream(out_name, FileMode.Create);
                    StreamWriter writer = new StreamWriter(out_file, Encoding.Default);

                    Console.Write("  PFR base : \t" + in_name + "\n\n" +
                                  "  Total lines: \t" + in_count + "\n" +
                                  "  Convert: \t");

                    //последняя позиция курсора
                    int cx = Console.CursorLeft;
                    int cy = Console.CursorTop;

                    string buf = "";
                    //считывает первую строку
                    buf = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        Console.SetCursorPosition(cx, cy);
                        Console.Write(i);

                        buf = reader.ReadLine();

                        if (Convert.ToString(buf[0]) == "О")
                        {
                            writer.Write(buf);
                            j = false;
                        }
                        else
                        {
                            if (!j)
                            {
                                writer.Write(buf + "\n");
                                j = true;
                            }
                        }
                        //System.Threading.Thread.Sleep(10);

                        i++;
                    }

                    writer.Close();
                    reader.Close();
                }
                else
                    Console.WriteLine("  File PFR base - not exists.");

            }
            else
                Console.WriteLine("  Usege:\tms0_to_txt.exe [MS0 file] [out txt file]\n\n" +
                                  "\t\tMS0 file - this PFR base file (format MS0)\n" +
                                  "\t\tTXT file - this output file after convert\n\n" +
                                  "  Example:\tms0_to_txt.exe PFR12_O.MS0 PFR12_O.txt");

            //Console.ReadLine();
        }
    }
}
