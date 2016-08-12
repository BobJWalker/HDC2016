using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAperture.IO.HDC2016.Core.Interfaces
{
    public interface ILocalScopeExampleDataService
    {
        List<int> GetList(int parentId);
        string GetItem(int itemId);
    }
}
