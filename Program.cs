﻿using System;
using System.Threading;

namespace MultiThread
{
    class Program
    {
        public static int M, N;
        public static int a, b, c, d;
        public static double Weight_a = 0.1, Weight_b = 0.2, Weight_c = 0.3, Weight_d = 0.4;
        public static double TotalWeight_a, TotalWeight_b, TotalWeight_c, TotalWeight_d;
        const int SizeTruck1 = 7000;
        const int SizeTruck2 = 5000;

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            // предлагается пользователю осуществить ввод значения переменной
            Console.Write("Укажите объём сырья (не менее 100 едениц):");
            string userString = Console.ReadLine();
            M = Convert.ToInt32(userString);
            // если значение переменной выходит из указанного предела, то выбрасывается исключение "Необходимый объём сырья должен быть более 100 едениц."
            if (M < 100)
            {
                throw new Exception("Необходимый объём сырья должен быть более 100 едениц.");
            }
            Console.ForegroundColor = ConsoleColor.White;
            // предлагается пользователю осуществить ввод значения переменной
            Console.Write("\nУкажите объём выпуска продукции в час (не менее 50 едениц):");
            string userString1 = Console.ReadLine();
            N = Convert.ToInt32(userString1);
            // если значение переменной выходит из указанного предела, то выбрасывается исключение
            if (N < 50)
            {
                throw new Exception("Максимальный объём выпуска продукции в час более 50 едениц");
            }
            a = N;
            b = Convert.ToInt32(1.1 * N);
            c = Convert.ToInt32(1.2 * N);
            d = Convert.ToInt32(1.3 * N);
            TotalWeight_a = a * Weight_a;
            TotalWeight_b = b * Weight_b;
            TotalWeight_c = c * Weight_c;
            TotalWeight_d = d * Weight_d;
            int Storage = M * (a + b + c + d);
            double Delivery = Convert.ToInt32(Storage * 95 / 100);
            double VoyageTruck1 = Convert.ToInt32(Delivery * 60 / 100 / SizeTruck1);
            double VoyageTruck2 = Convert.ToInt32(Delivery * 40 / 100 / SizeTruck2);
            double Truck1 = Convert.ToInt32(Delivery * 60 / 100);
            double Truck2 = Convert.ToInt32(Delivery * 40 / 100);
            double RawTruck1 = Convert.ToInt32((Delivery * 60 / 100) - (a + b));
            double RawTruck2 = Convert.ToInt32((Delivery * 40 / 100) - (c + d));
            // создаем первый поток и назначаем функцию - выпуск продукта_a 
            Thread factory_a = new Thread(ReleaseProduct_a);
            // запускаем первый поток
            factory_a.Start();
            // Остановка потока на 1 секунду
            Thread.Sleep(TimeSpan.FromSeconds(1));
            for (int i = 1; i <= a; i++)
            {
                Console.Write(string.Format("a{0} ", i));
            }
            // создаем второй поток и назначаем функцию - выпуск продукта_b
            Thread factory_b = new Thread(ReleaseProduct_b);
            // запускаем второй поток
            factory_b.Start();
            // Остановка потока на 1 секунду
            Thread.Sleep(TimeSpan.FromSeconds(1));
            for (int i = 1; i <= b; i++)
            {
                Console.Write(string.Format("b{0} ", i));
            }
            // создаем третий поток и назначаем функцию - выпуск продукта_c 
            Thread factory_c = new Thread(ReleaseProduct_c);
            // запускаем третий поток
            factory_c.Start();
            // Остановка потока на 1 секунду
            Thread.Sleep(TimeSpan.FromSeconds(1));
            for (int i = 1; i <= c; i++)
            {
                Console.Write(string.Format("c{0} ", i));
            }
            // создаем четвёртый поток и назначаем функцию - выпуск продукта_d
            Thread factory_d = new Thread(ReleaseProduct_d);
            // запускаем четвёртый поток
            factory_d.Start();
            // Остановка потока на 1 секунду
            Thread.Sleep(TimeSpan.FromSeconds(1));
            for (int i = 1; i <= d; i++)
            {
                Console.Write(string.Format("c{0} ", i));
            }
            Console.ForegroundColor = ConsoleColor.White;
            // далее выводятся расчётные данные по указанному условию задания
            Console.Write(string.Format("\n\nОбщая вместимость склада {0} едениц.", Storage));
            Console.Write(string.Format("\n\nПри заполнении склада на 95% - {0} едениц, производится вывоз со склада двумя грузовиками.", Delivery));
            Console.Write(string.Format("\n\nПервый грузовик (вместимостью 7000 едениц) выполнит {0} рейс(а)(ов). " +
             "\n\nПеревезёт {1} едениц, в том числе: продукт a-{2} ед., продукт b-{3} ед., сырья {4} ед.", VoyageTruck1, Truck1, a, b, RawTruck1));
            Console.Write(string.Format("\n\nВторой грузовик (вместимостью 5000 едениц) выполнит {0} рейс(а)(ов). " +
             "\n\nПеревезёт {1} едениц, в том числе: продукт c-{2} ед., продукт d-{3} ед., сырья {4} ед.", VoyageTruck2, Truck2, c, d, RawTruck2));
        }
        // функция потока a
        public static void ReleaseProduct_a()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format("\n\n\nЗавод A: Объём выпуска продукта a составляет {0} ед./час, а общий вес партии продукта составляет {1} кг.", a, TotalWeight_a));
        }
        // функция потока b
        public static void ReleaseProduct_b()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("\n\n\nЗавод B: Объём выпуска продукта b составляет {0} ед./час, а общий вес партии продукта составляет {1} кг.", b, TotalWeight_b));
        }
        // функция потока c
        public static void ReleaseProduct_c()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("\n\n\nЗавод C: Объём выпуска продукта c составляет {0} ед./час, а общий вес партии продукта составляет {1} кг.", c, TotalWeight_c));
        }
        // функция потока d
        public static void ReleaseProduct_d()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(string.Format("\n\n\nЗавод D: Объём выпуска продукта d составляет {0} ед./час, а общий вес партии продукта составляет {1} кг.", d, TotalWeight_d));
            Console.ReadLine();
        }
    }
}

