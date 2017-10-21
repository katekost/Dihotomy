using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dihotomia
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.25;
            double b = 1;
            Threading();
            Dihotomia(a, b);
            Console.WriteLine("Для виходу з програми натиснiть будь-яку клавiшу...");
            Console.ReadLine();
        }
       
        static void Dihotomia(double a, double b)
        {
            double fc, c, faa, fbb;
            double e = 0.1;
            c = FPartOfFunc(a, b) + SPartOfFunc(a, b);
            fc = FDerivativeFunc(c);
            faa = FDerivativeFunc(a);
            fbb = FDerivativeFunc(b);
            if ((b - a) < e)
            {
                c = Math.Round(c, 1);
                Console.WriteLine(c + " - критична точка" + '\n');
                Console.WriteLine("Значення другоi похiдноi f(" + c + ") = " + SDerivativeFunc(c) + '\n');
                if (c > 0)
                {
                    Console.WriteLine("Це точка min функцii, оскiльки " + SDerivativeFunc(c) + " > 0" + '\n');
                }
                else
                    Console.WriteLine("Це точка max функцii, оскiльки " + SDerivativeFunc(c) + " < 0" + '\n');
            }
            else
                if (fc * faa < 0)
                {
                    Console.WriteLine("Екстремум на вiдрiзку [" + a + "; " + c + "]" + '\n');

                    b = c;
                    Dihotomia(a, b);
                }

                else
                    if (fc * fbb < 0)
                    {
                        Console.WriteLine("Екстремум на вiдрiзку [" + c + "; " + b + "]" + '\n');
                        a = c;
                        Dihotomia(a, b);
                    }
        }
      
        static void LineSeg()
        {
            double a = 0.25;
            double b = 1;
            double fa, fb;
            Console.WriteLine("Вiдрiзок на якому шукаємо: [" + a + "; " + b + "]" + '\n');
            fa = FDerivativeFunc(a);
            fb = FDerivativeFunc(b);
            Console.WriteLine("f(" + a + ") = " + fa + "   f(" + b + ") = " + fb + '\n');
            if (fa * fb < 0)
                Console.WriteLine("Екстремуми функцii iснують, оскiльки значення функцii на кiнцях вiдрiзка мають рiзнi знаки." + '\n');
        }

        static void Threading()
        {
            Thread LineSegThread = new Thread(LineSeg);
            LineSegThread.Start();
        }

        static double FDerivativeFunc(double x)
        {
            return  4 * x - 1 / x;
        }

        static double SDerivativeFunc(double x)
        {
            return 4 + (1 / (x * x));
        }

        static double FPartOfFunc(double a, double b)
        {
            return (a + b) / 2;
        }

        static double SPartOfFunc(double a, double b)
        {
            double k = 0.1;
            return k * (b - a) / 2;
        }
    }
}


