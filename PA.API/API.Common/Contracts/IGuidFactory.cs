using System;
using System.Collections.Generic;
using System.Text;

namespace API.Common.Contracts
{
    public interface IGuidFactory
    {
        Guid GetGuid();
        string GetGuidWithoutHyphen();
    }
}
