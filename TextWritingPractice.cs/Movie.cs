using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWritingPractice.cs
{
    class Movie
    {
        private string title;
        private string director;
        private int year;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public Movie()
        {
            Title = title; //"Title";
            Director = director; //"Joe Schmoe";
            Year = year;// 1990;
        }

        public void DisplayInformation()
        {
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Director: {0}", Director);
            Console.WriteLine("Year: {0}", Year);
        }
    }

}
