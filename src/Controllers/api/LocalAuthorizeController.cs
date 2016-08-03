using CodeAperture.IO.HDC2016.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAperture.IO.HDC2016.Controllers.api
{
    public class LocalAuthorizeController : Controller
    {
        private ILocalScopeExampleDataService _dataService;

        public LocalAuthorizeController(ILocalScopeExampleDataService dataService)
        {
            _dataService = dataService;
        }

        [Route("api/LocalAuthorize")]
        [HttpGet]
        [Authorize]
        public IActionResult GetItems(int parentId)
        {
            var results = _dataService.GetList(parentId);

            return new ObjectResult(results);
        }

        [Route("api/LocalAuthorize/{itemId}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetItemById(int itemId)
        {
            var results = _dataService.GetItem(itemId);

            return new ObjectResult(results);
        }
    }
}
