<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="MovieFinderApp.View.Results"%>
<%@ Import Namespace="TMDbLib.Objects.Search" %> 
<%@ Import Namespace="TMDbLib.Objects.Movies" %>  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/blue.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <% MovieSearchResult results = MovieFinder.getInstance().getCurrentSearchResults(); %>
    <%=results.resultCount%> results found for "<%=MovieFinder.getInstance().getCurrentSearchTerm()%>"
    <table>
        <tr>
            <col width ="300" />
            <th>Movie Title</th>
            <th>Release Date</th>
            <th>Genre(s)</th>
            <th>TMDb Rating</th>
        </tr>
        <%foreach (Movie movie in results.getMovies()) { %>
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
                   <%=results.BuildGenreList(movie)%>
                </th>
                <th>
                    <%=movie.VoteAverage%>
                </th>

            </tr>


        <% } %>
    </table>
</body>
</html>





 {%>
                    <div style="font-weight: bolder; color: #00CC00;"><%=results.resultCount%> results found for "<%=MovieFinder.getInstance().getCurrentSearchTerm()%>"</div>
                        <table border="1" style="width: 80%">
                            <colgroup>
                                <col span="1" style="width: 30%;"/>
                                <col span="1" style="width: 10%;"/>
                                <col span="1" style="width: 30%;"/>
                                <col span="1" style="width: 10%;"/>
                            </colgroup>
                            <tr>
                                <th>Movie Title</th>
                                <th>Release Date</th>
                                <th>Genre(s)</th>
                                <th>TMDb Rating</th>
                            </tr>
                            <%foreach (Movie movie in results.getMovies()) { %>
                                <tr>
                                    <th>
                                        <%=movie.Title%>
                                    </th>
                                    <th>
                                        <%if (movie.ReleaseDate != null)
                                        {%>
                                            <%=movie.ReleaseDate.Value.ToString("d") %>
                                        <%}%>
                                    </th>
                                    <th>
                                        <%=results.BuildGenreList(movie)%>
                                    </th>
                                    <th>
                                        <%=movie.VoteAverage%>
                                    </th>
                                </tr>
                            <% } %>
                       </table>
            <%  }