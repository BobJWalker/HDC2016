using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security.AntiXss;
using CodeAperture.HDC2016.SampleSite.DataAccess.Context;
using CodeAperture.HDC2016.SampleSite.Models.Model;

namespace CodeAperture.HDC2016.SampleSite.Controllers
{
    public class DemoController : ApiController
    {
        private readonly DemoDbContext _context;

        public DemoController()
        {
            _context = new DemoDbContext();    
        }

        [HttpGet]
        public Task<List<DemoModel>> GetModel()
        {
            return _context.DemoModels.ToListAsync();
        }

        [HttpGet]
        public Task<DemoModel> GetModel(int id)
        {
            return _context.DemoModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<DemoModel> PostModel([FromBody] DemoModel model)
        {
            //model.Data = AntiXssEncoder.HtmlEncode(model.Data, true);

            _context.DemoModels.Add(model);
            await _context.SaveChangesAsync();
            
            return model;
        }

        [HttpPut]
        public async Task<DemoModel> UpdateModel([FromBody] DemoModel model)
        {
            var entity = await _context.DemoModels.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity != null)
            {
                entity.Data = model.Data;
                await _context.SaveChangesAsync();
            }

            return model;
        }
    }
}
