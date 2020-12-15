using System;
using System.Collections.Generic;
using System.Drawing;
using Library;

namespace lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var vectors = new List<MyVector>();
            PrintHelp();
            while (ReadCommands(ref vectors)) ;
        }

        private static bool ReadCommands(ref List<MyVector> vectors)
        {
            string buf;
            string[] command;
            try
            {
                buf = Console.ReadLine();
                command = buf.Split(' ');
                switch (command[0].ToLower())
                {
                    case "stop":
                        return false;

                    case "new":
                        AddNewVector(ref vectors, command);
                        break;

                    case "sum":
                        vectors.Add(vectors[Convert.ToInt32(command[1])] + vectors[Convert.ToInt32(command[2])]);
                        break;

                    case "mul":
                        vectors.Add(vectors[Convert.ToInt32(command[1])] * Convert.ToSingle(command[2]));
                        break;

                    case "dif":
                        vectors.Add(vectors[Convert.ToInt32(command[1])] - vectors[Convert.ToInt32(command[2])]);
                        break;

                    case "print":
                        PrintVectors(ref vectors);
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    default:
                        Console.WriteLine("Команда не найдена\n");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Комманда некорректна:{e?.Message}");
            }
            return true;
        }

        static void PrintVectors(ref List<MyVector> strings)
        {
            for (int i = 0; i < strings.Count; i++)
            {
                Console.WriteLine($"Vector №{i}\n{strings[i]}");
                Console.WriteLine("---------------------------------");
            }
        }

        static void AddNewVector(ref List<MyVector> strings, string[] command)
        {
            if (command.Length > 3)
            {
                var start = new PointF(Convert.ToSingle(command[1]), Convert.ToSingle(command[2]));
                var end = new PointF(Convert.ToSingle(command[3]), Convert.ToSingle(command[4]));
                strings.Add(new MyVector(start,end));
            }
            else if(command.Length == 3)
            {
                var end = new PointF(Convert.ToSingle(command[1]), Convert.ToSingle(command[2]));
                strings.Add(new MyVector(end));
            }
            else
            {
                throw new ArgumentException("Wrong count of arguments");
            }

        }
        static void PrintHelp()
        {
            Console.WriteLine("Список комманд:\n" +
                "new X Y -  добавить вектор с началом в (0,0) и концом в (X,Y)\n" +
                "new X0 Y0 X1 Y1 -  добавить вектор с началом в (X0,Y0) и концом в (X1,Y1)\n" +
                "sum vect1 vect2 - осуществляет суммирование vect1 и vect2\n" +
                "dif vect1 vect2 - осуществляет вычитание vect2 из vect1\n" +
                "mul vect int - умножаем вектор vect на число int\n" +
                "print - печатает все векторы\n" +
                "help - печатает списко всех комманд\n" +
                "stop - заканичвает работу програмыы");
        }
    }
}
