﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Models.DTOs;
using CSPharma_FinalVersion.Models.Conversores;

namespace CSPharma_FinalVersion.Pages.VistasEstadoEnvio
{
    public class IndexModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public IndexModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<EnvioDTO> TdcCatEstadosEnvioPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatEstadosEnvioPedidos != null)
            {
                TdcCatEstadosEnvioPedido = ToDto.ListEnvioToDto(await _context.TdcCatEstadosEnvioPedidos.ToListAsync());
            }
        }
    }
}
