using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WhateverUniversity.Data;
using WhateverUniversity.Models;

namespace WhateverUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly WhateverUniversity.Data.SchoolContext _context;

        public IndexModel(WhateverUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        // Also need to sort by age
        public string AgeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Student> Students { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            //Need to sort ny age also
            AgeSort = sortOrder == "Age" ? "age_desc" : "Age";

            IQueryable<Student> studentsIQ = from s in _context.Students
                                            select s;

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "Age":
                    studentsIQ = studentsIQ.OrderBy(s => s.Age);
                    break;
                case "age_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.Age);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            Students = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
