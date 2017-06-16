using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
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

        protected async void Page_Load(object sender, EventArgs e)
        {
        
            searchQuery = Request.Form["searchQuery"];

            filter = Request.Form["filter"];


            if (searchQuery != null && searchQuery != "")
            {
                Session["searchQuery"] = searchQuery;

                await BuildMovieListAsync(searchQuery, filter);
            }
            else
            {
                Response.Redirect("index.aspx", false); //search term was null or blank, go back to home page
            }
        }

        public async Task BuildMovieListAsync(string searchQuery, string filter)
        {
            try
            {
                await mf.searchForMovieByTitle(searchQuery, filter);
             }
            catch (TMDbLib.Objects.Exceptions.RequestLimitExceededException)
            {
                Response.Redirect("TooManyRequestsError.html", false);
            }



        }
    }
}