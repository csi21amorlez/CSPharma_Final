using DAL.DTOs;
using DAL.Models;

namespace CSPharma_FinalVersion.Models.Conversores
{
    public interface IToDto
    {
        DevolucionDTO DevolucionToDto(TdcCatEstadosDevolucionPedido devolucion);       

        EmpleadoDTO EmpleadoToDto(DlkCatAccEmpleado empleado);

        EnvioDTO EnvioToDto(TdcCatEstadosEnvioPedido envio);

        PagoDTO PagoToDto(TdcCatEstadosPagoPedido pago);

        LineasDTO LineasToDto(TdcCatLineasDistribucion lineas);

        PedidoDTO PedidoToDto(TdcCatEstadosEnvioPedido pedido);


    }
}
