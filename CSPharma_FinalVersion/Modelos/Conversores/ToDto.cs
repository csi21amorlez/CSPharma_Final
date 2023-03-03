using CSPharma_FinalVersion.Models.Lógica;
using Models.DTOs;
using DAL.Models;

namespace CSPharma_FinalVersion.Models.Conversores
{
    public class ToDto
    {
        #region Conversores individuales
        public static EstadoPedidoDTO EstadoPedidoToDto(TdcTchEstadoPedido pedido)
        {
            EstadoPedidoDTO dto = new EstadoPedidoDTO();

            dto.Id = pedido.Id;
            dto.CodPedido = pedido.CodPedido;
            dto.CodEstadoPago = pedido.CodEstadoPago;
            dto.CodEstadoEnvio = pedido.CodEstadoEnvio;
            dto.CodLinea = pedido.CodLinea;
            dto.CodEstadoDevolucion = pedido.CodEstadoDevolucion;

            return dto;
        }

        public static DevolucionDTO DevolucionToDto(TdcCatEstadosDevolucionPedido devolucion)
        {
            DevolucionDTO dto = new DevolucionDTO();

            dto.Id = devolucion.Id;
            dto.CodEstadoDevolucion = devolucion.CodEstadoDevolucion;
            dto.DesEstadoDevolucion = devolucion.DesEstadoDevolucion;

            return dto;
        }

        public static EmpleadoDTO EmpleadoToDto(DlkCatAccEmpleado empleado)
        {
            EmpleadoDTO dto = new EmpleadoDTO();

            dto.Id = empleado.Id;
            dto.CodEmpleado = empleado.CodEmpleado;
            dto.ClaveEmpleado = Encriptador.Desencriptar(empleado.ClaveEmpleado, "EstaEsLaStringParaEncriptarLasContraseñasYDemásDatosQueSeTienenQueOcultasPorqueSomosMuyProfesionales");
            dto.MdDate = empleado.MdDate;
            dto.MdUuid = empleado.MdUuid;
            dto.NivelAcceso = empleado.NivelAcceso;

            return dto;
        }

        public static EnvioDTO EnvioToDto(TdcCatEstadosEnvioPedido envio)
        {
            EnvioDTO dto = new EnvioDTO();

            dto.Id = envio.Id;
            dto.CodEstadoEnvio = envio.CodEstadoEnvio;
            dto.DesEstadoEnvio = envio.CodEstadoEnvio;

            return dto;
        }

        public static LineasDTO LineasToDto(TdcCatLineasDistribucion lineas)
        {
            LineasDTO dto = new LineasDTO();

            dto.Id = lineas.Id;
            dto.CodBarrio = lineas.CodBarrio;
            dto.CodLinea = lineas.CodLinea;
            dto.CodMunicipio = lineas.CodMunicipio;
            dto.CodProvincia = lineas.CodProvincia;

            return dto;
        }

        public static PagoDTO PagoToDto(TdcCatEstadosPagoPedido pago)
        {
            PagoDTO dto = new PagoDTO();

            dto.Id = pago.Id;
            dto.CodEstadoPago = pago.CodEstadoPago;
            dto.DesEstadoPago = pago.DesEstadoPago;

            return dto;
        }


        #endregion

        #region Conversores de listas



        public static List<DevolucionDTO> ListDevolucionToDto(IList<TdcCatEstadosDevolucionPedido> devoluciones)
        {
            List<DevolucionDTO> dto = new List<DevolucionDTO>();

            foreach (TdcCatEstadosDevolucionPedido devolucion in devoluciones)
                dto.Add(DevolucionToDto(devolucion));

            return dto;

        }

        public static List<EmpleadoDTO> ListEmpleadoToDto(IList<DlkCatAccEmpleado> empleados)
        {
            List<EmpleadoDTO> dto = new List<EmpleadoDTO>();

            foreach (DlkCatAccEmpleado empleado in empleados)
                dto.Add(EmpleadoToDto(empleado));

            return dto;
        }

        public static List<EnvioDTO> ListEnvioToDto(IList<TdcCatEstadosEnvioPedido> envios)
        {
            List<EnvioDTO> dto = new List<EnvioDTO>();

            foreach (TdcCatEstadosEnvioPedido envio in envios)
                dto.Add(EnvioToDto(envio));

            return dto;
        }

        public static List<EstadoPedidoDTO> ListEstadoPedidoToDto(IList<TdcTchEstadoPedido> pedidos)
        {
            List<EstadoPedidoDTO> dto = new List<EstadoPedidoDTO>();

            foreach (TdcTchEstadoPedido estadoPedido in pedidos)
                dto.Add(EstadoPedidoToDto(estadoPedido));

            return dto;
        }

        public static List<LineasDTO> ListLineasToDto(IList<TdcCatLineasDistribucion> lineas)
        {
            List<LineasDTO> dto = new List<LineasDTO>();

            foreach (TdcCatLineasDistribucion linea in lineas)
                dto.Add(LineasToDto(linea));

            return dto;
        }

        public static List<PagoDTO> ListPagoToDto(IList<TdcCatEstadosPagoPedido> pagos)
        {
            List<PagoDTO> dto = new List<PagoDTO>();

            foreach (TdcCatEstadosPagoPedido pago in pagos)
                dto.Add(PagoToDto(pago));

            return dto;
        }





        #endregion

    }
}
