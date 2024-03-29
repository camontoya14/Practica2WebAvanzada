﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Practica2WEB.Entidades;

namespace Practica2WEB.Services
{
    public interface IVendedorModel
    {
        public Respuesta? RegistrarVendedor(Vendedor entidad);

        public Vendedor? ConsultarVendedores();
    }
}
