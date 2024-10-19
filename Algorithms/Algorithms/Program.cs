using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Program
    {

        
        public static void Main(string[] args)
        {
            //*====================وضع عناصر عشوائية و طول عشوائي بين 25 و 75====================*
            Random random = new Random();
            int[] ints = new int[random.Next(25, 76)];
            int[] ints2 = new int[ints.Length];
            int cnt = 0;
            Random rnd = new Random();
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = rnd.Next(25,76);
                ints2[i] = ints[i];
            }


            //*====================الطريقة العودية====================*
            SortArray(ints);
            Duplicate(ints, 0);
            Console.WriteLine();
            //*====================الطريقة التكرارية====================*
            iterative(ints2);
        }
        //*====================ميثودات الطريقة العودية====================*
        public static void SortArray(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                for (int j = 0; j < ints.Length; j++)
                {
                    if (ints[i] < ints[j])
                    {
                        ints[i] *= ints[j]; ints[j] = ints[i] / ints[j]; ints[i] /= ints[j];
                    }
                }
            }
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i] + "\t");
            }
            Console.WriteLine();
        }
        //*====================حساب التكرارات====================*
        static void Duplicate(int[] ints, int currentIndex)
        {
            if (currentIndex >= ints.Length)
            {
                return;
            }

            int cnt = CountDuplicates(ints, ints[currentIndex], currentIndex + 1, 1);

            if (ints[currentIndex] != -1)
            {
                Console.WriteLine("the number " + ints[currentIndex] + " repeated " + cnt + " times");
            }

            Duplicate(ints, currentIndex + 1);
        }
        //*====================حساب عدد مرات تكرار عنصر معين====================*
        static int CountDuplicates(int[] ints, int number, int currentIndex, int count)
        {
            if (currentIndex >= ints.Length)
            {
                return count;
            }

            if (ints[currentIndex] == number)
            {
                ints[currentIndex] = -1;
                return CountDuplicates(ints, number, currentIndex + 1, count + 1);
            }

            return CountDuplicates(ints, number, currentIndex + 1, count);
        }
        //*====================ميثود الطريقة التكرارية====================*
        public static void iterative(int[] ints)
        {
            int  cnt = 1;
            for (int i = 0; i < ints.Length; i++)
            {
                for (int j = 0; j < ints.Length; j++)
                {
                    if (ints[i] < ints[j])
                    {
                        ints[i] *= ints[j]; ints[j] = ints[i] / ints[j]; ints[i] /= ints[j];
                    }
                }
            }
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i] + "\t");
            }
            Console.WriteLine();
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] == -1) { continue; }
                for (int j = i + 1; j < ints.Length; j++)
                {
                    if (ints[i] == ints[j])
                    {
                        cnt++;
                        ints[j] = -1;
                    }
                }
                Console.WriteLine("the number " + ints[i] + " repeated " + cnt + " times");
                cnt = 1;
            }
        }
    }
}
