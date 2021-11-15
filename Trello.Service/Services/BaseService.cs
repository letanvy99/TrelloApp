using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Interfaces;

namespace Trello.Service.Services
{
    public class BaseService
    {
        protected IUnitOfWork UnitOfWork { get; }
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
