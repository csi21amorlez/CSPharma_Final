using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Models.DTOs;
using CSPharma_FinalVersion.Models.Conversores;

namespace CSPharma_FinalVersion.Pages.VistasEstadoLineasDistribucion
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public DeleteModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LineasDTO TdcCatLineasDistribucion { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdcCatLineasDistribucions == null)
            {
                return NotFound();
            }

            var tdccatlineasdistribucion = ToDto.LineasToDto(await _context.TdcCatLineasDistribucions.FirstOrDefaultAsync(m => m.Id == id));

            if (tdccatlineasdistribucion == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatLineasDistribucion = tdccatlineasdistribucion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.TdcCatLineasDistribucions == null)
            {
                return NotFound();
            }
            var tdccatlineasdistribucion = await _context.TdcCatLineasDistribucions.FindAsync(id);

            if (tdccatlineasdistribucion != null)
            {
                TdcCatLineasDistribucion = ToDto.LineasToDto(tdccatlineasdistribucion);
                _context.TdcCatLineasDistribucions.Remove(DtoTo.LineasDtoToDao(TdcCatLineasDistribucion));
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
