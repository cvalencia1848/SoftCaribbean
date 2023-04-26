using Microsoft.EntityFrameworkCore;

namespace SoftCaribbean.Models;

public partial class SoftCaribbeanContext : DbContext
{
    public SoftCaribbeanContext()
    {
    }

    public SoftCaribbeanContext(DbContextOptions<SoftCaribbeanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<MedicosTratante> MedicosTratantes { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SoftCaribbean;Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genero>(entity =>
        {
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Genero1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Genero");
        });

        modelBuilder.Entity<MedicosTratante>(entity =>
        {
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.Property(e => e.Arl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Condicion).HasColumnType("text");
            entity.Property(e => e.Eps)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

            entity.HasOne(d => d.IdMedicoTratanteNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdMedicoTratante)
                .HasConstraintName("FK_MedicoTratante");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK01_PacientesPersonas");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Foto)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoFijo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TelefonoFIjo");
            entity.Property(e => e.TelefonoMovil)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK_Genero");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK_TipoDocumento");
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.ToTable("TiposDocumento");

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
