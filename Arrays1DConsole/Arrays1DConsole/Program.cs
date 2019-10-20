using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays1DConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            double[] arr = new double[number];

            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr.SetValue((double)r.Next(-11034,11035)/100, i);
                Console.Write("{0}\t", arr[i]);
            }

            Array.Sort(arr, 0, Array.IndexOf(arr, arr.Min()));
            Console.WriteLine("\n\nВпорядковані елементи до мiнімального:");
            foreach (double el in arr)
                Console.Write("{0}\t",el);

            Array.Sort(arr);
            double suma = arr.Max() + arr.Min();

            Console.WriteLine("\n\nСума максимального і мінімального елемента: {0}", suma);
        }
    }
}
