﻿using Microsoft.EntityFrameworkCore;
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
                .WithMany(p => p.PostsDeFeed)
                .HasForeignKey(pf => pf.IDdePost);

            modelBuilder.Entity<Evento>()
                .ToTable("Evento")
                .HasKey(e => e.ID);

            modelBuilder.Entity<Post_Evento>()
                .ToTable("Post_Evento")
                .HasKey(pe => new { pe.IDdePost, pe.IDdeEvento });

            modelBuilder.Entity<Post_Evento>()
                .HasOne(pe => pe.post)
                .WithMany(p => p.PostsDeEvento)
                .HasForeignKey(pe => pe.IDdePost);

            modelBuilder.Entity<Post_Banda>()
                .ToTable("Post_Banda")
                .HasKey(pb => pb.IDdePost);

            modelBuilder.Entity<Comentario>()
                .ToTable("Comentario")
                .HasKey(c => c.ID);

            modelBuilder.Entity<Comentario>()
            .HasOne(c => c.post)
            .WithMany(p => p.Comentarios)
            .HasForeignKey(c => c.IDdePost); 



        }
    }

}
