using Harman.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harman.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Harman.Web.Data.Entities.Marca> Marca { get; set; }

        public DbSet<Harman.Web.Data.Entities.Ciudad> Ciudad { get; set; }

        public DbSet<Harman.Web.Data.Entities.Cargo> Cargo { get; set; }

        public DbSet<Harman.Web.Data.Entities.ClasificacionDeProducto> ClasificacionDeProducto { get; set; }

        public DbSet<Harman.Web.Data.Entities.ClasificacionSuplidor> ClasificacionSuplidor { get; set; }

        public DbSet<Harman.Web.Data.Entities.Compañia> Compañia { get; set; }

        public DbSet<Harman.Web.Data.Entities.DetallesDeVenta> DetallesDeVenta { get; set; }

        public DbSet<Harman.Web.Data.Entities.DetallesOrdenDeCompra> DetallesOrdenDeCompra { get; set; }

        public DbSet<Harman.Web.Data.Entities.Empleado> Empleado { get; set; }

        public DbSet<Harman.Web.Data.Entities.Estado> Estado { get; set; }

        public DbSet<Harman.Web.Data.Entities.Suplidor> Suplidor { get; set; }

        public DbSet<Harman.Web.Data.Entities.Pais> Pais { get; set; }

        public DbSet<Harman.Web.Data.Entities.Itbis> Itbis { get; set; }

        public DbSet<Harman.Web.Data.Entities.Vendedor> Vendedor { get; set; }

        public DbSet<Harman.Web.Data.Entities.Unidad> Unidad { get; set; }

        public DbSet<Harman.Web.Data.Entities.Moneda> Moneda { get; set; }

        public DbSet<Harman.Web.Data.Entities.TasaDeCambio> TasaDeCambio { get; set; }

        public DbSet<Harman.Web.Data.Entities.Venta> Venta { get; set; }

        public DbSet<Harman.Web.Data.Entities.Producto> Producto { get; set; }

        public DbSet<Harman.Web.Data.Entities.Tipo_De_Suplidor> Tipo_De_Suplidor { get; set; }

        public DbSet<Harman.Web.Data.Entities.TipoDeTransaccion> TipoDeTransaccion { get; set; }

        public DbSet<Harman.Web.Data.Entities.TipoDocumento> TipoDocumento { get; set; }

        public DbSet<Harman.Web.Data.Entities.Transportista> Transportista { get; set; }

        public DbSet<Harman.Web.Data.Entities.OrdenDeCompra> OrdenDeCompra { get; set; }

        public DbSet<Harman.Web.Data.Entities.ModoEnvio> ModoEnvio { get; set; }

        public DbSet<Harman.Web.Data.Entities.ModoDePago> ModoDePago { get; set; }

        public DbSet<Harman.Web.Data.Entities.Factura> Factura { get; set; }

}
}
