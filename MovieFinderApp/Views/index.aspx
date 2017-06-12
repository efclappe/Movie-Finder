<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MovieFinderApp.View.WebForm1" Async="true" EnableEventValidation="false"%>
<%@ Import Namespace="TMDbLib.Objects.Search" %> 
<%@ Import Namespace="TMDbLib.Objects.Movies" %>  
<%MovieFinder mf = MovieFinder.getInstance();%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Finder</title>
    <link href="../CSS/blue.css" rel="stylesheet" type="text/css" />
</head>
<body>    
    <div style="text-align: center; padding:20px" id="welcomeText">
            Hello. Enter a movie name to search for it.
    </div>
    <div id="searchBar" style="padding-top:20px; padding-bottom:50px">
        <form id="SearchByTitle" runat="server" style="text-align: center" defaultbutton="SubmitButton">
            <asp:TextBox class="aspTextBox" ID="SearchKeyword" runat="server" width="200px" placeholder="Search..." ></asp:TextBox>
            <asp:Button class="aspButton" ID="SubmitButton" runat="server" Text="Find Movies" OnClick="Submitform"/>
        </form>
    </div>
    <div style="text-align:left">
        <%string searchTerm = mf.getCurrentSearchTerm();
            if (!(searchTerm == "" || searchTerm == null))
            {%>
                <% MovieSearchResult results = mf.getCurrentSearchResults(); %>
                <%if (results.getResultCount() == 0)
                    {%>
                    <div style="font-weight: bolder; color: #ff0000; text-align:center"><%=results.resultCount%> results found for "<%=MovieFinder.getInstance().getCurrentSearchTerm()%>"</div>
              <%}
                  else
                  {%>
                    <br />
                    <div style="text-align:center">
                       Sort By: <a href="index.aspx?sortBy=title">Title</a> | <a href="index.aspx?sortBy=year">Year</a> | <a href="index.aspx?sortBy=rating">Rating</a>
                    </div>
                    <br />
                    <%foreach (Movie movie in results.getMovies())
                      { %>
                      
                        <div class="movieResults" style="padding-left:350px; padding-right:350px">                         
                            <a href="http://www.imdb.com/title/<%=movie.ImdbId%>"><%=movie.Title%> </a>(<%=movie.ReleaseDate != null ? movie.ReleaseDate.Value.Year.ToString() : "Unknown"%>)
                             - <b><%=movie.VoteCount == 0 ? "No Ratings" : "Rating: " + movie.VoteAverage + " with " + movie.VoteCount + " votes"%></b>                           
                        </div>
                        <div class="movieResults" style="padding-left:350px; padding-right:350px">
                            <%=movie.Overview%>
                        </div>
                        <br />
                    <%}
                }
             } %>
    </div>
</body>
</html>
