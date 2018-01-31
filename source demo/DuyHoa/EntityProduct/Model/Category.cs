﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category : CreatedUpdated
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDes { get; set; }

    }
}
