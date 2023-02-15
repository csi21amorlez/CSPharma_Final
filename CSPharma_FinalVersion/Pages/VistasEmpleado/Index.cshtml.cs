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
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public IndexModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<DlkCatAccEmpleado> DlkCatAccEmpleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DlkCatAccEmpleados != null)
            {
                DlkCatAccEmpleado = await _context.DlkCatAccEmpleados.ToListAsync();
            }
        }
    }
}
