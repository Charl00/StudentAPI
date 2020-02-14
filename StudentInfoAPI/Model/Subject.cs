using System;
namespace StudentInfoAPI.Model
{
    public class Subject
    {
        public long Id { get; set; }
        public string SubjectName { get; set; }
        public int TotalPoints { get; set; }
        public int StudentPoints { get; set; }
        public int StudentNumber { get; set; }
    }
}
