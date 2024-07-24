using Prescolaire.Models;

namespace Prescolaire.ViewModel
{
    public class StudentMarksViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public List<SubjectMark> SubjectMarks { get; set; }
        public string? Grade { get; set; }
        public double AverageMark { get; set; }
        public bool IsPassed { get; set; }

        public class SubjectMark
        {
            public string SubjectName { get; set; }
            public double? Mark1 { get; set; }
            public double? Mark2 { get; set; }
            public double? AverageSubejectMark { get; set; }
        }
    }

}
