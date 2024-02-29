using Practica2WEB.Entidades;

namespace Practica2WEB.Services
{
    public interface IVehiculoModel
    {
        public Respuesta? RegistrarVehiculo(Vehiculo entidad);
    }
}
