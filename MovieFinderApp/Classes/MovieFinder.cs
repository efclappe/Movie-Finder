using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

//Class used for finding movies.  Search term is entered by the user and data for all matched movies is returned.
//Uses TMDbLib, a C# wrapper for The Movie Database's API
public class MovieFinder
{
    //My api key
    private static string APIKey = "c729b8fb4ce55457e5497c3630933df2";

    //Client responsible for searching the database
    private TMDbClient client;

    //Current search results, used by front end
    private MovieSearchResult currentSearch = new MovieSearchResult(0, new List<Movie>(), "");

     //A list of movie objects populated after returning search results
    private List<Movie> movieResults = new List<Movie>();

    //Creates singleton instance if null, returns it if not
    public MovieFinder()
    {
        client = new TMDbClient(APIKey);
    }

    //Task resposnsible for searching the database using the term entered by the user
    //Returns SearchMovie objects which are then converted into Movie objects in the following method
    public async Task searchForMovieByTitle(string searchTerm, string filter)
    {
        SearchContainer<SearchMovie> dbSearchResults = this.client.SearchMovieAsync(searchTerm).Result;
        foreach (SearchMovie movie in dbSearchResults.Results)
        {
           Task t = GetMovieByID(movie.Id);
           await t;
        }
        System.Diagnostics.Debug.WriteLine(dbSearchResults.Results.Count);
        buildMovieList(dbSearchResults.Results.Count, movieResults, filter);
                
    }

    //Gets a particular movie's info based on its ID, populates a Movie object, and adds it to the search results
    public async Task GetMovieByID(int id)
    {
        Movie m = await client.GetMovieAsync(id);
        movieResults.Add(m);
    }

    //Builds the search results used by the front end using a MovieSearchResult object
    public void buildMovieList(int resultCount, List<Movie> searchResults, string filter)
    {
        currentSearch = new MovieSearchResult(resultCount, searchResults, filter);
    }

    //Getter for the current search results
    public MovieSearchResult getCurrentSearchResults()
    {
        return currentSearch;
    }

    public void setCurrentSearchResults (MovieSearchResult msr)
    {
        currentSearch = msr;
    }

}
