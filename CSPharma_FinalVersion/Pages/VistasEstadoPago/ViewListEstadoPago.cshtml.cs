using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEstadoPago
{
    public class ViewListEstadoPagoModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public ViewListEstadoPagoModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatEstadosPagoPedidos != null)
            {
                TdcCatEstadosPagoPedido = await _context.TdcCatEstadosPagoPedidos.ToListAsync();
            }
        }
    }
}
