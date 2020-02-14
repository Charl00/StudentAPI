using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace StudentInfoAPI.Model
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}