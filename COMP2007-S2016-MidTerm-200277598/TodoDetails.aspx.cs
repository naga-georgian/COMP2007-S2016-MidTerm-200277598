using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_MidTerm_200277598.Models;

namespace COMP2007_S2016_MidTerm_200277598
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the grid from EF DB
            if (!IsPostBack)
            {
                // Get data
                this.GetTodo();
            }
             protected void GetTodo()
        {
            // connect to EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // query the Students table using EF and LINQ
                var Todo = (from allTodo in db.Todos
                                select allTodo);

                //bind the result to the GridView
                TodoGridView.DataSource = Todo.ToList();
                TodoGridView.DataBind();
            }

        }
    }
    }
}