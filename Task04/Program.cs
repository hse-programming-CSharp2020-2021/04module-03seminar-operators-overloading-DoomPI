﻿using System;
using System.Globalization;

/*
Источник: https://metanit.com/

Класс Celcius представляет градусник по Цельсию, а Fahrenheit - градусник по Фаренгейту.
Определите операторы преобразования от типа Celcius и наоборот.
Преобразование температуры по шкале Фаренгейта (Tf) в температуру по шкале Цельсия (Tc): Tc = 5/9 * (Tf - 32).
Преобразование температуры по шкале Цельсия в температуру по шкале Фаренгейта: Tf = 9/5 * Tc + 32.

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество градусов в Фаренгейтах и количество градусов в Цельсиях.
50
50
Программа должна вывести на экран число градусов в Цельсиях и Фаренгейтах, соответственно
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
10,00
122,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task04
{
    class Celcius
    {
        public double Gradus { get; set; }

        public static implicit operator Fahrenheit(Celcius tc) => new Fahrenheit { Gradus = (double)(tc.Gradus * 9 / 5 + 32) };

        public override string ToString()
        {
            string output = string.Format("{0:f2}", Gradus);
            output = output.Replace('.', ',');
            return output;
        }
    }

    class Fahrenheit
    {
        public double Gradus { get; set; }

        public static implicit operator Celcius(Fahrenheit tf) => new Celcius { Gradus = (double)((tf.Gradus - 32) * 5 / 9) };

        public override string ToString()
        {
            string output = string.Format("{0:f2}", Gradus);
            output = output.Replace('.', ',');
            return output;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("ru - RU");
            Fahrenheit farenheit = new Fahrenheit { Gradus = double.Parse(Console.ReadLine()) };
            Celcius celcius = new Celcius { Gradus = double.Parse(Console.ReadLine()) };
            Console.WriteLine((Celcius)farenheit);
            Console.WriteLine((Fahrenheit)celcius);
        }
    }
}
