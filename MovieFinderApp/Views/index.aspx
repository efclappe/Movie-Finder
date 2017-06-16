
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MovieFinderApp.View.WebForm1" Async="true" EnableEventValidation="false"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Finder</title>
    <link href="../CSS/moviefinder.css" rel="stylesheet" type="text/css" />
</head>
<body>    
    <h1 style="text-align:center">Movie Finder</h1>
    <div style="text-align: center; padding:20px" id="welcomeText">
            Hello. Enter a movie name to begin search.
    </div>
    <div id="searchBar" style="padding-top:20px; padding-bottom:50px; text-align:center">
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
</body>
    
</html>
<footer>
    <p>All information is retrieved from <a href="https://www.themoviedb.org/">The Movie Database</a>, using LordMike's c# Library <a href="https://github.com/LordMike/TMDbLib/">TMDbLib</a> </p>
</footer>
