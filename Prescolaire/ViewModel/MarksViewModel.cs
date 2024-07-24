using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prescolaire.ViewModel
{
    public class MarksViewModel
    {
        public int SelectedClassId { get; set; }
        public List<SelectListItem> Classes { get; set; }
        public List<StudentMarks> StudentsMarks { get; set; }

        public class StudentMarks
        {
            public int? StudentId { get; set; }
            public string StudentName { get; set; }
            public double? Mark1 { get; set; }
            public double? Mark2 { get; set; }
        }
    }

}
