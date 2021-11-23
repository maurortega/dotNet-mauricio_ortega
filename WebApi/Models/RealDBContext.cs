using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi.Models
{
    public partial class RealDBContext : DbContext
    {
        public RealDBContext()
        {
        }

        public RealDBContext(DbContextOptions<RealDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaEmpleado> MaEmpleados { get; set; }
        //private DbSet<MaEmpleado> _MaEmpleados = new MaEmpleadoDbSet();
        //public DbSet<MaEmpleado> MaEmpleados { 
        //    get => this._MaEmpleados; 
        //    //set => this._MaEmpleados = value; 
        //}

        //override 

        public virtual DbSet<TbArea> TbAreas { get; set; }
        public virtual DbSet<TbSubarea> TbSubareas { get; set; }
        public virtual DbSet<TbTipoDocumentoIdent> TbTipoDocumentoIdents { get; set; }

        private static string _ConnectionString;
        internal static string ConnectionString
        {
            get => _ConnectionString;
            set => _ConnectionString = value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(RealDBContext.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<MaEmpleado>(entity =>
            {
                entity.ToTable("ma_empleados");

                entity.HasIndex(e => e.Nombre1, "ma_empleados_idx01");

                entity.HasIndex(e => e.Nombre2, "ma_empleados_idx02");

                entity.HasIndex(e => e.Apellido1, "ma_empleados_idx03");

                entity.HasIndex(e => e.Apellido2, "ma_empleados_idx04");

                entity.HasIndex(e => new { e.DocIdentNumero, e.DocIdentTipo }, "ma_empleados_uk01")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.DocIdentNumero).HasColumnName("docIdentNumero");

                entity.Property(e => e.DocIdentTipo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("docIdentTipo")
                    .IsFixedLength(true);

                entity.Property(e => e.FechIns)
                    .HasColumnType("datetime")
                    .HasColumnName("fech_ins")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdSubArea).HasColumnName("idSubArea");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("nombre1");

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("nombre2");

                entity.HasOne(d => d.DocIdentTipoNavigation)
                    .WithMany(p => p.MaEmpleados)
                    .HasForeignKey(d => d.DocIdentTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ma_empleados_fk02");

                entity.HasOne(d => d.IdSubAreaNavigation)
                    .WithMany(p => p.MaEmpleados)
                    .HasForeignKey(d => d.IdSubArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ma_empleados_fk01");
            });

            modelBuilder.Entity<TbArea>(entity =>
            {
                entity.ToTable("tb_areas");

                entity.HasIndex(e => e.Nombre, "tb_areas_uk01")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FechaIns)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIns")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TbSubarea>(entity =>
            {
                entity.ToTable("tb_subareas");

                entity.HasIndex(e => e.IdArea, "tb_subareas_idx01");

                entity.HasIndex(e => new { e.IdArea, e.Nombre }, "tb_subareas_uk01")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FechaIns)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIns")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.InverseIdAreaNavigation)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_subareas_fk");
            });

            modelBuilder.Entity<TbTipoDocumentoIdent>(entity =>
            {
                entity.HasKey(e => e.Simbolo)
                    .HasName("tb_tipo_documento_ident_pk");

                entity.ToTable("tb_tipo_documento_ident");

                entity.Property(e => e.Simbolo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("simbolo")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaIns)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIns")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.HasSequence<decimal>("SEQ_NROPOLIZA")
                .StartsAt(3380435)
                .HasMin(-999999999999999999)
                .HasMax(999999999999999999);

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
