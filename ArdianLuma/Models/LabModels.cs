namespace luma.Models
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


        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Competition> Competition { get; set; }

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