using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieFinderApp.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

            await mf.searchForMovieByTitle(searchTerm);

            Response.Redirect("Results.aspx");
        }
    }
}