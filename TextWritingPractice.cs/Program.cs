using System;
using System.IO;


namespace TextWritingPractice.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie[] objMovies = new Movie[1];
            int choice;

            do
            {
                Console.WriteLine("Make a choice from 1-4");
                Console.WriteLine("1. Loading Data");
                Console.WriteLine("2. Display all movies");
                Console.WriteLine("3. Add a movie");
                Console.WriteLine("4. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        LoadData(ref objMovies);
                        break;
                    case 2:
                        DisplayAllMovies(objMovies);
                        break;
                    case 3:
                        AddMovie(ref objMovies);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
            
            while (choice != 4);
        }

        public static void LoadData(ref Movie[] objMovies) //passed by reference
        {
            StreamReader reader = new StreamReader("movies.txt"); //first thing to read is size of array
            int size = Convert.ToInt32(reader.ReadLine()); //reads first line and assigns value to int array size...originally pointing to array of size default 1
            objMovies = new Movie[size];

            for (int i = 0; i < objMovies.Length; i++)
            {
                objMovies[i] = new Movie();
                objMovies[i].Title = reader.ReadLine();
                objMovies[i].Director = reader.ReadLine();
                objMovies[i].Year = Convert.ToInt32(reader.ReadLine());
            }
            reader.Close();
            Console.WriteLine("Data loaded. Press enter to continue");
            Console.ReadKey();
        }

        public static void DisplayAllMovies(Movie[] objMovies) //pased by value
        {
            for(int i = 0; i < objMovies.Length; i++)
            {
                Console.WriteLine("-------------------------------");
                objMovies[i].DisplayInformation();
                Console.WriteLine("-------------------------------");
            }
            Console.ReadKey();
            Console.WriteLine("Press enter to continue...");
        }

        public static void AddMovie(ref Movie[] objMovies) //write to the file vs. reading from it above
        {
            StreamWriter writer = new StreamWriter("movies.txt");
            writer.WriteLine(objMovies.Length + 1);

            //create new object

            Movie temp = new Movie();

            //collect data from user
            Console.Write("Enter title: ");
            temp.Title = Console.ReadLine();

            Console.Write("Enter director: ");
            temp.Director = Console.ReadLine();

            Console.Write("Enter year: ");
            temp.Year = Convert.ToInt32(Console.ReadLine());

            //write new data to text file

            writer.WriteLine(temp.Title);
            writer.WriteLine(temp.Director);
            writer.WriteLine(temp.Year); //writer changes it to a string automatically so no need to convert

            //put old movives back to text file because the previous thing deletes them as it adds one

            for(int i = 0; i < objMovies.Length; i++)
            {
                writer.WriteLine(objMovies[i].Title);
                writer.WriteLine(objMovies[i].Director);
                writer.WriteLine(objMovies[i].Year);
            }
            writer.Close();

            //update array to include/load new info in array

            LoadData(ref objMovies);
        }
    }
}
