using DAL.DTOs;
using DAL.Models;

namespace CSPharma_FinalVersion.Models.Conversores
{
    public class ToDtoImpl : IToDto
    {
        DevolucionDTO IToDto.DevolucionToDto(TdcCatEstadosDevolucionPedido devolucion)
        {
             devolucion.CodEstadoDevolucion
        }

        EmpleadoDTO IToDto.EmpleadoToDto(DlkCatAccEmpleado empleado)
        {
            throw new NotImplementedException();
        }

        EnvioDTO IToDto.EnvioToDto(TdcCatEstadosEnvioPedido envio)
        {
            throw new NotImplementedException();
        }

        LineasDTO IToDto.LineasToDto(TdcCatLineasDistribucion lineas)
        {
            throw new NotImplementedException();
        }

        PagoDTO IToDto.PagoToDto(TdcCatEstadosPagoPedido pago)
        {
            throw new NotImplementedException();
        }

        PedidoDTO IToDto.PedidoToDto(TdcCatEstadosEnvioPedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
