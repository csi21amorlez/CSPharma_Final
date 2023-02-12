using DAL.DTOs;
using DAL.Models;

namespace CSPharma_FinalVersion.Models.Conversores
{
    public class DtoTo
    {
        #region Conversores individuales

        public DlkCatAccEmpleado EmpleadoDtoToDao(EmpleadoDTO dto)
        {
            DlkCatAccEmpleado empleado = new DlkCatAccEmpleado();

            empleado.MdUuid = Guid.NewGuid().ToString();
            empleado.MdDate = DateTime.Now;
            empleado.CodEmpleado = dto.CodEmpleado;
            empleado.ClaveEmpleado = dto.ClaveEmpleado;

            return empleado;
        }

        public TdcCatEstadosDevolucionPedido DevolucionDtoToDao(DevolucionDTO dto)
        {
            TdcCatEstadosDevolucionPedido devolucion = new TdcCatEstadosDevolucionPedido();

            devolucion.MdUuid = Guid.NewGuid().ToString();
            devolucion.MdDate = DateTime.Now;
            devolucion.CodEstadoDevolucion = dto.CodEstadoDevolucion;
            devolucion.DesEstadoDevolucion = dto.DesEstadoDevolucion;

            return devolucion;
        }

        public TdcCatEstadosEnvioPedido EnvioDtoToDao(EnvioDTO dto)
        {
            TdcCatEstadosEnvioPedido envio = new TdcCatEstadosEnvioPedido();

            envio.MdUuid = Guid.NewGuid().ToString();
            envio.MdDate = DateTime.Now;
            envio.DesEstadoEnvio = dto.DesEstadoEnvio;
            envio.CodEstadoEnvio = dto.CodEstadoEnvio;

            return envio;
        }

        public TdcCatEstadosPagoPedido PagoDtoToDao(PagoDTO dto)
        {
            TdcCatEstadosPagoPedido pago = new TdcCatEstadosPagoPedido();

            pago.MdUuid = Guid.NewGuid().ToString();
            pago.MdDate = DateTime.Now;
            pago.DesEstadoPago = dto.DesEstadoPago;
            pago.CodEstadoPago = dto.DesEstadoPago;

            return pago;

        }

        public TdcCatLineasDistribucion LineasDtoToDao(LineasDTO dto)
        {
            TdcCatLineasDistribucion lineas = new TdcCatLineasDistribucion();

            lineas.MdUuid = Guid.NewGuid().ToString();
            lineas.MdDate = DateTime.Now;
            lineas.CodLinea = dto.CodLinea;
            lineas.CodBarrio = dto.CodBarrio;
            lineas.CodProvincia = dto.CodProvincia;
            lineas.CodMunicipio = dto.CodMunicipio;

            return lineas;


        }

        public TdcTchEstadoPedido EstadoPedidoDtoToDao(EstadoPedidoDTO dto)
        {
            TdcTchEstadoPedido estadoPedido = new TdcTchEstadoPedido();

            estadoPedido.MdUuid = Guid.NewGuid().ToString();
            estadoPedido.MdDate = DateTime.Now;
            estadoPedido.CodLinea = dto.CodLinea;
            estadoPedido.CodEstadoPago = dto.CodEstadoPago;
            estadoPedido.CodEstadoEnvio = dto.CodEstadoEnvio;
            estadoPedido.CodPedido = dto.CodPedido;
            estadoPedido.CodEstadoDevolucion = dto.CodEstadoDevolucion;

            return estadoPedido;
        
        }





        #endregion

        #region Conversores de listas


        #endregion 


    }
}
