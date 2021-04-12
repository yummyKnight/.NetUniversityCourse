using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApp.DAL.Entities {
    public partial class HotelDBContext : DbContext {
        public HotelDBContext() {
        }

        public HotelDBContext(DbContextOptions<HotelDBContext> options)
            : base(options) {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CanceledAt)
                    .HasColumnType("date")
                    .HasColumnName("canceled_at");

                entity.Property(e => e.CheckIn)
                    .HasColumnType("date")
                    .HasColumnName("check_in");

                entity.Property(e => e.CheckOut)
                    .HasColumnType("date")
                    .HasColumnName("check_out");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IsCanceled)
                    .HasColumnName("is_canceled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("modified_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ReservedDay)
                    .HasColumnType("date")
                    .HasColumnName("reserved_day");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Booking_client_id_fkey");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("Booking_room_id_fkey");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("modified_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.OrdersNum).HasColumnName("orders_num");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasComment("In dollars");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.Canceled)
                    .HasColumnName("canceled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CanceledAt)
                    .HasColumnType("date")
                    .HasColumnName("canceled_at");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("modified_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("Payment_booking_id_fkey");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("Payment_payment_type_id_fkey");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.HasIndex(e => e.Type, "PaymentType_type_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("Room_room_type_id_fkey");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType");

                entity.HasIndex(e => e.RoomType1, "RoomType_room_type_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoomType1)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("room_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}