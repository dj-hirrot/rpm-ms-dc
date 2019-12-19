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
    public class IndexModel : PageModel
    {
        private readonly rpm_ms_dc.Data.RazorPageMovieContext _context;

        public IndexModel(rpm_ms_dc.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
