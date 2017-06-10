using System;

public class Movie
{
    private string name;
    private string releaseYear;
    private string[] genres;
    private string rating;
    private string description;
	public Movie (string name, string releaseYear, string[] genres, string rating, string description)
	{
        this.Name1 = name;
        this.releaseYear = releaseYear;
        this.genres = genres;
        this.rating = rating;
        this.description = description;
	}

    public string Name { get => Name1; set => Name1 = value; }

    public string ReleaseYear { get => releaseYear; set => releaseYear = value; }

    public string[] Genres { get => genres; set => genres = value; }

    public string Rating { get => rating; set => rating = value; }

    public string Description { get => description; set => description = value; }

}
