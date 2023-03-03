using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using CSPharma_FinalVersion.Models.Conversores;
using Models.DTOs;

namespace CSPharma_FinalVersion.Pages.VistasEstadoLineasDistribucion
{
    public class IndexModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public IndexModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<LineasDTO> TdcCatLineasDistribucion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatLineasDistribucions != null)
            {
                TdcCatLineasDistribucion = ToDto.ListLineasToDto(await _context.TdcCatLineasDistribucions.ToListAsync());
            }
        }
    }
}
