using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_complex_num_EXTRA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber c1 = new ComplexNumber(1, 2);
            ComplexNumber c2 = new ComplexNumber(3, -4);

            ComplexNumber sum = c1 + c2;
            Console.WriteLine($"Сумма: {sum}");

            ComplexNumber difference = c1 - c2;
            Console.WriteLine($"Разность: {difference}");

            ComplexNumber product = c1 * c2;
            Console.WriteLine($"Произведение: {product}");

            ComplexNumber quotient = c1 / c2;
            Console.WriteLine($"Деление: {quotient}");

        }

        public class ComplexNumber
        {
            private double real;
            private double imaginary;

            public ComplexNumber(double real, double imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
            {
                return new ComplexNumber(c1.real + c2.real, c1.imaginary + c2.imaginary);
            }

            public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
            {
                return new ComplexNumber(c1.real - c2.real, c1.imaginary - c2.imaginary);
            }

            public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
            {
                double newReal = c1.real * c2.real - c1.imaginary * c2.imaginary;
                double newImaginary = c1.real * c2.imaginary + c1.imaginary * c2.real;
                return new ComplexNumber(newReal, newImaginary);
            }

            public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
            {
                double denominator = c2.real * c2.real + c2.imaginary * c2.imaginary;

                if (denominator == 0)
                {
                    throw new DivideByZeroException("Деление на ноль невозможно");
                }

                double newReal = (c1.real * c2.real + c1.imaginary * c2.imaginary) / denominator;
                double newImaginary = (c1.imaginary * c2.real - c1.real * c2.imaginary) / denominator;
                return new ComplexNumber(newReal, newImaginary);
            }

            public override string ToString()
            {
                if (imaginary == 0)
                {
                    return real.ToString();
                }
                else if (imaginary > 0)
                {
                    return $"{real}+{imaginary}i";
                }
                else
                {
                    return $"{real}{imaginary}i";
                }
            }
        }

    }
}
