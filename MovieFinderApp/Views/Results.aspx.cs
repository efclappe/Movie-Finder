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
        public MovieFinder mf = new MovieFinder();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Request.RawUrl);

            NameValueCollection queryParameters = Request.QueryString;

            string searchTerm = Request.Form["TextBox1"];

            if (searchTerm != null && searchTerm != "")
            {
                Session["searchTerm"] = searchTerm;

                mf.setCurrentSearchTerm(searchTerm);

                BuildMovieList(searchTerm);
            }
            else
            {
                Response.Redirect("index.aspx", true); //search term was null or blank, go back to home page
            }

            string sortBy = queryParameters["sortBy"];

            if (sortBy != null && sortBy != "") //sort the results
            {                                   
                switch (sortBy)
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
                //Response.Redirect("error.aspx", false); // sort parameter was probably blank or not specified
            }
        }

        public async void BuildMovieList(string searchTerm)
        {
             try
            {
                await mf.searchForMovieByTitle(searchTerm);
            }
            catch //Too many request exception
            {

            }
        }

        public void test()
        {
            System.Diagnostics.Debug.WriteLine("test");
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