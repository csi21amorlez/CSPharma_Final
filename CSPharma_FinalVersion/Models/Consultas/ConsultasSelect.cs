using DAL.DTOs;
using DAL.Models;
using CSPharma_FinalVersion.Models.Conversores;
using Microsoft.EntityFrameworkCore;

namespace CSPharma_FinalVersion.Models.Consultas
{
    public class ConsultasSelect
    {
        //Declaramos el contexto en global para usarlo en todos los metodos
        CspharmaInformacionalContext context = new CspharmaInformacionalContext();

        public List<EmpleadoDTO> FindAllEmpleados()
        {
            return ToDto.ListEmpleadoToDto(context.DlkCatAccEmpleados.ToList()); ;
        }

        public List<DevolucionDTO> FindAllDevoluciones()
        {
            return ToDto.ListDevolucionToDto(context.TdcCatEstadosDevolucionPedidos.ToList());
        }

        public List<EnvioDTO> FindAllEnvios()
        {
            return ToDto.ListEnvioToDto(context.TdcCatEstadosEnvioPedidos.ToList());
        }

        public List<EstadoPedidoDTO> FindAllEstadoPedido()
        {
            return ToDto.ListEstadoPedidoToDto(context.TdcTchEstadoPedidos.ToList());
        }

        public List<LineasDTO> FindAllLineas()
        {
            return ToDto.ListLineasToDto(context.TdcCatLineasDistribucions.ToList());
        }

        public List<PagoDTO> FindAllPagos()
        {
            return ToDto.ListPagoToDto(context.TdcCatEstadosPagoPedidos.ToList());
        }

    }
}
