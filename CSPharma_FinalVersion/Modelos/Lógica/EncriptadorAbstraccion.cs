using CSPharma_FinalVersion.Models.Lógica;

namespace CSPharma_FinalVersion.Modelos.Lógica
{
    public class EncriptadorAbstraccion
    {
        private const string KEY = "c2VjcmV0RGF0YQ==";
        public static string Encriptar(String dato)
        {
            return Encriptador.Encriptar(dato,KEY);

        }

        public static string Desencriptar(String dato)
        {
            return Encriptador.Desencriptar(dato, KEY);
        }
    }
}
