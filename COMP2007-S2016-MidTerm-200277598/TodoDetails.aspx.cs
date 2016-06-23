using COMP2007_S2016_MidTerm_200277598.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/**
 @author: Naga Rimmalapudi
    @date: June 23,2016 
    @Website Name : http://comp2007midterm200277598.azurewebsites.net
    @This is a TodoDetail page. which will show specific todo if edited 
    or can insert new todo.
    @version = 1.0
*/


namespace COMP2007_S2016_MidTerm_200277598
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }
        protected void GetTodo()
        {
            // populate teh form with existing data from the database
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a Todo object instance with the TodoID from the URL Parameter
                Todo updatedTodo = (from Todos in db.Todos
                                    where Todos.TodoID == TodoID
                                    select Todos).FirstOrDefault();

                // map the Todo properties to the form controls
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
                    if (updatedTodo.Completed == true)
                    {
                        todoCheckBox.Checked = true;
                    }
                    else
                    {
                        todoCheckBox.Checked = false;
                    }
                }
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Todolist page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (TodoConnection db = new TodoConnection())
            {

                // save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0)
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current Todo from EF DB
                    newTodo = (from Todo in db.Todos
                               where Todo.TodoID == TodoID
                               select Todo).FirstOrDefault();
                }

                // add form data to new record
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                if (todoCheckBox.Checked == true)
                {
                    newTodo.Completed = todoCheckBox.Enabled;
                }
                else
                {
                    newTodo.Completed = false;
                }


                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();


                Response.Redirect("~/TodoList.aspx");
            }
        }


    }
}