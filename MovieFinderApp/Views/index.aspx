
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MovieFinderApp.View.WebForm1" Async="true" EnableEventValidation="false"%>
<%@ Import Namespace="TMDbLib.Objects.Search" %> 
<%@ Import Namespace="TMDbLib.Objects.Movies" %>  
<%MovieFinder mf = MovieFinder.getInstance();%>
<%var searchTerm = Session["searchTerm"];%>
<% MovieSearchResult results = mf.getCurrentSearchResults(); %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Finder</title>
    <link href="../CSS/moviefinder.css" rel="stylesheet" type="text/css" />
</head>
<body>    
    <div style="text-align: center; padding:20px" id="welcomeText">
            Hello. Enter a movie name to search for it.
    </div>
    <div id="searchBar" style="padding-top:20px; padding-bottom:50px">
            <input type="text" id="searchterm" placeholder="Search" style="width:200px;" />
            <input type="button" value="Find Movies" onclick="window.location.href = 'index.aspx?searchTerm=' + document.getElementById('searchterm').value" />
    </div>
    <div class="sidebar">
        Hi.
    </div>
    <div class="mainView">
        <%if (!(searchTerm == null))
            {%>
                <%if (results.getResultCount() == 0)
                    {%>
                    <div class="movieResults" style="font-weight: bolder; color: #ff0000; text-align:center"><%=results.resultCount%> results found for "<%=MovieFinder.getInstance().getCurrentSearchTerm()%>"</div>
              <%}
                  else
                  {%>
                    <div class="movieResults" style="font-weight: bolder; color: #029c16; text-align:center"><%=results.resultCount%> results found for "<%=MovieFinder.getInstance().getCurrentSearchTerm()%>"</div>
                    <br />
                    <div class="sortHeader">
                       Sort By: <a href="window.locationhref + '&sortBy=title'">Title</a> | <a href="window.locationhref + '&sortBy=year'">Year</a> | <a href="window.locationhref + '&sortBy=rating'">Rating</a>
                    </div>
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
</body>
</html>
