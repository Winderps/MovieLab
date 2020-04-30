using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLab
{
    class Movie
    {
        private string _name;
        private Genre _category;

        public string Name { get { return _name; } }
        public Genre Category { get { return _category; } }

        public Movie(string name, Genre category)
        {
            _name = name;
            _category = category;
        }
    }
    enum Genre
    {
        SciFi,
        Animated,
        Horror,
        Drama
    }
}