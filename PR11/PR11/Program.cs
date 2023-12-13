using System.Collections.Specialized;
using System.Xml;
using System.Text.RegularExpressions;
using System;

namespace PR11
{

    public class Work
    {
        public int kod;
        public double zarabotok;
        public string[] NameBase;
        public string[] SurnameBase;
        public string name;
        public string surname;
        public string cardNumber;
        public string phoneNumber;
    }

    class Program
    {
       
        static void Main()
        {
            Work[] w = new Work[5];

            Random rand = new Random();
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = new Work();
                w[i].kod = i;
                w[i].zarabotok = rand.Next(15000, 30000);

                Console.Write($"Код сотрудника №{i + 1}: Имя: ");
                w[i].name = Console.ReadLine();

                Console.Write($"Код сотрудника №{i + 1}: Фамилия: ");
                w[i].surname = Console.ReadLine();

                Console.Write($"Код сотрудника №{i + 1}: Номер карты: ");
                w[i].cardNumber = Console.ReadLine();

                Console.Write($"Код сотрудника №{i + 1}: Номер телефона: ");
                w[i].phoneNumber = Console.ReadLine();

                // Проверка корректности ввода номера карты и номера телефона с помощью регулярных выражений
                // В данном примере шаблоны проверки - номер карты состоит из 16 цифр, номер телефона - из 11 цифр
                string cardPattern = @"^\d{16}$";
                string phonePattern = @"^\d{11}$";
                if (!Regex.IsMatch(w[i].cardNumber, cardPattern))
                {
                    Console.WriteLine("Некорректный номер карты! Введите 16 цифр без пробелов и разделителей.");
                    return;
                }
                if (!Regex.IsMatch(w[i].phoneNumber, phonePattern))
                {
                    Console.WriteLine("Некорректный номер телефона! Введите 11 цифр без пробелов и разделителей.");
                    return;
                }
            }

            Console.WriteLine("\nРезультат: ");

            double projitMin = 20000; // Прожиточный минимум

            int countProjitMinPerson = 0; // Количество сотрудников с зарплатой выше прожиточного минимума
            Console.WriteLine("Сотрудники с зарплатой выше прожиточного минимума:");
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i].zarabotok > projitMin)
                {
                    countProjitMinPerson++;
                    Console.WriteLine($"Код сотрудника №{i + 1}\nИмя: {w[i].name}\nФамилия: {w[i].surname}\nЗарплата: {w[i].zarabotok}");
                }
            }
            Console.WriteLine($"Количество сотрудников с зарплатой выше прожиточного минимума: {countProjitMinPerson}");

            Console.WriteLine("\nСотрудники с фамилией, начинающейся на 'А':");
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i].surname.StartsWith("А", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Код сотрудника №{i + 1}\nИмя: {w[i].name}\nФамилия: {w[i].surname}\nЗарплата: {w[i].zarabotok}");
                }
            }

            Console.WriteLine("\nСписок фамилий, отсортированных по алфавиту:");
            Array.Sort(w, (a, b) => string.Compare(a.surname, b.surname));
            for (int i = 0; i < w.Length; i++)
            {
                Console.WriteLine($"{w[i].surname}");
            }

            Console.ReadKey();
        }
    }

}