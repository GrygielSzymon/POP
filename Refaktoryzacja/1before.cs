
namespace refaktoryzacja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // zmiana długich instrukcji warunkowych na wyrażenie switch
            Console.Write("Podaj numer roli(1-3)");
            if (int.TryParse(Console.ReadLine(), out int roleId))
            {
                string role = GetUserRole(roleId);
                Console.WriteLine("Rola użytkownika: " + role);
            }
            else
            {
                Console.WriteLine("Nieporawny numer roli");
            }
        }

        private static string GetUserRole(int roleId)
        {
            if (roleId == 1) return "Administrator";
            else if (roleId == 2) return "Moderator";
            else if (roleId == 3) return "Użytkownik";
            else return "Nieznana rola";
        }
    }
}
