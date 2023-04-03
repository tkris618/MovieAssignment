using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
logger.Info(scrubbedFile);
MovieFile movieFile = new MovieFile(scrubbedFile);

string choice;

Console.ForegroundColor = ConsoleColor.Green;
do{
    Console.WriteLine("Movie Library");
    Console.WriteLine("1. Add Movie");
    Console.WriteLine("2. View all movies");
    Console.WriteLine("3. Find movie");

    Console.WriteLine("Choose from the options above.\nAny other key to exit.");
    choice = Console.ReadLine();
    string genres;
        if (choice == "1"){
            Console.WriteLine("Would you like to add a movie? (Y/N)");
            string resp = Console.ReadLine().ToUpper();

            if (resp != "Y") {break;}

            Movie movie = new Movie();
            Console.WriteLine("Enter title:");
            movie.title = Console.ReadLine();
            Console.WriteLine("Enter genre:");
            genres = Console.ReadLine();
            Console.WriteLine("Enter movie director:");
            movie.director = Console.ReadLine();
            Console.WriteLine("Enter run time: (h:m:s)");
            movie.runningTime = TimeSpan.Parse(Console.ReadLine());

        }
        if (choice == "2") 
        {
            if(File.Exists(scrubbedFile))
            {
                StreamReader sr = new StreamReader(scrubbedFile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] arr = line.Split(',');

                    Console.WriteLine("Movie ID: {0}, Movie Title: {1}, Genre: {2}, Director: {3}, Running time: {4}");
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        if (choice == "3")
        {
            Console.WriteLine("Search for movie? (Y/N).");
            String response = Console.ReadLine().ToUpper();

            if (response != "Y") {break;}

            Console.WriteLine("Enter search option (title/date/genre):");
           string option = Console.ReadLine();

            if (option == "title" || option == "date")
            {
                Console.WriteLine("Enter title/date to search:");
                string titleDate = Console.ReadLine();
                var Movies = movieFile.Movies.Where(m => m.title.Contains(titleDate));
                Console.WriteLine($"There are {Movies.Count()} movies with {titleDate} in the title:");
                foreach(Movie m in Movies) 
                {
                    Console.WriteLine($" {m.title}");
                }
            }
            if(option == "genre")
            {
                Console.WriteLine("Enter genre to search for: ");
                string searchGenre = Console.ReadLine();
                var Movies = movieFile.Movies.Where(m => m.genres.Contains(searchGenre));
                Console.WriteLine($"There are {Movies.Count()} movies within {searchGenre} genre: ");

                foreach(Movie g in Movies)
                {
                    Console.WriteLine($" {g.title}");
                }
            }
            
        }

}while (choice == "1"||choice == "2"||choice == "3");

Console.ForegroundColor = ConsoleColor.White;

logger.Info("Program ended");