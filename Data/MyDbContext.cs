using Microsoft.EntityFrameworkCore;
using Api_Post_Eventos_Vfinal.Models;

namespace Api_Post_Eventos_Vfinal.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Post { get; set; }
        public DbSet<Post_Feed> PostFeed { get; set; }
        public DbSet<Post_Banda> PostBanda { get; set; }
        public DbSet<Post_Evento> PostEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Comentario> Comentario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // claves

            modelBuilder.Entity<Post>()
            .ToTable("Post")
            .HasKey(p => p.ID);
            
            modelBuilder.Entity<Post_Feed>()
            .ToTable("Post_Feed")
            .HasKey(pf => pf.IDdePost); 

            modelBuilder.Entity<Post_Feed>()
                .HasOne(pf => pf.post) 
                .WithOne() 
                .HasForeignKey<Post_Feed>(pf => pf.IDdePost);
            
            modelBuilder.Entity<Post_Banda>()
            .ToTable("Post_Banda")
            .HasKey(pf => pf.IDdePost);

            modelBuilder.Entity<Post_Banda>()
                .HasOne(pf => pf.post)
                .WithOne()
                .HasForeignKey<Post_Banda>(pf => pf.IDdePost);
            
            modelBuilder.Entity<Post_Evento>()
            .ToTable("Post_Evento")
            .HasKey(pf => pf.IDdePost);

            modelBuilder.Entity<Post_Evento>()
                .HasOne(pf => pf.post)
                .WithOne()
                .HasForeignKey<Post_Evento>(pf => pf.IDdePost);

            /* modelBuilder.Entity<Post_Feed>()
                 .HasOne(pf => pf.Cuenta)
                 .WithMany()
                 .HasForeignKey(pf => pf.IDdeCuenta);*/

            /* modelBuilder.Entity<Post_Banda>()
                 .HasOne(pb => pb.Cuenta)
                 .WithMany()
                 .HasForeignKey(pb => pb.IDdeCuenta);*/

            /* modelBuilder.Entity<Post_Banda>()
                 .HasOne(pb => pb.Banda)
                 .WithMany()
                 .HasForeignKey(pb => pb.IDdeBanda);*/

            /* modelBuilder.Entity<Post_Evento>()
                 .HasOne(pe => pe.Cuenta)
                 .WithMany()
                 .HasForeignKey(pe => pe.IDdeCuenta);*/

            modelBuilder.Entity<Post_Evento>()
                .HasOne(pe => pe.Evento)
                .WithMany()
                .HasForeignKey(pe => pe.IDdeEvento);



        }
    }

}
