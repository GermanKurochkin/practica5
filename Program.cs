using System;

namespace practica5
{
    class Program
    {
        const int min = 10;
        const int max = 100;
        static int maxNum=0;
        static bool RandomOrNot()
        {
            int randomOrNot;   
            string input;       
            bool ok, random;
            do
            {
                Console.WriteLine($"1.Использовать рандомные числа от {min} до {max}");
                Console.WriteLine($"2.Ввести числа самостоятельно");
                input = Console.ReadLine();
                ok = int.TryParse(input, out randomOrNot);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (randomOrNot < 1 || randomOrNot > 2) Console.WriteLine("Некорректный ввод.Введите число из меню(1 или 2)");
            } while (!ok || randomOrNot < 1 || randomOrNot > 2);
            if (randomOrNot == 1) random = true;
            else random = false;
            return random;
        }
        static void MakeMatrWrite(int size, ref int[,] mas)
        {
            mas = new int[size,size];
            int element;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    element = InputElement($"Bведите элемент массива строки №{i + 1}, столбца №{j + 1}; от {min} до {max}");
                    mas[i, j] = element;
                }
        }
        static void MakeMatrRandom(int size, ref int[,] mas)
        {
            mas = new int[size, size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    mas[i, j] = rand.Next(90) + 10;
        }
        static void WriteMatr(int[,] masTwo)
        {

            Console.WriteLine("Полученный матрица:");
            for (int i = 0; i < masTwo.GetLength(0); i++)
            {
                for (int j = 0; j < masTwo.GetLength(1); j++)
                {
                    if (j >= i && masTwo.GetLength(0) - j >= i+1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{masTwo[i, j]} ");
                        Console.ResetColor();
                    }
                    else Console.Write($"{masTwo[i, j]} ");
                }
                Console.WriteLine();
            }
        
        }
        static void WriteMatrWithMax(int[,] masTwo)
        {

     
            for (int i = 0; i < masTwo.GetLength(0); i++)
            {
                for (int j = 0; j < masTwo.GetLength(1); j++)
                {
                    if (j >= i && masTwo.GetLength(0) - j >= i + 1)
                    {
                        if(masTwo[i, j]==maxNum)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{masTwo[i, j]} ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{masTwo[i, j]} ");
                            Console.ResetColor();
                        }
                    }
                    else Console.Write($"{masTwo[i, j]} ");
                }
                Console.WriteLine();
            }

        }
        static int InputSize(string output)
        {
            int size;         
            bool ok;           
            string input;      
            do
            {
                Console.WriteLine(output);
                input = Console.ReadLine();
                ok = int.TryParse(input, out size);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (size < 1 || size > 20) Console.WriteLine("Некорректный ввод.Введите число от 1 до 20");
            } while (!ok || size < 1 || size > 20);
            return size;
        }
        static int InputElement(string output)
        {
            int element;      
            bool ok;           
            string input;      

            do
            {
                Console.WriteLine(output);
                input = Console.ReadLine();
                ok = int.TryParse(input, out element);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (element < min || element > max) Console.WriteLine("Некорректный ввод.Введите число от {min} до {max}");
            } while (!ok || element < min || element > max);
            return element;
        }
        static void FindMax( int[,] masTwo)
        {
            for (int i = 0; i < masTwo.GetLength(0); i++)
            {
                for (int j = 0; j < masTwo.GetLength(1); j++)
                {
                    if (j >= i && masTwo.GetLength(0) - j >= i + 1)
                    {
                        if(maxNum<masTwo[i,j])
                        {
                            maxNum = masTwo[i, j];
                        }
                    }
                }
             
            }
        }
        static void Main(string[] args)
        {
            bool random = RandomOrNot();
            int[,] matr = new int[1,1];
            int size = InputSize("Введите размер квадратной матрицы");
            if (random) MakeMatrRandom(size, ref matr);
            else MakeMatrWrite(size, ref matr);
            WriteMatr(matr);
            FindMax(matr);
            Console.WriteLine();
            Console.WriteLine("Максимум выведен красным цветом:");
            WriteMatrWithMax(matr);

        }
    }
}
