using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasPedido
{
    public class IndexModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public IndexModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        public IList<TdcTchEstadoPedido> TdcTchEstadoPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                if (_context.TdcTchEstadoPedidos != null)
                {//Enviamos la informacion de los campos referenciados
                    TdcTchEstadoPedido = await _context.TdcTchEstadoPedidos
                    .Include(t => t.CodEstadoDevolucionNavigation)
                    .Include(t => t.CodEstadoEnvioNavigation)
                    .Include(t => t.CodEstadoPagoNavigation)
                    .Include(t => t.CodLineaNavigation).ToListAsync();
                }
            }catch (Exception ex)
            {
                Redirect("../Error");
            }
           
        }
    }
}
