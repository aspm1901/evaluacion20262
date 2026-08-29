using TecnoGasHogar.Models;

namespace TecnoGasHogar.Data;

public static class DbInitializer
{
    public static void Initialize(TecnoGasContext context)
    {
        // Si ya existen registros, no se vuelve a poblar
        if (context.SolicitudesServicio.Any())
        {
            return;
        }

        var solicitudes = new SolicitudServicio[]
        {
            new SolicitudServicio
            {
                Cliente = "María Elena Flores",
                Telefono = "998877665",
                Distrito = "Miraflores",
                TipoServicio = "Instalación",
                Descripcion = "Instalación completa de terma a gas de 14 litros en departamento nuevo.",
                FechaRegistro = DateTime.Now.AddDays(-2).AddHours(3)
            },
            new SolicitudServicio
            {
                Cliente = "Carlos Rodríguez Vega",
                Telefono = "912345678",
                Distrito = "San Borja",
                TipoServicio = "Mantenimiento",
                Descripcion = "Mantenimiento preventivo y limpieza de cocina de 4 hornillas a gas natural.",
                FechaRegistro = DateTime.Now.AddDays(-1).AddHours(5)
            },
            new SolicitudServicio
            {
                Cliente = "Patricia Quispe Romero",
                Telefono = "987612345",
                Distrito = "Surco",
                TipoServicio = "Fuga",
                Descripcion = "Olor a gas cerca de la conexión de la terma en la lavandería. Atención urgente.",
                FechaRegistro = DateTime.Now.AddHours(-4)
            },
            new SolicitudServicio
            {
                Cliente = "Jorge Luis Huamán",
                Telefono = "955443322",
                Distrito = "Los Olivos",
                TipoServicio = "Revisión",
                Descripcion = "Revisión técnica de presión en tubería interna de gas natural Cálidda.",
                FechaRegistro = DateTime.Now.AddHours(-1)
            }
        };

        context.SolicitudesServicio.AddRange(solicitudes);
        context.SaveChanges();
    }
}
