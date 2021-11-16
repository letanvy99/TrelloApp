﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Domain.Entities;
using Trello.Domain.Interfaces;

namespace Trello.Infrastructure.Repositories
{
    public class ListRepository : Repository<List>, IListRepository
    {
        public ListRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}