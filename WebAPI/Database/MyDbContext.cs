namespace WebAPI.Database
{
    public class MyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<GroupImage> GroupImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("MySqlConnection");
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId).ValueGeneratedOnAdd();

                entity.Property(u => u.UserId).HasColumnName("UserId");
                entity.Property(u => u.Username).HasColumnName("Username");
                entity.Property(u => u.Password).HasColumnName("Password");

                entity.HasMany(u => u.GroupImage)
                    .WithOne(g => g.CreateBy)
                    .HasForeignKey(g => g.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GroupImage>(entity =>
            {
                entity.HasKey(g => g.GroupId);
                entity.Property(g => g.GroupId).ValueGeneratedOnAdd();

                entity.Property(g => g.GroupId).HasColumnName("GroupId");
                entity.Property(g => g.GroupName).HasColumnName("GroupName");
                entity.Property(g => g.GroupDate).HasColumnName("GroupDate");
                entity.Property(g => g.UserId).HasColumnName("UserId");

                entity.HasOne(g => g.CreateBy)
                    .WithMany(u => u.GroupImage)
                    .HasForeignKey(g => g.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(g => g.Images)
                    .WithOne(i => i.GroupImage)
                    .HasForeignKey(i => i.GroupId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(i => i.ImageId);
                entity.Property(i => i.ImageId).ValueGeneratedOnAdd();

                entity.Property(i => i.ImageId).HasColumnName("ImageId");
                entity.Property(i => i.FileImage).HasColumnName("FileImage");
                entity.Property(i => i.GroupId).HasColumnName("GroupId");

                entity.HasOne(i => i.GroupImage)
                    .WithMany(g => g.Images)
                    .HasForeignKey(i => i.GroupId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }

    }
}
