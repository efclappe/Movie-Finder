
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="results.aspx.cs" Async="true" EnableEventValidation="false" Inherits="MovieFinderApp.View.results"%>
<%@ Import Namespace="TMDbLib.Objects.Search" %> 
<%@ Import Namespace="TMDbLib.Objects.Movies" %>  
<%MovieSearchResult results = mf.getCurrentSearchResults(); %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Finder</title>
    <link href="../CSS/moviefinder.css" rel="stylesheet" type="text/css" />
</head>
<body>    
    <div style="text-align: center; id="welcomeText">
            Hello. Enter a movie name to begin search.
    </div>

    <div id="searchBar" style="padding-top:20px; padding-bottom:50px; text-align:center; display:block">
        <form id="searchForm" action="results.aspx" method="post">
            <input name="searchQuery" type="text" placeholder="Search..." id="searchQuery" />
            Sort By:
            <select form="searchForm" name="filter" id="filter">
                <option value="relevance">Relevance</option>
                <option value="title">Title</option>
                <option value="year">Year</option>
                <option value="rating">Rating</option>
            </select>
            <input type="submit" name="Button1" value="Find Movies" id="Button1" />
        </form>
    </div>
    <div>
    <div class="sidebar" style="width:15%">
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
    </div>
    <div class="mainView" style="width:85%; float:right">
        <%if (!(searchQuery == null))
            {%>
                <%if (results.getResultCount() == 0)
                    {%>
                    <div class="movieResults" style="font-weight: bolder; color: #ff0000; text-align:center"><%=results.resultCount%> results found for "<%=searchQuery%>"</div>
              <%}
                  else
                  {%>
                    <div class="movieResults" style="font-weight: bolder; color: #029c16; text-align:center"><%=results.resultCount%> results found for "<%=searchQuery%>"</div>
                    <br />
                    <%foreach (Movie movie in results.getMovies())
                      { %>
                      
                        <div class="movieResults">                         
                            <a href="http://www.imdb.com/title/<%=movie.ImdbId%>"><%=movie.Title%> </a>(<%=movie.ReleaseDate != null ? movie.ReleaseDate.Value.Year.ToString() : "Unknown"%>)
                             - <b><%=movie.VoteCount == 0 ? "No Ratings" : "Rating: " + movie.VoteAverage + " with " + movie.VoteCount + " votes"%></b>                           
                        </div>
                        <div class="movieResults">
                            <%=movie.Overview%>
                        </div>
                        <br />
                    <%}
                }
             } %>
    </div>
        </div>
</body>
</html>
