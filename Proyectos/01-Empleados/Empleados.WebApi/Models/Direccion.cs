using System;
namespace Empleado.WebApi.Models
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroExtrerior { get; set; }
        public string NumeroInterior { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
    }
}