// Download initial movie data file
// Create movie Console Application to see all movies in the file and to add movies to the file Check for duplicate values!
// Implement Exception Handling
// Implement NLog framework
String? resp = Console.ReadLine();
do{
Console.WriteLine("Welcome to the Movie Library!\n");
Console.WriteLine("What would you like to do?");
Console.WriteLine("1. View movies on file.");
Console.WriteLine("2. Add a new movie?");
Console.WriteLine("To exit press any key.");
resp = Console.ReadLine();

if(resp == "1") {



}

else if (resp == "2"){

    Console.WriteLine("Enter title of movie: ");
    Console.WriteLine("Enter movies genre (Can be more than one genre.): "); 

}

}while (resp == "1" || resp == "2");
//parsing is sifting through the data take a value to pull it to the console.