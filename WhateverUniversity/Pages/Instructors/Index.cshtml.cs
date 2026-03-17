using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WhateverUniversity.Data;
using WhateverUniversity.Models;

namespace WhateverUniversity.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly WhateverUniversity.Data.SchoolContext _context;

        public IndexModel(WhateverUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Instructor = await _context.Instructors.ToListAsync();
        }
    }
}
