﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.MenuTables.Queries.GetList
{
    public class GetListMenuTableResponse
    {
        public int MenuTableID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
