using FChat.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataService.Services
{
    public abstract class BaseService
    {
        public readonly IDataAccessService DataAccessService;

        public BaseService(IDataAccessService dataAccessService)
        {
            DataAccessService = dataAccessService;
        }
    }
}
