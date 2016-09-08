using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Security.AntiXss;
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
            //AntiXssEncode(ChangeTracker);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            ProcessContextAudit(ChangeTracker);
            //AntiXssEncode(ChangeTracker);
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ProcessContextAudit(ChangeTracker);
            //AntiXssEncode(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }

        private static void ProcessContextAudit(DbChangeTracker tracker)
        {
            var entriesChangedWithBaseModel = tracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Added | e.State == EntityState.Modified));

            foreach (var entry in entriesChangedWithBaseModel)
            {
                var auditEntity = (BaseModel) entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    auditEntity.CreatedOn = DateTime.Now;
                }

                auditEntity.UpdatedOn = DateTime.Now;
            }
        }

        private static void AntiXssEncode(DbChangeTracker tracker)
        {
            var addedModifiedEntries = tracker.Entries().Where(e => e.State == EntityState.Added | e.State == EntityState.Modified);

            foreach (var entry in addedModifiedEntries)
            {
                var entity = entry.Entity;
                var type = entity.GetType();
                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    if (property.PropertyType != typeof(string))
                    {
                        continue;
                    }

                    var value = property.GetValue(entity, null);

                    if (value == null)
                    {
                        continue;
                    }

                    value = AntiXssEncoder.HtmlEncode(value.ToString(), true);

                    property.SetValue(entity, value, null);
                }
            }
        }        
    }
}