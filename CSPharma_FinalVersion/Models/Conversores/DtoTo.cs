using DAL.DTOs;
using DAL.Models;

namespace CSPharma_FinalVersion.Models.Conversores
{
    public class DtoTo
    {
        #region Conversores individuales

        public static DlkCatAccEmpleado EmpleadoDtoToDao(EmpleadoDTO dto)
        {
            DlkCatAccEmpleado empleado = new DlkCatAccEmpleado();

            empleado.MdUuid = Guid.NewGuid().ToString();
            empleado.MdDate = DateTime.Now;
            empleado.CodEmpleado = dto.CodEmpleado;
            empleado.ClaveEmpleado = dto.ClaveEmpleado;

            return empleado;
        }

        public static TdcCatEstadosDevolucionPedido DevolucionDtoToDao(DevolucionDTO dto)
        {
            TdcCatEstadosDevolucionPedido devolucion = new TdcCatEstadosDevolucionPedido();

            devolucion.MdUuid = Guid.NewGuid().ToString();
            devolucion.MdDate = DateTime.Now;
            devolucion.CodEstadoDevolucion = dto.CodEstadoDevolucion;
            devolucion.DesEstadoDevolucion = dto.DesEstadoDevolucion;

            return devolucion;
        }

        public static TdcCatEstadosEnvioPedido EnvioDtoToDao(EnvioDTO dto)
        {
            TdcCatEstadosEnvioPedido envio = new TdcCatEstadosEnvioPedido();

            envio.MdUuid = Guid.NewGuid().ToString();
            envio.MdDate = DateTime.Now;
            envio.DesEstadoEnvio = dto.DesEstadoEnvio;
            envio.CodEstadoEnvio = dto.CodEstadoEnvio;

            return envio;
        }

        public static TdcCatEstadosPagoPedido PagoDtoToDao(PagoDTO dto)
        {
            TdcCatEstadosPagoPedido pago = new TdcCatEstadosPagoPedido();

            pago.MdUuid = Guid.NewGuid().ToString();
            pago.MdDate = DateTime.Now;
            pago.DesEstadoPago = dto.DesEstadoPago;
            pago.CodEstadoPago = dto.DesEstadoPago;

            return pago;

        }

        public static TdcCatLineasDistribucion LineasDtoToDao(LineasDTO dto)
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

        public static TdcTchEstadoPedido EstadoPedidoDtoToDao(EstadoPedidoDTO dto)
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

        public static List<TdcCatEstadosDevolucionPedido> ListDevolucionDtoToDao(List<DevolucionDTO> dto)
        {
            List<TdcCatEstadosDevolucionPedido> listDevoluciones = new List<TdcCatEstadosDevolucionPedido>();

            foreach (DevolucionDTO item in dto)
            {
                listDevoluciones.Add(DevolucionDtoToDao(item));
            }

            return listDevoluciones;
        }

        public static List<TdcTchEstadoPedido> ListPedidosDtoToDao(List<EstadoPedidoDTO> dto)
        {
            List<TdcTchEstadoPedido> listEstadoPedidos = new List<TdcTchEstadoPedido>();

            foreach (EstadoPedidoDTO item in dto)
            {
                listEstadoPedidos.Add(EstadoPedidoDtoToDao(item));
            }

            return listEstadoPedidos;
        }

        public static List<TdcCatLineasDistribucion> ListLineasDtoToDao(List<LineasDTO> dto)
        {
            List<TdcCatLineasDistribucion> listLineas = new List<TdcCatLineasDistribucion>();

            foreach (LineasDTO item in dto)
            {
                listLineas.Add(LineasDtoToDao(item));
            }

            return listLineas;

        }

        public static List<DlkCatAccEmpleado> ListEmpleadoDtoToDao(List<EmpleadoDTO> dto)
        {
            List<DlkCatAccEmpleado> listEmpleados = new List<DlkCatAccEmpleado>();

            foreach (EmpleadoDTO item in dto)
            {
                listEmpleados.Add(EmpleadoDtoToDao(item));
            }

            return listEmpleados;

        }

        public static List<TdcCatEstadosPagoPedido> ListEstadoPagoDtoToDao(List<PagoDTO> dto)
        {
            List<TdcCatEstadosPagoPedido> listEstadoPago = new List<TdcCatEstadosPagoPedido>();

            foreach (PagoDTO item in dto)
            {
                listEstadoPago.Add(PagoDtoToDao(item));
            }

            return listEstadoPago;
        }

        public static List<TdcCatEstadosEnvioPedido> ListEnvioDtoToDao(List<EnvioDTO> dto)
        {
            List<TdcCatEstadosEnvioPedido> listEnvios = new List<TdcCatEstadosEnvioPedido>();

            foreach (EnvioDTO item in dto)
            {
                listEnvios.Add(EnvioDtoToDao(item));
            }

            return listEnvios;
        }


        #endregion 


    }
}
