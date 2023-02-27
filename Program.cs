// Download initial movie data file
// Create movie Console Application to see all movies in the file and to add movies to the file Check for duplicate values!
// Implement Exception Handling
// Implement NLog framework
string file = "movies.txt"; 
string line;
string? resp = Console.ReadLine();
do{
Console.WriteLine("Welcome to the Movie Library!\n");
Console.WriteLine("What would you like to do?");
Console.WriteLine("1. View movies on file.");
Console.WriteLine("2. Add a new movie?");
Console.WriteLine("To exit press any key.");
resp = Console.ReadLine();

if(resp == "1") {
    if (File.Exists(file))
    {
        string content = File.ReadAllText(file);
       Console.WriteLine(content);
    }

}

else if (resp == "2"){
if(File.Exists(file)) {


    Console.WriteLine("Enter title of movie: ");
    string movieTitle = Console.ReadLine();

    StreamReader sr = new StreamReader(file);
    line = sr.ReadLine();
    var moviesIndex = line.IndexOf(",");

    var movieString = line.Substring(2, moviesIndex);

    Console.WriteLine(movieString);
}

    //StreamWriter sw = File.AppendText(file);

    // if(file.Contains(movieTitle)) 
    // {
    //     Console.WriteLine("Movie already exists within file.");
    // }
    // try {

    // } catch (Exception ex) {
    //      Console.WriteLine("This movie already exists within file: " +  movieTitle);
    //     return;
           
    //  }
    
    // if (movieTitle != file){


    // } else {
    //     Console.WriteLine("That movie already exists within the Movie Library. Please try again.");
    // }

}

}while (resp == "1" || resp == "2");
//parsing is sifting through the data take a value to pull it to the console.