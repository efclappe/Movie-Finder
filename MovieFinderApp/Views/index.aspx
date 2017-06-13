
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MovieFinderApp.View.WebForm1" Async="true" EnableEventValidation="false"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Finder</title>
    <link href="../CSS/moviefinder.css" rel="stylesheet" type="text/css" />
</head>
<body>    
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
    <div class="sidebar">
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
        <img src="https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4MTE5MjY5OV5BMl5BanBnXkFtZTcwNDEwMzUzMw@@._V1_.jpg" alt="this is a test" />
    </div>
</body>
</html>
