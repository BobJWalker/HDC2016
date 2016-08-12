using System;
using Microsoft.AspNetCore.Mvc;
using CodeAperture.IO.HDC2016.Core.Interfaces;

namespace CodeAperture.IO.HDC2016.Controllers.api
{
    public class LocalScopeExampleController : Controller
    {
        private ILocalScopeExampleDataService _dataService;
        private ILocalScopeLogManager _logManager;

        public LocalScopeExampleController(ILocalScopeExampleDataService dataService, ILocalScopeLogManager logManager)
        {
            _dataService = dataService;
            _logManager = logManager;
        }

        [Route("api/LocalScopeGetItems")]
        [HttpGet]
        public IActionResult GetItems(int parentId)
        {
            try
            {
                var results = _dataService.GetList(parentId);

                return new ObjectResult(results);
            }
            catch (Exception e)
            {
                _logManager.LogError(e, "GetItems", "LocalScopeExampleController");

                throw; 
            }
        }

        [Route("api/LocalScopeGetItems/{itemId}")]
        [HttpGet]
        public IActionResult GetItemById(int itemId)
        {
            try
            {
                var results = _dataService.GetItem(itemId);

                return new ObjectResult(results);
            }
            catch (Exception e)
            {
                _logManager.LogError(e, "GetItemById", "LocalScopeExampleController");

                throw;
            }
        }
    }
}
