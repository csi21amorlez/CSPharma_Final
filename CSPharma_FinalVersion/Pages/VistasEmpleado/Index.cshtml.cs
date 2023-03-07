using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class IndexModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public IndexModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        public IList<DlkCatAccEmpleado> DlkCatAccEmpleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DlkCatAccEmpleados != null)
            {
                DlkCatAccEmpleado = await _context.DlkCatAccEmpleados
                .Include(d => d.NivelAccesoNavigation).ToListAsync();
            }
        }
    }
}
