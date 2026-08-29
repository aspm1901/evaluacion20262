using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Models;

namespace TecnoGasHogar.Data;

public class TecnoGasContext : DbContext
{
    public TecnoGasContext(DbContextOptions<TecnoGasContext> options) : base(options)
    {
    }

    public DbSet<SolicitudServicio> SolicitudesServicio => Set<SolicitudServicio>();
}
