using DAL.DTOs;
using DAL.Models;

namespace CSPharma_FinalVersion.Models.Conversores
{
    public class ToDtoImpl
    {
        #region Conversores individuales
        EstadoPedidoDTO EstadoPedidoToDto(TdcTchEstadoPedido pedido)
        {
            EstadoPedidoDTO dto = new EstadoPedidoDTO();

            dto.CodPedido = pedido.CodPedido;
            dto.CodEstadoPago = pedido.CodEstadoPago;
            dto.CodEstadoEnvio = pedido.CodEstadoEnvio;
            dto.CodLinea = pedido.CodLinea;
            dto.CodEstadoDevolucion = pedido.CodEstadoDevolucion;

            return dto;
        }

        DevolucionDTO DevolucionToDto(TdcCatEstadosDevolucionPedido devolucion)
        {
            DevolucionDTO dto = new DevolucionDTO();

            dto.CodEstadoDevolucion = devolucion.CodEstadoDevolucion;
            dto.DesEstadoDevolucion = devolucion.DesEstadoDevolucion;

            return dto;
        }

        EmpleadoDTO EmpleadoToDto(DlkCatAccEmpleado empleado)
        {
            EmpleadoDTO dto = new EmpleadoDTO();

            dto.CodEmpleado = empleado.CodEmpleado;
            dto.ClaveEmpleado = empleado.ClaveEmpleado;
            dto.NivelAcceso = empleado.NivelAcceso;

            return dto;
        }

        EnvioDTO EnvioToDto(TdcCatEstadosEnvioPedido envio)
        {
            EnvioDTO dto = new EnvioDTO();

            dto.CodEstadoEnvio = envio.CodEstadoEnvio;
            dto.DesEstadoEnvio = envio.CodEstadoEnvio;

            return dto;
        }

        LineasDTO LineasToDto(TdcCatLineasDistribucion lineas)
        {
            LineasDTO dto = new LineasDTO();

            dto.CodBarrio = lineas.CodBarrio;
            dto.CodLinea = lineas.CodLinea;
            dto.CodMunicipio = lineas.CodMunicipio;
            dto.CodProvincia = lineas.CodProvincia;

            return dto;
        }

        PagoDTO PagoToDto(TdcCatEstadosPagoPedido pago)
        {
            PagoDTO dto = new PagoDTO();

            dto.CodEstadoPago = pago.CodEstadoPago;
            dto.DesEstadoPago = pago.DesEstadoPago;

            return dto;
        }


        #endregion

        #region Conversores de listas



        List<DevolucionDTO> ListDevolucionToDto(List<TdcCatEstadosDevolucionPedido> devoluciones)
        {
            List<DevolucionDTO> dto = new List<DevolucionDTO>();

            foreach (TdcCatEstadosDevolucionPedido devolucion in devoluciones)
                dto.Add(DevolucionToDto(devolucion));

            return dto;

        }

        List<EmpleadoDTO> ListEmpleadoToDto(List<DlkCatAccEmpleado> empleados)
        {
            List<EmpleadoDTO> dto = new List<EmpleadoDTO>();

            foreach (DlkCatAccEmpleado empleado in empleados)
                dto.Add(EmpleadoToDto(empleado));

            return dto;
        }

        List<EnvioDTO> ListEnvioToDto(List<TdcCatEstadosEnvioPedido> envios)
        {
            List<EnvioDTO> dto = new List<EnvioDTO>();

            foreach (TdcCatEstadosEnvioPedido envio in envios)
                dto.Add(EnvioToDto(envio));

            return dto;
        }

        List<EstadoPedidoDTO> ListEstadoPedidoToDto(List<TdcTchEstadoPedido> pedidos)
        {
            List<EstadoPedidoDTO> dto = new List<EstadoPedidoDTO>();

            foreach (TdcTchEstadoPedido estadoPedido in pedidos)
                dto.Add(EstadoPedidoToDto(estadoPedido));

            return dto;
        }

        List<LineasDTO> ListLineasToDto(List<TdcCatLineasDistribucion> lineas)
        {
            List<LineasDTO> dto = new List<LineasDTO>();

            foreach (TdcCatLineasDistribucion linea in lineas)
                dto.Add(LineasToDto(linea));

            return dto;
        }

        List<PagoDTO> ListPagoToDto(List<TdcCatEstadosPagoPedido> pagos)
        {
            List<PagoDTO> dto = new List<PagoDTO>();

            foreach (TdcCatEstadosPagoPedido pago in pagos)
                dto.Add(PagoToDto(pago));

            return dto;
        }





        #endregion

    }
}
