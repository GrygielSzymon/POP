namespace Takskmarik
{
    internal class Program
    {
        class Employee
        {
            //Brak enkapsulacji, niepoprawne użycie pól zamiast właścwości (nie mamy kontrol nad ustawianiem wartości),
            //brak zabespieczenia przed pustym imieniem
            public string Name;
            public int Age; //błędny typ danych, powinniśmy zastosować: byte (0-255), ushort (0-65535), 
            //DateTime (musimy dodać metodę obliczającą wek w czasie rzeczywistym)
            public double Salary;


            public Employee(string name, int age, double salary)
            {
                Name = name;
                Age = age;
                Salary = salary;
            }

            //brak waldacji w metodzie, nie sprawdzamy czy amount jest dodatnie
            public void IncreaseSalary(double amount)
            {
                Salary += amount;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ivan Sentemon");

            Employee emp = new Employee("janusz", 20, 5000);
            emp.Age = -5;   //Możemy ustawić błędny wiek
            emp.Salary = -1000; //Możemy ustawić negatywną pensję
            Console.WriteLine($"Pracownik: {emp.Name}, wiek: {emp.Age}, pensja: {emp.Salary} \n");
        }
    }
}
