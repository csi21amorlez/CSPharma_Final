using CSPharma_FinalVersion.Models.Conversores;
using DAL.DTOs;
using DAL.Models;

namespace CSPharma_FinalVersion.Models.Consultas
{
   
    public class ConsultasInsert
    {
        private CspharmaInformacionalContext context = new CspharmaInformacionalContext();
        public void InsertarEnvio(EnvioDTO envio)
        {            
            context.TdcCatEstadosEnvioPedidos.Add(DtoTo.EnvioDtoToDao(envio));
        }

        public void InsertarEmpleado(EmpleadoDTO empleado)
        {
            Console.WriteLine(empleado.CodEmpleado);
            context.DlkCatAccEmpleados.Add(DtoTo.EmpleadoDtoToDao(empleado));
        }

        public void InsertarDevolucion(DevolucionDTO devolucion)
        {
            context.TdcCatEstadosDevolucionPedidos.Add(DtoTo.DevolucionDtoToDao(devolucion));
        }

        public void InsertarLinea(LineasDTO linea)
        {
            context.TdcCatLineasDistribucions.Add(DtoTo.LineasDtoToDao(linea));
        }

        public void InsertarEstadoPedido(EstadoPedidoDTO estadoPedido)
        {
            context.TdcTchEstadoPedidos.Add(DtoTo.EstadoPedidoDtoToDao(estadoPedido));
        }

        public void InsertarEstadoPago(PagoDTO pago)
        {
            context.TdcCatEstadosPagoPedidos.Add(DtoTo.PagoDtoToDao(pago));
        }
    }
}
