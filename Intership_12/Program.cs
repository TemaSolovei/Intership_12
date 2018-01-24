using System;
using System.Threading;

namespace Intership_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice, size;
            int[] mas1, mas2, mas3; // Три массива
            bool ok; // ok — проверка на принадлежность типу

            do
            {
                Console.Write("Каким образом будем задавать входные данные? \n 1. Ввод вручную  \n 2. Случайно сгенерированные массивы\n Введите номер выбранного варианта: ");
                ok = int.TryParse(Console.ReadLine(), out choice);
                if ((!ok) || (1 > choice) || (2 < choice)) Console.WriteLine("Введите 1 или 2!");
            } while ((!ok) || (1 > choice) || (2 < choice));

            do
            {
                Console.Write("Введите размер массива: ");
                ok = int.TryParse(Console.ReadLine(), out size);
                if ((!ok) || (size < 1)) Console.WriteLine("Ошибка! Введите целое число больше нуля!");
            } while ((!ok) || (size < 1));


            mas1 = new int[size];
            mas2 = new int[size];
            mas3 = new int[size];

            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Введите первый массив - упорядоченный по возрастанию: ");
                    
                    mas1[0] = checkInt("Введите 1 элемент: ");
                    Console.WriteLine();

                    for (int i = 1; i < size; i++)
                    {                     
                        do
                        {
                            Console.Write("Введите {0} элемент:", i + 1);

                            mas1[i] = checkInt(" ");
                            Console.WriteLine();

                            if (mas1[i] < mas1[i - 1]) Console.WriteLine("Ошибка! Следующий элемент должен быть больше предыдущего!");
                        } while (mas1[i] < mas1[i-1]);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Введите второй массив - упорядоченный по убыванию: ");

                    mas2[0] = checkInt("Введите 1 элемент: ");
                    Console.WriteLine();

                    for (int i = 1; i < size; i++)
                    {
                        do
                        {
                            Console.Write("Введите {0} элемент:", i + 1);

                            mas2[i] = checkInt(" ");
                            Console.WriteLine();

                            if (mas2[i] > mas2[i - 1]) Console.WriteLine("Ошибка! Следующий элемент должен быть меньше предыдущего!");
                        } while (mas2[i] > mas2[i - 1]);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Введите третий массив - неупорядоченный: ");

                    for (int i = 0; i < size; i++)
                    {
                        
                        Console.Write("Введите {0} элемент:", i + 1);

                        mas3[i] = checkInt(" ");
                        Console.WriteLine();
                    }

                    Console.WriteLine("\nНа данный момент массивы выглядят так:\n");
                    writeMas(mas1, "Возрастающий массив");
                    writeMas(mas2, "Убывающий массив");
                    writeMas(mas3, "Неотсортированный массив");

                    int firstCountSelect1 = 0, firstCountSelect2 = 0, firstCountSelect3 = 0, firstCountCount1 = 0, firstCountCount2 = 0, firstCountCount3 = 0; // Подсчёт количества пересылок

                    int[] mas1Select = selection(mas1, ref firstCountSelect1);
                    int[] mas2Select = selection(mas2, ref firstCountSelect2);
                    int[] mas3Select = selection(mas3, ref firstCountSelect3);
                    int[] mas1Count = counting(mas1, ref firstCountCount1);
                    int[] mas2Count = counting(mas2, ref firstCountCount2);
                    int[] mas3Count = counting(mas3, ref firstCountCount3);


                    Console.WriteLine("После сортировки массивы выглядят следующим образом:\n");

                    Console.WriteLine("Сортировка методом простого выбора:\n");

                    writeMas(mas1Select, "");
                    Console.WriteLine("Количество пересылок - {0}", firstCountSelect1);

                    writeMas(mas2Select, "");
                    Console.WriteLine("Количество пересылок - {0}", firstCountSelect2);

                    writeMas(mas3Select, "");
                    Console.WriteLine("Количество пересылок - {0}", firstCountSelect3);


                    Console.WriteLine("\nСортировка методом подсчёта:\n");

                    writeMas(mas1Count, "");
                    Console.WriteLine("Количество пересылок - {0}", firstCountCount1);

                    writeMas(mas2Count, "");
                    Console.WriteLine("Количество пересылок - {0}", firstCountCount2);

                    writeMas(mas3Count, "");
                    Console.WriteLine("Количество пересылок - {0}", firstCountCount3); ;


                    Console.ReadLine();
                    break;

                case 2:
                    Random rand = new Random();

                    mas1[0] = rand.Next(0, 201);
                    Thread.Sleep(20);

                    for (int i = 1; i < size; i++)
                    {
                        do
                        {
                            int left = mas1[i - 1];
                            mas1[i] = rand.Next(left, 201);
                            Thread.Sleep(20);

                        } while (mas1[i] < mas1[i - 1]);
                    }

                    mas2[0] = rand.Next(0, 201);
                    Thread.Sleep(20);

                    for (int i = 1; i < size; i++)
                    {
                        do
                        {
                            int right = (int)mas2[i - 1];
                            mas2[i] = rand.Next(0, right);
                            Thread.Sleep(20);

                        } while (mas2[i] > mas2[i - 1]);
                    }

                    for (int i = 0; i < size; i++)
                    {
                        mas3[i] = rand.Next(0, 201);
                        Thread.Sleep(20);
                    }

                    Console.WriteLine("\nНа данный момент массивы выглядят так:\n");
                    writeMas(mas1, "Возрастающий массив");
                    writeMas(mas2, "Убывающий массив");
                    writeMas(mas3, "Неотсортированный массив");

                    int secondCountSelect1 = 0, secondCountSelect2 = 0, secondCountSelect3 = 0, secondCountCount1 = 0, secondCountCount2 = 0, secondCountCount3 = 0; // Подсчёт количества пересылок

                    int[] secondMas1Select = selection(mas1, ref secondCountSelect1);
                    int[] secondMas2Select = selection(mas2, ref secondCountSelect2);
                    int[] secondMas3Select = selection(mas3, ref secondCountSelect3);
                    int[] secondMas1Count = counting(mas1, ref secondCountCount1);
                    int[] secondMas2Count = counting(mas2, ref secondCountCount2);
                    int[] secondMas3Count = counting(mas3, ref secondCountCount3);


                    Console.WriteLine("После сортировки массивы выглядят следующим образом:\n");

                    Console.WriteLine("Сортировка методом простого выбора:\n");

                    writeMas(secondMas1Select, "");
                    Console.WriteLine("Количество пересылок - {0}", secondCountSelect1);

                    writeMas(secondMas2Select, "");
                    Console.WriteLine("Количество пересылок - {0}", secondCountSelect2);

                    writeMas(secondMas3Select, "");
                    Console.WriteLine("Количество пересылок - {0}", secondCountSelect3);


                    Console.WriteLine("\nСортировка методом подсчёта:\n");

                    writeMas(secondMas1Count, "");
                    Console.WriteLine("Количество пересылок - {0}", secondCountCount1);

                    writeMas(secondMas2Count, "");
                    Console.WriteLine("Количество пересылок - {0}", secondCountCount2);

                    writeMas(secondMas3Count, "");
                    Console.WriteLine("Количество пересылок - {0}", secondCountCount3); ;


                    Console.ReadLine();

                    break;

                default: Console.WriteLine("Ошибка! Введен неправильный пункт меню");
                    break;
            }
        }

        static void writeMas(int[] mas, string message)
        {
            Console.WriteLine(message);

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }

            Console.WriteLine();
        }

        static int[] selection(int[] mas, ref int count)
        {
            count = 0; // Подсчёт количества пересылок

            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[min] > mas[j])
                    {
                        min = j;
                    }
                }

                int temp = mas[i];
                mas[i] = mas[min];
                mas[min] = temp;
                count++;
            }

            return mas;
        }


        static int[] counting(int[] mas, ref int count)
        {
            int index, resultIndex = 0, max = mas[0]; // Значение элемента вспомогательного массива, индекс результирующего массива, максимальный элемент
            int[] help; // Вспомогательный массив
            int[] result = new int[mas.Length]; // Результирующий массив
            count = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                if (max < mas[i]) max = mas[i];
            }

            help = new int[max+1];

            for (int i = 0; i < mas.Length; i++)
            {

                help[mas[i]]++; // Подсчитываем количество переменных определённого размера
            }

            for (int i = 0; i < help.Length; i++)
            {
                index = help[i];

                while (index > 0)
                {
                    result[resultIndex] = i;
                    resultIndex++;
                    count++;
                    index--;
                }
            }

            return result;
        }

        static int checkInt(string message)
        {
            int result; // result - проверенная переменная
            bool ok; // Проверка ввода

            do
            {
                Console.Write(message);
                ok = int.TryParse(Console.ReadLine(), out result);
                if (!ok) Console.WriteLine("Ошибка! Введите целое число!");
                if (result < 0) Console.WriteLine("Введите целое число, больше или равное нулю!");
            } while ((!ok) || (result < 0));

            return result;
        }
    }
}
