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
    public class DeleteModel : PageModel
    {
        private readonly rpm_ms_dc.Data.RazorPageMovieContext _context;

        public DeleteModel(rpm_ms_dc.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FindAsync(id);

            if (Movie != null)
            {
                _context.Movie.Remove(Movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
