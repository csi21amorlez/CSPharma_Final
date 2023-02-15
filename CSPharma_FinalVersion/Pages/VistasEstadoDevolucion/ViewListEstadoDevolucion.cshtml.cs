using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.DTOs;


namespace CSPharma_FinalVersion.Pages.VistasEstadoDevolucion
{
    public class ViewListEstadoDevolucionModel : PageModel
    {
        public IList<DevolucionDTO> TdcCatEstadosDevolucionPedido { get; set; } = default!;

        public async Task OnGetAsync()
        {


            //TdcCatEstadosDevolucionPedido = ConsultasSelect.FindAllDevoluciones();

        }
    }
}
