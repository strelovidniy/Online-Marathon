using System;

namespace Sprint_01.Task_03
{
    class Fraction
    {
        private readonly int numerator;
        private readonly int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;

            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                this.denominator = denominator;
            }
        }

        public static Fraction operator +(Fraction a)
            => a.Simplify();
        public static Fraction operator -(Fraction a) 
            => new Fraction(-a.numerator, a.denominator).Simplify();

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator).Simplify();

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator !(Fraction a) 
            => new Fraction(a.denominator, a.numerator).Simplify();

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator).Simplify();

        public static Fraction operator /(Fraction a, Fraction b) 
            => a * !b;

        public static bool operator ==(Fraction a, Fraction b)
            => a.ToString() == b.ToString();

        public static bool operator !=(Fraction a, Fraction b)
            => !(a == b);

        public override string ToString()
            => $"{Simplify().numerator} / {Simplify().denominator}";

        public Fraction Simplify()
        {
            int num;
            int den;

            if (denominator < 0)
            {
                num = -numerator;
                den = -denominator;
            }
            else
            {
                num = numerator;
                den = denominator;
            }

            for (int i = (Math.Abs(num) > den ? den : Math.Abs(num)); i >= 1; --i)
            {
                if (Math.Abs(num) % i == 0 && den % i == 0)
                {
                    num /= i;
                    den /= i;
                }
            }

            return new Fraction(num, den);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction))
            {
                return false;
            }
            
            return this == (Fraction)obj;
        }

        public override int GetHashCode() 
            => (numerator + denominator + numerator % denominator) * numerator * denominator;
    }
}
