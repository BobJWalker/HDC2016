using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAperture.IO.HDC2016.Core.Interfaces
{
    public interface ILocalScopeLogManager
    {
        void LogError(Exception e, string methodName, string controllerName);
    }
}
