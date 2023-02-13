using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MilestoneOneLibraryWithMVC_Feb13.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuthor> TAuthors { get; set; } = null!;
        public virtual DbSet<TBook> TBooks { get; set; } = null!;
        public virtual DbSet<TBorrow> TBorrows { get; set; } = null!;
        public virtual DbSet<TStudent> TStudents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured) //It is the Connection String that we are Copying and Paste it in appsettings.json file
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=IN3238393W2\\SQLEXPRESS;Initial Catalog=Library;Trusted_Connection=True;");
//            } 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuthor>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.ToTable("T_Author");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("authorName");

                entity.Property(e => e.AuthorSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("authorSurname");
            });

            modelBuilder.Entity<TBook>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("T_Book");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bookName");

                entity.Property(e => e.BookPageCount).HasColumnName("bookPageCount");
            });

            modelBuilder.Entity<TBorrow>(entity =>
            {
                entity.HasKey(e => e.BorrowId);

                entity.ToTable("T_Borrow");

                entity.Property(e => e.BorrowId).HasColumnName("borrowId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("returnDate");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TakenDate)
                    .HasColumnType("date")
                    .HasColumnName("takenDate");
            });

            modelBuilder.Entity<TStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("T_Student");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.StudentAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("studentAddress");

                entity.Property(e => e.StudentAge).HasColumnName("studentAge");

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("studentGender");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("studentName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
