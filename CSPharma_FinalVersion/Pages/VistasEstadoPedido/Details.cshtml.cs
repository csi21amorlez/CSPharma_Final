﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEstadoPedido
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public DetailsModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

      public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdctchestadopedido = await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);
            if (tdctchestadopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcTchEstadoPedido = tdctchestadopedido;
            }
            return Page();
        }
    }
}
