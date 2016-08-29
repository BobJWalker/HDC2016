using System.Configuration;
using System.Data.Entity;

namespace CodeAperture.HDC2016.SampleSite.DataAccess.Context
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {            
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}