namespace HSZF_LABOR_2026_09_18
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string inputTitle;
            int inputMinutes;
            DateTime? inputReleaseDate;

            MovieManager movieManager = new MovieManager();
            movieManager.Event += MovieManager_Event;

            while (true)
            {
                Console.WriteLine("Kilépsz?");
                inputTitle = Console.ReadLine();
                if (inputTitle == "exit")
                {
                    break;
                }

                Console.WriteLine("Kérem a film címét:  ");
                inputTitle = Console.ReadLine();
                Console.WriteLine("Kérem a film hosszát:  ");
                inputMinutes = int.Parse(Console.ReadLine());
                Console.WriteLine("Kérem a megjelenési dátumot:  ");
                inputReleaseDate = Convert.ToDateTime(Console.ReadLine());

                movieManager.AddMovie(inputTitle, inputMinutes, inputReleaseDate);
            }

            movieManager.ListMovies();
        }

        private static void MovieManager_Event(object? sender, string e)
        {
            Console.WriteLine(e);
        }
    }

}

