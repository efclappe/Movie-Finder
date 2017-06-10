using System;
using System.Collections.Generic;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using MovieSearchResults;

public class MovieFinder
{
    private static MovieFinder instance;

    private TMDbClient client;

    private static string APIKey = "c729b8fb4ce55457e5497c3630933df2";

    public static MovieFinder getInstance()
    {
        if (instance == null)
        {
            instance = new MovieFinder();
            client = new TMDbClient(APIKey);
        }
        return instance;
    }

    public MovieSearchResult searchForMovieByTitle(string searchTerm)
    {
        MovieFinder database = MovieFinder.getInstance();
        SearchContainer<SearchMovie> dbSearchResults = database.client.SearchMovieAsync(searchTerm).result;
        List<SearchMovie> movieResults = new List<SearchMovie>();

        if(dbSearchResults.Results.Count == 0)
        {
            return null;
        }

        foreach(SearchMovie movie in dbSearchResults.Results)
        {
           movieResults.Add(movie);
        }

        MovieSearchResult searchReults = new MovieSearchResult(dbSearchResults.Results.Count, movieResults);

        return searchResults;
    }
}
