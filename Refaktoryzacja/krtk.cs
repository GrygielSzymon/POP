namespace RefaktoryzacjaZamowien
{

    internal class Program

    {

        static void Main(string[] args)

        {

            Console.Write("Podaj status zamówienia (1 - Nowe, 2 - W trakcie, 3 - Wysłane, 4 - Zrealizowane): ");

            if (int.TryParse(Console.ReadLine(), out int statusId))

            {

                string statusDescription = GetOrderStatusDescription(statusId);

                Console.WriteLine($"Status zamówienia: {statusDescription}");

            }

            else

            {

                Console.WriteLine("Niepoprawny status zamówienia.");

            }

        }



        private static string GetOrderStatusDescription(int statusId)

        {
            var statuses = new Dictionary<int, string>()
            {
                { 1, "Nowe zamówienie"},
                { 2, "Zamówienie w trakcie realizacji"},
                { 3, "Zamówienie wysłane"},
                { 4, "Zamówienie zrealizowane"}
            };
            return statuses.TryGetValue(statusId, out var a) ? a : "źle";
        }

    }

}
