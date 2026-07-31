using Atrato.Entities.Documents;
using Microsoft.EntityFrameworkCore;

namespace Atrato.Entities.Context;

public class AtratoContext : DbContext
{
    public AtratoContext(DbContextOptions<AtratoContext> options) : base(options)
    {}

    public DbSet<Address> Address { get; set; }
    public DbSet<Area> Area { get; set; }
    public DbSet<ChangeHistory> ChangeHistory { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Enterprise> Enterprise { get; set; }
    public DbSet<EntityType> EntityType { get; set; }
    public DbSet<ErrorHistory> ErrorHistory { get; set; }
    public DbSet<FileDb> FileDb { get; set; }
    public DbSet<Guide> Guide { get; set; }
    public DbSet<Invitation> Invitation { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<RefreshToken> RefreshToken { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<ReservationState> ReservationState { get; set; }
    public DbSet<ReservationType> ReservationType { get; set; }
    public DbSet<Rol> Rol { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<TicketState> TicketState { get; set; }
    public DbSet<TimeZoneData> TimeZoneData { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserAction> UserAction { get; set; }
    public DbSet<UserEnterprise> UserEnterprise { get; set; }
    public DbSet<Workplace> Workplace { get; set; }
    public DbSet<WorkStation> WorkStation { get; set; }
    public DbSet<WorkStationState> WorkStationState { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEnterprise>()
            .HasKey(x => new { x.UserId, x.EnterpriseId });
        
        foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
        {
            relation.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}

public class AtratoAuditContext : DbContext
{
    public AtratoAuditContext(DbContextOptions<AtratoAuditContext> options) : base(options)
    {}

    public DbSet<AddressAudit> AddressAudit { get; set; }
    public DbSet<AreaAudit> AreaAudit { get; set; }
    public DbSet<EnterpriseAudit> EnterpriseAudit { get; set; }
    public DbSet<FileDbAudit> FileDbAudit { get; set; }
    public DbSet<NewsAudit> NewsAudit { get; set; }
    public DbSet<NotificationAudit> NotificationAudit { get; set; }
    public DbSet<ReservationAudit> ReservationAudit { get; set; }
    public DbSet<RolAudit> RolAudit { get; set; }
    public DbSet<TicketAudit> TicketAudit { get; set; }
    public DbSet<UserAudit> UserAudit { get; set; }
    public DbSet<WorkplaceAudit> WorkplaceAudit { get; set; }
    public DbSet<WorkStationAudit> WorkStationAudit { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            Console.WriteLine($"\n{entity.ClrType.Name}");

            foreach (var nav in entity.GetNavigations())
            {
                Console.WriteLine($"  -> {nav.Name} : {nav.TargetEntityType.ClrType.Name}");
            }
        }
    }
}