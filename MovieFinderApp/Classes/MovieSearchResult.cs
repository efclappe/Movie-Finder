using System;
using System.Collections.Generic;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

//Class representing a search result made by the user
public class MovieSearchResult
{
    //Amount of movies found
    public int resultCount;

    //Collection of Movie objects returned by the search
    private List<Movie> movies; 


	public MovieSearchResult(int resultCount, List<Movie> movies)
	{
        this.resultCount = resultCount;
        this.movies = movies;
	}

    //Builds a list of genres for a Movie in the search results.  The genres are returned normally as an array of ints and strings,
    //this formats them into a nice list for display purposes
    public string BuildGenreList(Movie movie)
    {
        List<Genre> genreList = movie.Genres;

        string genres = "";

        foreach(Genre g in genreList)
        {
            genres += g.Name + ", ";
        }

        if(genres.Length > 0)
            genres = genres.Substring(0, genres.Length - 2); //cut off the last ", " from the genre list.


        return genres;
    }

    public MovieSearchResult sortByTitle()
    {
        movies.Sort((m1, m2) => m1.Title.CompareTo(m2.Title));
        return new MovieSearchResult(this.resultCount, movies);
    }

    public MovieSearchResult sortByYear()
    {
        List<Movie> invalidMovies = new List<Movie>();
        List<Movie> validMovies = new List<Movie>();
        foreach(Movie m in movies)
        {
            if (m.ReleaseDate == null)
            {
                invalidMovies.Add(m);
            }
            else
            {
                validMovies.Add(m);
            }
        }
        movies.Sort((x, y) => -DateTime.Compare(x.ReleaseDate ?? DateTime.MinValue, y.ReleaseDate ?? DateTime.MinValue));
        return new MovieSearchResult(this.resultCount, movies);
    }

    public MovieSearchResult sortByRating()
    {
        movies.Sort((m1, m2) => m2.VoteAverage.CompareTo(m1.VoteAverage));
        return new MovieSearchResult(this.resultCount, movies);
    }


    public List<Movie> getMovies()
    {
        return movies;
    }

    public int getResultCount()
    {
        return resultCount;
    }
}
