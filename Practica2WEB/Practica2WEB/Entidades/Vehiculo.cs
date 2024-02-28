namespace Practica2WEB.Entidades
{
    public class Vehiculo
    {
        public long IdVehiculo { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Color { get; set; }
        public double Precio { get; set; }
        public long? IdVendedor { get; set; }
    }
}
