using DAL.DTOs;
using DAL.Models;
using CSPharma_FinalVersion.Models.Conversores;
using Microsoft.EntityFrameworkCore;

namespace CSPharma_FinalVersion.Models.Consultas
{
    public class ConsultasSelect
    {
        //Declaramos el contexto en global para usarlo en todos los metodos
        static CspharmaInformacionalContext context = new CspharmaInformacionalContext();

        public static List<EmpleadoDTO> FindAllEmpleados()
        {
            return ToDto.ListEmpleadoToDto(context.DlkCatAccEmpleados.ToList()); ;
        }

        public static List<DevolucionDTO> FindAllDevoluciones()
        {
            return ToDto.ListDevolucionToDto(context.TdcCatEstadosDevolucionPedidos.ToList());
        }

        public static List<EnvioDTO> FindAllEnvios()
        {
            return ToDto.ListEnvioToDto(context.TdcCatEstadosEnvioPedidos.ToList());
        }

        public static List<EstadoPedidoDTO> FindAllEstadoPedido()
        {
            return ToDto.ListEstadoPedidoToDto(context.TdcTchEstadoPedidos.ToList());
        }

        public  static List<LineasDTO> FindAllLineas()
        {
            return ToDto.ListLineasToDto(context.TdcCatLineasDistribucions.ToList());
        }

        public static List<PagoDTO> FindAllPagos()
        {
            return ToDto.ListPagoToDto(context.TdcCatEstadosPagoPedidos.ToList());
        }

    }
}
