<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="MovieFinderApp.View.Results"%>
<%@ Import Namespace="TMDbLib.Objects.Search" %> 
<%@ Import Namespace="TMDbLib.Objects.Movies" %>  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <% MovieSearchResult results = MovieFinder.getInstance().getCurrentSearchResults(); %>
    <%=results.resultCount%> results found for <%=MovieFinder.getInstance().getCurrentSearchTerm()%>
    <table>
        <tr>
            <th>Movie Title</th>
            <th>Release Date</th>
            <th>Genre(s)</th>
            <th>Rating</th>

        </tr>
        <%foreach (Movie movie in results.movies) { %>
            <tr>
                <th>
                    <%=movie.Title%>
                </th>
                <th>
                    <%if (movie.ReleaseDate != null)
                    {%>
                        <%=movie.ReleaseDate.Value.ToString("d") %>
                    <%} 
                    %>
                </th>
                <th>
                   <%//=results.BuildGenreList(movie)%>
                </th>
            </tr>


        <% } %>
    </table>
</body>
</html>
