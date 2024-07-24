using Microsoft.AspNetCore.Mvc.Rendering;
using Prescolaire.Models;

namespace Prescolaire.ViewModel
{
    public class MarkFilterViewModel
    {
        public int? SelectedClassId { get; set; }
        public int? SelectedStudentId { get; set; }
        public int? SelectedSchoolYearId { get; set; }
        public List<SelectListItem> Classes { get; set; }
        public List<SelectListItem> Students { get; set; }
        public List<SelectListItem> SchoolYears { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
    }
}
