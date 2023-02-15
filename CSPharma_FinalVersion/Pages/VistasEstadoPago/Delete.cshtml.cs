﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEstadoPago
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public DeleteModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TdcCatEstadosPagoPedido TdcCatEstadosPagoPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdcCatEstadosPagoPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadospagopedido = await _context.TdcCatEstadosPagoPedidos.FirstOrDefaultAsync(m => m.Id == id);

            if (tdccatestadospagopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosPagoPedido = tdccatestadospagopedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.TdcCatEstadosPagoPedidos == null)
            {
                return NotFound();
            }
            var tdccatestadospagopedido = await _context.TdcCatEstadosPagoPedidos.FindAsync(id);

            if (tdccatestadospagopedido != null)
            {
                TdcCatEstadosPagoPedido = tdccatestadospagopedido;
                _context.TdcCatEstadosPagoPedidos.Remove(TdcCatEstadosPagoPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
