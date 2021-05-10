using System;

/*
Источник: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

Fraction - упрощенная структура, представляющая рациональное число.
Необходимо перегрузить операции:
+ (бинарный)
- (бинарный)
*
/ (в случае деления на 0, выбрасывать DivideByZeroException)

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки, содержацие числители и знаменатели двух дробей, разделенные /, соответственно.
1/3
1/6
Программа должна вывести на экран сумму, разность, произведение и частное двух дробей, соответственно,
с использованием перегруженных операторов (при необходимости, сокращать дроби):
1/2
1/6
1/18
2

Обратите внимание, если дробь имеет знаменатель 1, то он уничтожается (2/1 => 2). Если дробь в числителе имеет 0, то 
знаменатель также уничтожается (0/3 => 0).
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator)
    {
        num = numerator;
        if (denominator == 0)
            throw new DivideByZeroException();
        else
            den = denominator;
    }

    public static int GCD(int a, int b)
    {
        int result = 1;
        for (int i = 1; i < Math.Min(Math.Abs(a), Math.Abs(b)) + 1; i++)
        {
            if (a % i == 0 && b % i == 0)
                result = i;
        }
        return result;
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int num = f1.num * f2.den + f2.num * f1.den;
        int den = f1.den * f2.den;
        int gcd = GCD(num, den);
        num /= gcd;
        den /= gcd;
        return new Fraction(num, den);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int num = f1.num * f2.den - f2.num * f1.den;
        int den = f1.den * f2.den;
        int gcd = GCD(num, den);
        num /= gcd;
        den /= gcd;
        return new Fraction(num, den);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        int num = f1.num * f2.num;
        int den = f1.den * f2.den;
        int gcd = GCD(num, den);
        num /= gcd;
        den /= gcd;
        return new Fraction(num, den);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        int num = f1.num * f2.den;
        int den = f1.den * f2.num;
        int gcd = GCD(num, den);
        num /= gcd;
        den /= gcd;
        return new Fraction(num, den);
    }
    public override string ToString()
    {
        if (Math.Abs(den) == 1)
            return (num / den).ToString();
        else if (num == 0)
            return "0";
        else return num + "/" + den;
    }
}

public static class OperatorOverloading
{
    public static void Main()
    {
        try
        {
            string sf1 = Console.ReadLine();
            string sf2 = Console.ReadLine();
            Fraction f1 = new Fraction(int.Parse(sf1.Substring(0, sf1.IndexOf('/'))), int.Parse(sf1.Substring(sf1.IndexOf('/') + 1)));
            Fraction f2 = new Fraction(int.Parse(sf2.Substring(0, sf2.IndexOf('/'))), int.Parse(sf2.Substring(sf2.IndexOf('/') + 1)));
            Console.WriteLine(f1 + f2);
            Console.WriteLine(f1 - f2);
            Console.WriteLine(f1 * f2);
            Console.WriteLine(f1 / f2);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("zero");
        }
    }
}
