using System;
using System.Collections.Generic;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

public class MovieSearchResult
{
    public int resultCount;

    public List<Movie> movies; 


	public MovieSearchResult(int resultCount, List<Movie> movies)
	{
        this.resultCount = resultCount;
        this.movies = movies;
	}


    public string BuildGenreList(Movie movie)
    {
        List<Genre> genreList = movie.Genres;

        string genres = "";

        foreach(Genre g in genreList)
        {
            genres += g.Name + ", ";
        }
        genres = genres.Substring(0, genres.Length - 2); //cut off the last ", " from the genre list.

        
        return null;
    }

}
