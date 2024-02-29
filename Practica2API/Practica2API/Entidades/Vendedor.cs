namespace Practica2API.Entidades
{
    public class Vendedor
    {
        public long IdVendedor { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre{ get; set; }
        public string? Correo { get; set; }
        public bool Estado { get; set; }
    }
}
