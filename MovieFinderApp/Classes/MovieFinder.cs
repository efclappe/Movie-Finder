using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

public class MovieFinder
{
    private static MovieFinder instance;

    private static string APIKey = "c729b8fb4ce55457e5497c3630933df2";

    private TMDbClient client = new TMDbClient(APIKey);

    private string currentSearchTerm;

    private MovieSearchResult currentSearch;
    
    private List<Movie> movieResults = new List<Movie>();

    public static MovieFinder getInstance()
    {
        if (instance == null)
        {
            instance = new MovieFinder();
        }
        return instance;
    }

    public async Task searchForMovieByTitle(string searchTerm)
    {
        MovieFinder database = MovieFinder.getInstance();
        SearchContainer<SearchMovie> dbSearchResults = database.client.SearchMovieAsync(searchTerm).Result;

        foreach(SearchMovie movie in dbSearchResults.Results)
        {
           Task t = GetMovieByID(movie.Id);
           await t;
        }

        buildMovieList(dbSearchResults.Results.Count, movieResults);
                
    }

    public async Task GetMovieByID(int id)
    {
        Movie m = await client.GetMovieAsync(id);
        movieResults.Add(m);
    }

    public void buildMovieList(int resultCount, List<Movie> searchResults)
    {
        if(resultCount == 0)
        {
            currentSearch = null;
        }

        currentSearch = new MovieSearchResult(resultCount, searchResults);
    }

    public MovieSearchResult getCurrentSearchResults()
    {
        return currentSearch;
    }

    public void setCurrentSearchTerm(string term)
    {
        currentSearchTerm = term;
    }

    public string getCurrentSearchTerm()
    {
        return currentSearchTerm;
    }
}
