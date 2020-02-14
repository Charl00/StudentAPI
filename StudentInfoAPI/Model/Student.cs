using System;
namespace StudentInfoAPI.Model
{
    public class Student
    {
        public long Id { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string ContactNumber { get; set; }
        public int StudentNumber { get; set; }
    }
}
