using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_MidTerm_200277598.Models;
using System.Web.ModelBinding;

namespace COMP2007_S2016_MidTerm_200277598
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void GetTodo()
        {
            // populate the form with existing todo data from the db
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a student instance with the TodoID from the URL parameter
                Todo updatedTodo = (from Todo in db.Todos
                                          where Todo.TodoID == TodoID
                                          select Todo).FirstOrDefault();

                // map the student properties to the form controls
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;

                }
            }
        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (TodoConnection db = new TodoConnection())
            {
                // use the Student model to create a new Todo object and
                // save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0)
                {
                    // get the id from url
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current Todo from EF DB
                    newTodo = (from Todo in db.Todos
                                  where Todo.TodoID == TodoID
                                  select Todo).FirstOrDefault();
                }

                // add form data to the new Todo record
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                

                // use LINQ to ADO.NET to add / insert new student into the database

                // check to see if a new student is being added
                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes - run an update
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}

