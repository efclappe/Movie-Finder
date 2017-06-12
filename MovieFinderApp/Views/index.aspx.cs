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
            string sortBy = Request.QueryString["sortBy"] ;
            if (sortBy != null && sortBy != "") {
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
           
        }

        protected void Submitform(object sender, EventArgs e)
        {
            string searchTerm = SearchKeyword.Text;

            MovieFinder.getInstance().setCurrentSearchTerm(searchTerm);

            BuildMovieList(searchTerm);
           
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
            
            Response.Redirect(Request.RawUrl, false);
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