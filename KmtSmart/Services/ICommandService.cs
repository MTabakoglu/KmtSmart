using KmtSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    interface ICommandService
    {
        Task Add(CommandModel command);
    }
}
