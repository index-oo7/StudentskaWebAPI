using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentskaWebAPI.Models;

namespace StudentskaWebAPI.Data;

public partial class StudentskaWebApiContext : DbContext
{
    public StudentskaWebApiContext()
    {
    }

    public StudentskaWebApiContext(DbContextOptions<StudentskaWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ispit> Ispits { get; set; }

    public virtual DbSet<IspitniRok> IspitniRoks { get; set; }

    public virtual DbSet<Predmet> Predmets { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentPredmet> StudentPredmets { get; set; }

    public virtual DbSet<Zapisnik> Zapisniks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-J6AQ95Q\\SQLEXPRESS;Database=StudentskaWebAPI;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ispit>(entity =>
        {
            entity.HasKey(e => e.IdIspita).HasName("PK__Ispit__55982DDF41A45579");

            entity.ToTable("Ispit");

            entity.Property(e => e.IdIspita).HasColumnName("idIspita");
            entity.Property(e => e.Datum)
                .HasColumnType("datetime")
                .HasColumnName("datum");
            entity.Property(e => e.IdPredmeta).HasColumnName("idPredmeta");
            entity.Property(e => e.IdRoka).HasColumnName("idRoka");

            entity.HasOne(d => d.IdPredmetaNavigation).WithMany(p => p.Ispits)
                .HasForeignKey(d => d.IdPredmeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ispit__idPredmet__412EB0B6");

            entity.HasOne(d => d.IdRokaNavigation).WithMany(p => p.Ispits)
                .HasForeignKey(d => d.IdRoka)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ispit__idRoka__403A8C7D");
        });

        modelBuilder.Entity<IspitniRok>(entity =>
        {
            entity.HasKey(e => e.IdRoka).HasName("PK__IspitniR__E50475CB80CDA364");

            entity.ToTable("IspitniRok");

            entity.Property(e => e.IdRoka).HasColumnName("idRoka");
            entity.Property(e => e.Naziv)
                .HasMaxLength(255)
                .HasColumnName("naziv");
            entity.Property(e => e.SkolskaGod)
                .HasMaxLength(255)
                .HasColumnName("skolskaGod");
            entity.Property(e => e.StatusRoka)
                .HasMaxLength(255)
                .HasColumnName("statusRoka");
        });

        modelBuilder.Entity<Predmet>(entity =>
        {
            entity.HasKey(e => e.IdPredmeta).HasName("PK__Predmet__C015D9D162100B7D");

            entity.ToTable("Predmet");

            entity.Property(e => e.IdPredmeta).HasColumnName("idPredmeta");
            entity.Property(e => e.Espb).HasColumnName("espb");
            entity.Property(e => e.IdProfesora).HasColumnName("idProfesora");
            entity.Property(e => e.Naziv)
                .HasMaxLength(255)
                .HasColumnName("naziv");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.IdProfesoraNavigation).WithMany(p => p.Predmets)
                .HasForeignKey(d => d.IdProfesora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Predmet__idProfe__3B75D760");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesora).HasName("PK__Profesor__4968748659BA8646");

            entity.ToTable("Profesor");

            entity.Property(e => e.IdProfesora).HasColumnName("idProfesora");
            entity.Property(e => e.DatumZap)
                .HasColumnType("datetime")
                .HasColumnName("datumZap");
            entity.Property(e => e.Ime)
                .HasMaxLength(255)
                .HasColumnName("ime");
            entity.Property(e => e.Prezime)
                .HasMaxLength(255)
                .HasColumnName("prezime");
            entity.Property(e => e.Zvanje)
                .HasMaxLength(255)
                .HasColumnName("zvanje");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudenta).HasName("PK__Student__66DE1F69A5F58C56");

            entity.ToTable("Student");

            entity.Property(e => e.IdStudenta).HasColumnName("idStudenta");
            entity.Property(e => e.Broj).HasColumnName("broj");
            entity.Property(e => e.GodinaUpisa)
                .HasMaxLength(255)
                .HasColumnName("godinaUpisa");
            entity.Property(e => e.Ime)
                .HasMaxLength(255)
                .HasColumnName("ime");
            entity.Property(e => e.Prezime)
                .HasMaxLength(255)
                .HasColumnName("prezime");
            entity.Property(e => e.Smer)
                .HasMaxLength(255)
                .HasColumnName("smer");
        });

        modelBuilder.Entity<StudentPredmet>(entity =>
        {
            entity.HasKey(e => new { e.IdStudenta, e.IdPredmeta }).HasName("PK__StudentP__6ADF42F476FE432C");

            entity.ToTable("StudentPredmet");

            entity.Property(e => e.IdStudenta).HasColumnName("idStudenta");
            entity.Property(e => e.IdPredmeta).HasColumnName("idPredmeta");
            entity.Property(e => e.SkolskaGodina)
                .HasMaxLength(255)
                .HasColumnName("skolskaGodina");

            entity.HasOne(d => d.IdPredmetaNavigation).WithMany(p => p.StudentPredmets)
                .HasForeignKey(d => d.IdPredmeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentPr__idPre__44FF419A");

            entity.HasOne(d => d.IdStudentaNavigation).WithMany(p => p.StudentPredmets)
                .HasForeignKey(d => d.IdStudenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentPr__idStu__440B1D61");
        });

        modelBuilder.Entity<Zapisnik>(entity =>
        {
            entity.HasKey(e => new { e.IdStudenta, e.IdIspita }).HasName("PK__Zapisnik__83879DB4EE736E7D");

            entity.ToTable("Zapisnik");

            entity.Property(e => e.IdStudenta).HasColumnName("idStudenta");
            entity.Property(e => e.IdIspita).HasColumnName("idIspita");
            entity.Property(e => e.Bodovi)
                .HasMaxLength(255)
                .HasColumnName("bodovi");
            entity.Property(e => e.Ocena).HasColumnName("ocena");

            entity.HasOne(d => d.IdIspitaNavigation).WithMany(p => p.Zapisniks)
                .HasForeignKey(d => d.IdIspita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Zapisnik__idIspi__48CFD27E");

            entity.HasOne(d => d.IdStudentaNavigation).WithMany(p => p.Zapisniks)
                .HasForeignKey(d => d.IdStudenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Zapisnik__idStud__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
