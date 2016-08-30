using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeAperture.HDC2016.SampleSite.Models.Model;

namespace CodeAperture.HDC2016.SampleSite.DataAccess.Context
{
    public class DemoDbContext : DbContext
    {
        public IDbSet<DemoModel> DemoModels { get; set; }

        public DemoDbContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {            
        }

        public override int SaveChanges()
        {
            ProcessContextAudit(ChangeTracker);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            ProcessContextAudit(ChangeTracker);
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ProcessContextAudit(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessContextAudit(DbChangeTracker tracker)
        {
            if (tracker.Entries().Any(e => e.Entity is BaseModel && (e.State == EntityState.Added | e.State == EntityState.Modified)))
            {
                foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is BaseModel
                                                                         && (e.State == EntityState.Added | e.State == EntityState.Modified)))
                {
                    var auditEntity = (BaseModel)entry.Entity;
                    if (entry.State == EntityState.Added)
                    {
                        auditEntity.CreatedOn = DateTime.Now;                        
                    }

                    auditEntity.UpdatedOn = DateTime.Now;                    
                }
            }
        }
    }
}