using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_spmedgroup_webAPI.Domains;

#nullable disable

namespace senai_spmedgroup_webAPI.Contexts
{
    public partial class SpMedGroupContext : DbContext
    {
        public SpMedGroupContext()
        {
        }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2J57S36\\SQLEXPRESS; initial catalog=SP_MEDICAL_GROUP; user id=sa; pwd=123;");
                ///optionsBuilder.UseSqlServer("Data Source=NOTE0113A1\\SQLEXPRESS; initial catalog=SP_MEDICAL_GROUP_MANHA; user id=sa; pwd=Senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__CLINICA__C73A6055FDC10ECA");

                entity.ToTable("CLINICA");

                entity.HasIndex(e => e.EnderecoClinica, "UQ__CLINICA__229F2191695CE9EE")
                    .IsUnique();

                entity.HasIndex(e => e.CnpjClinica, "UQ__CLINICA__BC8E35E2498D966F")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasiaClinica, "UQ__CLINICA__FA561938CC2135D6")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.CnpjClinica)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpjClinica");

                entity.Property(e => e.EnderecoClinica)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("enderecoClinica");

                entity.Property(e => e.HorarioAbreClinica).HasColumnName("horarioAbreClinica");

                entity.Property(e => e.HorarioFechaClinica).HasColumnName("horarioFechaClinica");

                entity.Property(e => e.NomeFantasiaClinica)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasiaClinica");

                entity.Property(e => e.RazaoSocialClinica)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocialClinica");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__CONSULTA__CA9C61F521E8EC8D");

                entity.ToTable("CONSULTA");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("situacao");

                entity.Property(e => e.Valor)
                    .HasColumnType("money")
                    .HasColumnName("valor")
                    .HasDefaultValueSql("('50.00')");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__CONSULTA__idMedi__403A8C7D");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__CONSULTA__idPaci__412EB0B6");

                entity.HasOne(d => d.SituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Situacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONSULTA__situac__4222D4EF");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__ESPECIAL__409698056F9DE146");

                entity.ToTable("ESPECIALIDADE");

                entity.HasIndex(e => e.NomeEspeci, "UQ__ESPECIAL__37FD43E36C19D4F0")
                    .IsUnique();

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.NomeEspeci)
                    .IsRequired()
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("nomeEspeci");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__MEDICO__4E03DEBAB825495A");

                entity.ToTable("MEDICO");

                entity.HasIndex(e => e.CrmMed, "UQ__MEDICO__FB6D4A9D54EB3E97")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.CrmMed)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("crmMed");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.NomeMed)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeMed");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__MEDICO__email__36B12243");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__MEDICO__idClinic__34C8D9D1");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__MEDICO__idEspeci__35BCFE0A");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__PACIENTE__F48A08F2F35B0073");

                entity.ToTable("PACIENTE");

                entity.HasIndex(e => e.RgPac, "UQ__PACIENTE__1F060BFAEDDAC277")
                    .IsUnique();

                entity.HasIndex(e => e.CpfPac, "UQ__PACIENTE__B8CF100C4913779D")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.CpfPac)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpfPac");

                entity.Property(e => e.DataNascPac)
                    .HasColumnType("date")
                    .HasColumnName("dataNascPac");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EnderecoPac)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("enderecoPac");

                entity.Property(e => e.NomePac)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomePac");

                entity.Property(e => e.RgPac)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rgPac");

                entity.Property(e => e.TelefonePac)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefonePac");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__PACIENTE__email__3B75D760");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.Situacao1)
                    .HasName("PK__SITUACAO__52F4F1205A8C7207");

                entity.ToTable("SITUACAO");

                entity.Property(e => e.Situacao1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("situacao");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.Sigla)
                    .HasName("PK__TIPOUSUA__3C47D518F24A36F8");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__TIPOUSUA__A9585C05F51A5E6A")
                    .IsUnique();

                entity.Property(e => e.Sigla)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("sigla");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__USUARIO__AB6E61652A1D5AB5");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.NomeUsuario, "UQ__USUARIO__8C9D1DE5600F71A9")
                    .IsUnique();

                entity.HasIndex(e => e.SenhaUsuario, "UQ__USUARIO__F03EFC5733225031")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.SenhaUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("senhaUsuario");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("sigla");

                entity.HasOne(d => d.SiglaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Sigla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__sigla__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
