using Microsoft.EntityFrameworkCore;
using StockPriceMicroservice.Models.SqlServer;

namespace StockPriceMicroservice.Data
{
    public class ContextSqlServer : DbContext
    {
        public ContextSqlServer(DbContextOptions<ContextSqlServer> options) : base (options) 
        { 
        
        } 
        
        public DbSet<WebSocketConnection> WebSocketConnections { get; set; }
        public DbSet<TrackedSymbols> TrackedSymbols { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            // Configuración para la tabla TrackedSymbols
            modelBuilder.Entity<TrackedSymbols>()
                .HasIndex(ts => new { ts.ConnectionId, ts.Symbol })
                .IsUnique();  // Asegura que cada símbolo sea único por conexión

            // Si quieres hacer la configuración de la clave foránea también, la puedes agregar aquí:
            modelBuilder.Entity<TrackedSymbols>()
                .HasOne(ts => ts.WebSocketConnection)
                .WithMany() // Esto asume que no necesitas una colección de TrackedSymbols en WebSocketConnection
                .HasForeignKey(ts => ts.ConnectionId);
        }




    }
}
