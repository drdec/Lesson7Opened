// Decompiled with JetBrains decompiler
// Type: Laba5.Program
// Assembly: ConsoleApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7BF0C4F9-E408-40BC-9041-A325B477CE61
// Assembly location: C:\Projects Vs\ConsoleApp1\bin\Debug\net6.0\ConsoleApp1.dll

using System;


#nullable enable
namespace Laba5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double a = 0.6;
            double b = 1.724;
            double h = 1E-07;
            double n = (b - a) / h;
            Console.WriteLine("n = " + n.ToString());
            Console.WriteLine("Метод трапеции - " + Program.TrapezoidMethod(a, b, h, n).ToString());
            Console.WriteLine("Метод Симсона - " + Program.SimsonsMethod(a, b, h, n).ToString());
            Console.WriteLine("Кубаторный метод Симпсона - " + Program.MethodOfCubeSimpson().ToString());
        }

        private static double GetFunction(double x) => Math.Pow(x + Math.Pow(x, 3.0), 0.5);

        private static double GetFunction(double x, double y) => Math.Pow(x, 2.0) + 2.0 * y;

        private static double TrapezoidMethod(double a, double b, double h, double n)
        {
            double num = h * (Program.GetFunction(a) + Program.GetFunction(b)) / 2.0;
            for (int index = 1; (double)index <= n - 1.0; ++index)
                num += h * Program.GetFunction(a + h * (double)index);
            return num;
        }

        private static double SimsonsMethod(double a, double b, double h, double n)
        {
            double num = h * (Program.GetFunction(a) + Program.GetFunction(b)) / 6.0;
            for (int index = 1; (double)index <= n; ++index)
                num += 2.0 / 3.0 * h * Program.GetFunction(a + h * ((double)index - 0.5));
            for (int index = 1; (double)index <= n - 1.0; ++index)
                num += 1.0 / 3.0 * h * Program.GetFunction(a + h * (double)index);
            return num;
        }

        private static double MethodOfCubeSimpson()
        {
            double num1 = 0.0;
            double num2 = 2.0;
            double num3 = 0.0;
            double num4 = 1.0;
            int num5 = 2;
            int num6 = 2 * num5;
            double num7 = (num2 - num1) / (double)(2 * num6);
            double num8 = (num4 - num3) / (double)num6;
            double num9 = 0.0;
            double num10 = 0.0;
            double num11 = num1;
            double num12 = num3;
            double[] numArray1 = new double[2 * num6 + 1];
            numArray1[0] = num11;
            for (int index = 1; index <= 2 * num6; ++index)
                numArray1[index] = numArray1[index - 1] + num7;
            double[] numArray2 = new double[2 * num5 + 1];
            numArray2[0] = num12;
            for (int index = 1; index <= 2 * num5; ++index)
                numArray2[index] = numArray2[index - 1] + num8;
            for (int index1 = 0; index1 < num6; ++index1)
            {
                for (int index2 = 0; index2 < num5; ++index2)
                    num10 = num10 + Program.GetFunction(numArray1[2 * index1], numArray2[2 * index2]) + 4.0 * Program.GetFunction(numArray1[2 * index1 + 1], numArray2[2 * index2]) + Program.GetFunction(numArray1[2 * index1 + 2], numArray2[2 * index2]) + 4.0 * Program.GetFunction(numArray1[2 * index1], numArray2[2 * index2 + 1]) + 16.0 * Program.GetFunction(numArray1[2 * index1 + 1], numArray2[2 * index2 + 1]) + 4.0 * Program.GetFunction(numArray1[2 * index1 + 2], numArray2[2 * index2 + 1]) + Program.GetFunction(numArray1[2 * index1], numArray2[2 * index2 + 2]) + 4.0 * Program.GetFunction(numArray1[2 * index1 + 1], numArray2[2 * index2 + 2]) + Program.GetFunction(numArray1[2 * index1 + 2], numArray2[2 * index2 + 2]);
            }
            return (num9 + num10) * (num7 * num8 / 9.0);
        }
    }
}
