﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Interfaces;
using Trello.Service.Services.Interfaces;

namespace Trello.Service.Services
{
    public class BaseService
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected IIdentityUser User;

        public BaseService(IUnitOfWork unitOfWork, IIdentityUser user)
        {
            UnitOfWork = unitOfWork;
            User = user;
        }
    }
}
