using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEstadoLineasDistribucion
{
    public class ViewListEstadoLineasDistribucionModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public ViewListEstadoLineasDistribucionModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<TdcCatLineasDistribucion> TdcCatLineasDistribucion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatLineasDistribucions != null)
            {
                TdcCatLineasDistribucion = await _context.TdcCatLineasDistribucions.ToListAsync();
            }
        }
    }
}
