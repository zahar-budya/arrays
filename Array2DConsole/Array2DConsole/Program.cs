using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2DConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = Convert.ToInt32(Console.ReadLine());
            int number2 = Convert.ToInt32(Console.ReadLine());
            double[,] arr = new double[number1, number2];

            Random r = new Random();
            for (int i = 0; i < number1; i++)
            {
                for (int j = 0; j < number2; j++)
                {
                    arr[i, j] = (double)r.Next(-278, 784) / 10;
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine();
            }

            int counter = 0;
            for(int i = 0; i < number1; i++)
            {
                bool check = true;
                for (int j = 0; j < number2; j++)
                {
                    if(arr[i, j] > 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check) counter++;
            }
            
            Console.WriteLine("\nКількість рядків без додатніх елементів: {0}", counter);

            double temp;
            for (int i = 0; i < arr.GetLength(1) - 1; i++)
            {
                bool f = false;
                for (int j = 0; j < arr.GetLength(1) - i - 1; j++)
                {
                    double[] sum = {0,0};
                    for (int k = 0; k < arr.GetLength(0); k++) {
                        sum[0] += arr[k, j] > 0 ? arr[k, j] : 0;
                        sum[1] += arr[k, j + 1] > 0 ? arr[k, j + 1] : 0;
                    }

                    if (sum[1] > sum[0])
                    {
                        f = true;
                        for (int k = 0; k < arr.GetLength(0); k++)
                        {
                            temp = arr[k, j + 1];
                            arr[k, j + 1] = arr[k, j];
                            arr[k, j] = temp;
                        }
                    }
                }
                if (!f) break;
            }

            for (int i = 0; i < number1; i++)
            {
                for (int j = 0; j < number2; j++)
                {
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
