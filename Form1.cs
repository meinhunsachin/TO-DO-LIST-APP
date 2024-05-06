using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }
        DataTable todoList = new DataTable();//create a datatable called todoList// this is going to store our data like columns,rows                                                                                                                                                                                        
        bool isEditing = false;// is going to be later on in the program for tracking when things being edited or not

        private void ToDoList_Load(object sender, EventArgs e)
        {
            // create columns and we are going to our reference our data table
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            //point our datagridview to our datasource (here remember our datagridview name like here toDoListView
            toDoListView.DataSource = todoList;
              //now our buttons actually work                      
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = ""; // our newButton function allow you to add something new and that just involve clearing out the text fields
            descriptionTextbox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // fill text fields with data from table

            titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextbox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try//there might be some weired bug or something where the user might misbehave and not clicked on something thats valid
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();// need to acces which row the user is currently clicked on 
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erroe" + ex);
            

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(isEditing)// if its true 
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"]=titleTextBox.Text;
                // set the title field inside of that row to whatever is currently set in the title.txt // updating an existing title
                 todoList.Rows[toDoListView.CurrentCell.RowIndex]["Descripion"] = descriptionTextbox.Text;
            }
            else // if not 
            {
                todoList.Rows.Add(titleTextBox.Text,descriptionTextbox.Text);// there is two columns so its going to store ....
            }
            // clear fields 
            titleTextBox.Text = "";
            descriptionTextbox.Text = "";
            isEditing = false; // because we are done wharever happened here 
        }
    }
}
              