using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YES.Server.Enums
{
    public enum Status
    {
        Default = 0,
        ToBeAnnounced = 1,
        Postponed = 2,
        Relocated = 3,
        Canceled = 4,
        Past = 5,
    }
}