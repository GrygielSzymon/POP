using System;
using System.Security.Cryptography.X509Certificates;

namespace MaksimTsarik
{
    internal class Program
    {
        public class Employee
        {
            public string Name { get; }
            public DateOnly DateOfBirth { get; }
            public int Age => CalculateAge();

            public Employee(string name, DateOnly dateOfBirth)
            {
                Name = name;
                DateOfBirth = dateOfBirth;
            }

            private int CalculateAge()
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age)) --age;
                return age;
            }
        }

        static void Main(string[] args)
        {
            string name = GetValidName();
            DateOnly dateOfBirth = GetValidDateOfBirth();

            Employee emp = new Employee(name, dateOfBirth);
            Console.WriteLine($"Pracownik: {emp.Name}, wiek: {emp.Age}");
        }

        private static DateOnly GetValidDateOfBirth()
        {
            DateOnly dateOfBirth;
            bool isValidDate = false;
            do
            {
                Console.WriteLine("Podaj datę urodzenia (RRRR-MM-DD)");
                string input = Console.ReadLine();

                if (DateOnly.TryParse(input, out dateOfBirth) && dateOfBirth <= DateOnly.FromDateTime(DateTime.Now))
                {
                    isValidDate = true;
                }
                else
                {
                    Console.WriteLine("Błąd: podaj poprawną datę urodzenia (w przeszłości)");
                }
            }
            while (!isValidDate);
            return dateOfBirth;
        }

        private static string GetValidName()
        {
            string name;
            const byte MinLength = 3;
            const byte MaxLength = 50;

            string[] errorMessages = new string[]
            {
                "Imie nie może byc puste",
                $"Imię musi mieć co najmniej {MinLength} znaków",
                $"Imię nie może mieć więcej nż {MaxLength} znaków"
            }

            do
            {
                Console.WriteLine("Podaj imie: ");
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Imię nie może być puste. Spróbuj ponownie.");
                }
                else
                {
                    return name;
                }
            }
            while (true);
        }
    }
}
