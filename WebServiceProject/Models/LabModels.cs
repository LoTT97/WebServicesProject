namespace ClubCompetition.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class LabModels : DbContext
    {
        
        public LabModels()
            : base("name=Lab1") 
        {
        }


        public DbSet<Member> Member { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
   
            modelBuilder.Entity<Member>()
                .HasMany<Competition>(s => s.Competitions)
                .WithMany(c => c.Members)
                .Map(cs =>{
                    cs.MapLeftKey("MemberId");
                    cs.MapRightKey("CompetitionId");
                    cs.ToTable("MemberCompetition");
                });
            base.OnModelCreating(modelBuilder);
        }
    }

}