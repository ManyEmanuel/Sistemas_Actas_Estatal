using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<T_Municipio> Municipios { get; set; }
        public DbSet<T_Oficina> Oficinas { get; set; }
        public DbSet<T_Usuario> Usuarios { get; set; }
        public DbSet<T_Partido> Partidos { get; set; }
        public DbSet<T_Distrito> Distritos { get; set; }
        public DbSet<T_Demarcacion> Demarcaciones { get; set; }
        public DbSet<T_Seccion> Secciones { get; set; }
        public DbSet<T_Tipo_Eleccion> Tipos_Eleccion { get; set; }
        public DbSet<T_Tipo_Casilla> Tipos_Casilla { get; set; }
        public DbSet<T_Tipo_Acta> Tipos_Acta { get; set; }
        public DbSet<T_Casilla> Casillas { get; set; }
        public DbSet<T_Coalicion> Coaliciones { get; set; }
        public DbSet<Models.T_Detalle_Coalicion> Detalle_Coaliciones { get; set; }
        public DbSet<T_Candidato> Candidatos { get; set; }
        public DbSet<T_Combinacion> Combinaciones { get; set; }
        public DbSet<T_Detalle_Combinacion> Detalle_Combinacion { get; set; }
        public DbSet<T_Causal_Recuento> Causales_recuento { get; set; }
        public DbSet<T_Acta> Actas { get; set; }
        public DbSet<T_Acta_Detalle> Actas_Detalle { get; set; }
        public DbSet<T_Detalle_Votos_Acta> Detalle_Votos_Acta { get; set; }
        public DbSet<T_Detalle_Votos_Acta_Actor> Detalle_Votos_Acta_Actor { get; set; }
        public DbSet<T_Detalle_Votos_Acta_Partido> Detalle_Votos_Acta_Partido { get; set; }
        public DbSet<T_Estatus_Acta> Estatus_Acta { get; set; }
        public DbSet<T_Recepcion_Paquete> Recepcion_Paquete { get; set; }
        public DbSet<T_Votos_Acta> Votos_Actas { get; set; }
        public DbSet<T_Puntos_Recuento> Puntos_Recuento { get; set; }
        public DbSet<T_Detalle_Acta_Computo> Detalle_Acta_Computos { get; set; }
        public DbSet<T_Acta_Detalle_RP> Acta_Detalle_RP { get; set; }
        public DbSet<T_Acta_RP> Acta_RP { get; set; }
        public DbSet<T_Votos_Acta_RP> Votos_Acta_RP { get; set; }
        public DbSet<T_Detalle_Votos_Acta_RP> Detalle_Votos_Acta_RP { get; set; }
        public DbSet<T_Detalle_Acta_Computo_RP> Detalle_Acta_Computos_RP { get; set; }
        public DbSet<T_Acta_Extranjero> Acta_Extranjero { get; set; }
        public DbSet<T_Detalle_Votos_Ext> Detalle_Votos_Ext { get; set; }
        public DbSet<T_Votos_Acta_Ext> Votos_Actas_Ext { get; set; }
        public DbSet<T_HistorialSubsanar> HistorialSubsanar { get; set; }
        public DbSet<T_HistorialModificaciones> HistorialModificaciones { get; set; }
        public DbSet<T_HistoricoRestablecer>HistoricoRestablecer { get; set; }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<T_Municipio>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Oficina>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Partido>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Distrito>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Demarcacion>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Seccion>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Tipo_Eleccion>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Tipo_Casilla>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Tipo_Acta>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Casilla>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Coalicion>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<Models.T_Detalle_Coalicion>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Candidato>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Acta>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Acta_Detalle>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Detalle_Votos_Acta>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Detalle_Votos_Acta_Actor>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Detalle_Votos_Acta_Partido>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Estatus_Acta>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Recepcion_Paquete>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Votos_Acta>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Puntos_Recuento>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Acta_RP>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Votos_Acta_RP>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Detalle_Votos_Acta_RP>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_Detalle_Votos_Ext>().HasQueryFilter(x => x.Eliminado == false);
            builder.Entity<T_HistorialSubsanar>().HasQueryFilter(x => x.Eliminar == false);

            base.OnModelCreating(builder);
        }
    }
}
