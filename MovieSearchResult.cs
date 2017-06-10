using System;

public class MovieSearchResult
{
    private int resultCount;

    private List<SearchMovie> movies; 


	public MovieSearchResult(int resultCount, List<SearchMovie> movies)
	{
        this.ResultCount = resultCount;
        this.Movies = movies;
	}

    public List<SearchMovie> Movies { get => movies; set => movies = value; }

    public int ResultCount { get => resultCount; set => resultCount = value; }
}
