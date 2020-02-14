using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.Model;
using TodoApi.Models;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace StudentInfoAPI.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        public DataTable retrieveStudentTable (int studentNumber)
        {
            // Setting up necessary strings
            string queryString = "SELECT * FROM Students WHERE StudentNumber=" + studentNumber.ToString();
            string connectionString = "Data Source=(local);Initial Catalog=Northwind; Integrated Security=true";

            // Creating SQL Connection
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            // Data Adapter
            SqlDataAdapter daStudents = new SqlDataAdapter(queryString, sqlConn);

            // DataSet
            DataSet studData = new DataSet("studData");
            daStudents.FillSchema(studData, SchemaType.Source, "Students");
            daStudents.Fill(studData, "Students");

            // Data Table to be returned
            DataTable studTable;
            studTable = studData.Tables["Students"];

            return studTable;
        }

        public DataTable retrieveSubjectsTable(int studentNumber)
        {
            // Setting up necessary strings
            string queryString = "SELECT * FROM Subjects WHERE StudentNumber=" + studentNumber.ToString();
            string connectionString = "Data Source=(local);Initial Catalog=Northwind; Integrated Security=true";

            // Creating SQL Connection
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            // Data Adapter
            SqlDataAdapter daStudents = new SqlDataAdapter(queryString, sqlConn);

            // DataSet
            DataSet studData = new DataSet("studData");
            daStudents.FillSchema(studData, SchemaType.Source, "Subjects");
            daStudents.Fill(studData, "Subjects");

            // Data Table to be returned
            DataTable studTable;
            studTable = studData.Tables["Subjects"];

            return studTable;
        }
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }


        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }

        public void makeConnectionAndRetrieve(string query)
        {

        }
    }
}
