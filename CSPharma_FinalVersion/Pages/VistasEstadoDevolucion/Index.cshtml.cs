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

namespace CSPharma_FinalVersion.Pages.VistasEstadoDevolucion
{
    public class IndexModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public IndexModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<DevolucionDTO> TdcCatEstadosDevolucionPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatEstadosDevolucionPedidos != null)
            {
                TdcCatEstadosDevolucionPedido = ToDto.ListDevolucionToDto(await _context.TdcCatEstadosDevolucionPedidos.ToListAsync());
            }
        }
    }
}
