using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieFinderApp.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        

        protected void Page_Load(object sender, EventArgs e)
        {

            string sortBy = Request.QueryString["sortBy"];
            if (sortBy != null && sortBy != "") //if sortby is not null, we already have results and we just need them sorted
            {                                   //so we dont have to worry about the search query
                if (sortBy.Equals("title"))
                {
                    sortByTitle();
                }
                if (sortBy.Equals("year"))
                {
                    sortByYear();
                }
                if (sortBy.Equals("rating"))
                {
                    sortByRating();
                }
            }
            else //else we are doing a search for the first time and need results, so lets get them!
            {
                if (Request.QueryString["searchTerm"] != null)
                {
                    string searchTerm = Request.QueryString["searchTerm"];

                    Session["searchTerm"] = searchTerm;

                    MovieFinder.getInstance().setCurrentSearchTerm(searchTerm);

                    BuildMovieList(searchTerm);
                }
            }

        }

        protected void Submitform(object sender, EventArgs e)
        {
            string searchTerm = "1234";

            Session["searchTerm"] = searchTerm;

            MovieFinder.getInstance().setCurrentSearchTerm(searchTerm);

            BuildMovieList(searchTerm);

            
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session has begun!");
        }

        protected void Session_eND(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session has ended!");
        }

        public async void BuildMovieList(string searchTerm)
        {
            MovieFinder mf = MovieFinder.getInstance();
            try
            {
                await mf.searchForMovieByTitle(searchTerm);
            } catch //Too many request exception
            {

            }
        }

        public void sortByTitle()
        {
            MovieSearchResult currentResults = MovieFinder.getInstance().getCurrentSearchResults();
            MovieSearchResult sortedResults = currentResults.sortByTitle();

            MovieFinder.getInstance().setCurrentSearchResults(sortedResults);

        }

        public void sortByYear()
        {
            MovieSearchResult currentResults = MovieFinder.getInstance().getCurrentSearchResults();
            MovieSearchResult sortedResults = currentResults.sortByYear();

            MovieFinder.getInstance().setCurrentSearchResults(sortedResults);

        }

        public void sortByRating()
        {
            MovieSearchResult currentResults = MovieFinder.getInstance().getCurrentSearchResults();
            MovieSearchResult sortedResults = currentResults.sortByRating();

            MovieFinder.getInstance().setCurrentSearchResults(sortedResults);

        }
    }
}