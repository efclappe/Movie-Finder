
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="results.aspx.cs" Async="true" EnableEventValidation="false" Inherits="MovieFinderApp.View.results"%>
<%@ Import Namespace="TMDbLib.Objects.Search" %> 
<%@ Import Namespace="TMDbLib.Objects.Movies" %>  
<%MovieSearchResult results = mf.getCurrentSearchResults(); %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Results</title>
    <link href="../CSS/moviefinder.css" rel="stylesheet" type="text/css" />
</head>
<body>    
    <div id="searchBar" style="padding-top:20px; padding-bottom:50px; text-align:center; display:block">
        <form id="searchForm" action="results.aspx" method="post">
            <input name="searchQuery" type="text" placeholder="Search..." value="<%=searchQuery%>" id="searchQuery" />
            Sort By:
            <select form="searchForm" name="filter" id="filter">
                <option id="option1" value="relevance">Relevance</option>
                <option value="title">Title</option>
                <option value="year">Year</option>
                <option value="rating">Rating</option>
            </select>
            <input type="submit" name="Button1" value="Find Movies" id="Button1" />
        </form>
    </div>
    <%if (results.getResultCount() == 0)
    {%>
        <div class="zeroResultsText"><%=results.resultCount%> results found for "<%=searchQuery%>"</div>
    <%}
    else
    {%>
        <div class="resultsText"><%=results.resultCount%> results found for "<%=searchQuery%>"</div>
    <%} %>
    <div class="mainView" >
         <%foreach (Movie movie in results.getMovies())
             { %>                      
            <div class="movieResults">
                <div class="moviePosterDiv">
                    <a href="https://image.tmdb.org/t/p/w500/<%=movie.PosterPath%>"><img class="moviePosterImage" src="https://image.tmdb.org/t/p/w92/<%=movie.PosterPath%>"/></a>
                </div>
                <div class="movieDetails"><a href="http://www.imdb.com/title/<%=movie.ImdbId%>"><%=movie.Title%> </a>(<%=movie.ReleaseDate != null ? movie.ReleaseDate.Value.Year.ToString() : "Unknown"%>)
                    - <b><%=movie.VoteCount == 0 ? "No Ratings" : "Rating: " + movie.VoteAverage + " with " + movie.VoteCount + " votes"%></b>                           
                    <br />
                    <%=movie.Overview%>
                </div>
           </div>
           <br />
       <%}%>
     </div>
</body>
    
</html>
<footer>
    <p>All information is retrieved from <a href="https://www.themoviedb.org/">The Movie Database</a>, using LordMike's c# Library <a href="https://github.com/LordMike/TMDbLib/">TMDbLib</a> </p>
</footer>
