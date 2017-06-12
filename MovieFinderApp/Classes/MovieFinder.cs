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
    //Singleton instance
    private static MovieFinder instance;

    //My api key
    private static string APIKey = "c729b8fb4ce55457e5497c3630933df2";

    //Client responsible for searching the database
    private TMDbClient client = new TMDbClient(APIKey);

    //Currently searched movie, used by front end
    private string currentSearchTerm;

    //Current search results, used by front end
    private MovieSearchResult currentSearch;
    
    //A list of movie objects populated after returning search results
    private List<Movie> movieResults = new List<Movie>();

    //Manually selected list of "featured movies" for sidebar
    private static List<Movie> featuredMovies = new List<Movie>();

    //Creates singleton instance if null, returns it if not
    public static MovieFinder getInstance()
    {
        if (instance == null)
        {
            instance = new MovieFinder();
        }

        return instance;
    }

    public async Task generateFeaturedMovies()
    {
        Task t = findFeaturedMovies();
        await t;
    }

    private async Task findFeaturedMovies()
    {
        Movie m1 = await client.GetMovieAsync(11199);//Wild Hogs
        Movie m2= await client.GetMovieAsync(51876);//Limitless
        Movie m3 = await client.GetMovieAsync(24428);//The Avengers
        Movie m4 = await client.GetMovieAsync(11836);//Spongebob

        featuredMovies.Add(m1);
        featuredMovies.Add(m2);
        featuredMovies.Add(m3);
        featuredMovies.Add(m4);
    }

    //Task resposnsible for searching the database using the term entered by the user
    //Returns SearchMovie objects which are then converted into Movie objects in the following method
    public async Task searchForMovieByTitle(string searchTerm)
    {
        movieResults.Clear();
        MovieFinder database = MovieFinder.getInstance();
        SearchContainer<SearchMovie> dbSearchResults = database.client.SearchMovieAsync(searchTerm).Result;
        foreach (SearchMovie movie in dbSearchResults.Results)
        {
           Task t = GetMovieByID(movie.Id);
           await t;
        }

        buildMovieList(dbSearchResults.Results.Count, movieResults);
                
    }

    //Gets a particular movie's info based on its ID, populates a Movie object, and adds it to the search results
    public async Task GetMovieByID(int id)
    {
        Movie m = await client.GetMovieAsync(id);
        movieResults.Add(m);
    }

    //Builds the search results used by the front end using a MovieSearchResult object
    public void buildMovieList(int resultCount, List<Movie> searchResults)
    {
        if(resultCount == 0)
        {
            currentSearch = null;
        }

        currentSearch = new MovieSearchResult(resultCount, searchResults);
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

    //Setter for current search term
    public void setCurrentSearchTerm(string term)
    {
        currentSearchTerm = term;
    }

    //Getter for current search term
    public string getCurrentSearchTerm()
    {
        return currentSearchTerm;
    }

    public List<Movie> getFeaturedMovies()
    {
        return featuredMovies;
    }

}
