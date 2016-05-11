using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;

namespace Convertor_MS0_to_TXT
{
    class Program
    {
        //public static object MessageBox { get; private set; }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n=[ Convertor MS0 to TXT ]====[ 2016 Zemlyakov Jurij (LodestaRgr@yandex.ru) ]==\n");

            if (args.Length == 2)
            {
                //Console.WriteLine("Arguments: " + string.Join(",", args));
                string in_name = args[0];
                string out_name = args[1];

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

                    Console.Write("\n\n==============================================================================");

                    string buf = reader.ReadLine();                 //Считывает первую строку
                    string k = ((char) reader.Peek()).ToString();   //Запоминает первый символ следующей строки

                    while (!reader.EndOfStream)                     //Запуск процесса конвертации
                    {
                        Console.SetCursorPosition(cx, cy);          //ставит курсор на позицию
                        Console.Write(i);                           //пишет номер обрабатываемой строки

                        buf = reader.ReadLine();                    //считывает строку

                        if (buf[0].ToString() == k)                 //если строка начинается с символа к
                        {
							if (buf.Length == 978 || buf.Length == 1022)
							{
								writer.Write(buf);
							}
							else
							{
								if (buf.Length < 978)				//если строка меньше формата (MS0 - 012xxx.ms0)
								{
									writer.Write(String.Format("{0,-978}", buf));	//добавить пробелы до 978
								}
								else								//если строка меньше формата (000 - 120xxx.ms0)
								{
									writer.Write(String.Format("{0,-1022}", buf));	//добавить пробелы до 1022
								}
							}
							j = false;
                        }
                        else
                        {
                            if (!j)
                            {
//								if (buf.Length == 222)
//								{
                                	writer.Write(buf + "\n");
//								}
//								else								//если строка меньше формата
//								{
//									writer.Write(String.Format("{0,-222}", buf));	//добавить пробелы до 222
//									writer.Write("\n");
//								}
                                j = true;
                            }

                        }
                        //System.Threading.Thread.Sleep(10);        //пауза 10мс
                        i++;
                    }

                    Console.WriteLine("\n\n=[ Process is finished! ]");

                    writer.Close();
                    reader.Close();
                }
                else
                    Console.WriteLine("  File PFR base (MS0) - not exists.");

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
