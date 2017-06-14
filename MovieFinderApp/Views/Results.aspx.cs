using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMDbLib.Objects.Search;

namespace MovieFinderApp.View
{
    public partial class results : System.Web.UI.Page
    {
        protected MovieFinder mf = new MovieFinder();

        protected string searchQuery = "";

        protected string filter = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        
            searchQuery = Request.Form["searchQuery"];

            string filter = Request.Form["filter"];

            if (searchQuery != null && searchQuery != "")
            {
                Session["searchQuery"] = searchQuery;

                BuildMovieList(searchQuery, filter);
            }
            else
            {
                Response.Redirect("index.aspx", true); //search term was null or blank, go back to home page
            }  
        }

        public async void BuildMovieList(string searchQuery, string filter)
        {
             try
            {
                await mf.searchForMovieByTitle(searchQuery);
            }
            catch //Too many request exception?
            {

            }

            if (filter != null && filter != "") //sort the results
            {
                switch (filter)
                {
                    case "relevance":
                        break; //default, no sorting required

                    case "title":
                        sortByTitle();
                        break;

                    case "year":
                        sortByYear();
                        break;

                    case "rating":
                        sortByRating();
                        break;

                    default:
                        Response.Redirect("error.aspx", true); //invalid search parameter, error out
                        break;
                }
            }
            else
            {
                Response.Redirect("error.aspx", false); // sort parameter was probably blank or not specified
            }

        }


        public void sortByTitle()
        {
            MovieSearchResult currentResults = mf.getCurrentSearchResults();
            MovieSearchResult sortedResults = currentResults.sortByTitle();

            mf.setCurrentSearchResults(sortedResults);

        }

        public void sortByYear()
        {
            MovieSearchResult currentResults = mf.getCurrentSearchResults();
            MovieSearchResult sortedResults = currentResults.sortByYear();

            mf.setCurrentSearchResults(sortedResults);

        }

        public void sortByRating()
        {
            MovieSearchResult currentResults = mf.getCurrentSearchResults();
            MovieSearchResult sortedResults = currentResults.sortByRating();

            mf.setCurrentSearchResults(sortedResults);

        }
    }
}