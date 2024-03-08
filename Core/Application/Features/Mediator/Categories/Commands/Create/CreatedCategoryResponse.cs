﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories .Commands.Create
{
    public class CreatedCategoryResponse
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
