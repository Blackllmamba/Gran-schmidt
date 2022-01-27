using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gram_Schmidt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число векторов = ");
            int countVektor = Convert.ToInt32(Console.ReadLine());
            double[][] start = new double[countVektor][];
            for (int i = 0; i < countVektor; i++)
                start[i] = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray(); ;
            double[] vek;

            ArrayList ortanalizVectors = new ArrayList();

            foreach (double[] startVector in start)
            {
                vek = OrtVek(startVector, ortanalizVectors);
                if (Proverka(vek))
                {
                    Console.WriteLine("Векторы линейно зависимые");
                    break;
                }
                ortanalizVectors.Add(vek);
            }
            if (ortanalizVectors.Count == start.Length)
            {
                foreach (double[] item in ortanalizVectors)
                {
                    foreach (double num in item)
                    {
                        Console.Write($"{num} ");
                    }
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();

        }
        public static bool Proverka(double[] vek)
        {
            foreach (var item in vek)
            {
                if (item != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static double[] OrtVek(double[] start, ArrayList ortanaliz)
        {
            double scal;
            double[] OrtVek = start;
            foreach (double[] item in ortanaliz)
            {
                scal = Scal(item, start);
                for (int i = 0; i < start.Length; i++)
                {
                    OrtVek[i] -= scal * item[i];
                }
            }
            for (int i = 0; i < OrtVek.Length; i++)
            {
                OrtVek[i] = Math.Round(OrtVek[i], 7);
            }
            if (Proverka(OrtVek))
            {
                return OrtVek;
            }
            OrtVek = Norm(OrtVek);
            return OrtVek;
        }
        public static double Scal(double[] mas1, double[] mas2)
        {
            double scal = 0;
            for (int i = 0; i < mas1.Length; i++)
            {
                scal += mas1[i] * mas2[i];
            }
            return scal;
        }
        public static double[] Norm(double[] ort)
        {
            double[] norm = new double[ort.Length];
            double sum = 0;
            foreach (var item in ort)
            {
                sum += item * item;
            }
            for (int i = 0; i < ort.Length; i++)
            {
                norm[i] = Math.Round(ort[i] / Math.Sqrt(sum), 8);
            }
            return norm;
        }
    }
}
