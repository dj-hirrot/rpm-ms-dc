using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rpm_ms_dc.Data;
using rpm_ms_dc.Models;

namespace rpm_ms_dc.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly rpm_ms_dc.Data.RazorPageMovieContext _context;

        public DetailsModel(rpm_ms_dc.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
