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
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // connect to EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // use the student model to save a new record
                Todo newTodo = new Todo();

                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                

                // adds a new studdent to the Student Table collection
                db.Todos.Add(newTodo);

                // run insert in DB
                db.SaveChanges();

                // redirect to the updated students page
                Response.Redirect("~/TodoList.aspx");
            }
        }
}