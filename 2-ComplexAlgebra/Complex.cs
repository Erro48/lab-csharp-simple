using System;
using System.Collections.Generic;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// 
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public double Modulus
        {
            get => Math.Sqrt((Real * Real) + (Imaginary * Imaginary));
        }

        public double Phase
        {
            get => Math.Atan2(Imaginary, Real);
        }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex number) => new Complex(Real + number.Real, Imaginary + number.Imaginary);

        public Complex Minus(Complex number) => Plus(new Complex(-number.Real, -number.Imaginary));

        public string ToString()
        {
            string result = Real != 0 ? Real.ToString() : "";
            if (Imaginary != 0)
            {
                string sign = Imaginary > 0 ? "+" : "-";
                string immS = Imaginary > 1 ? Math.Abs(Imaginary).ToString() : "";
                result += sign + immS + "i";
            }
            return result;
        }

        public bool Equals(Complex number) =>
            Real.CompareTo(number.Real) == 0 && Imaginary.CompareTo(number.Imaginary) == 0;
    }
}