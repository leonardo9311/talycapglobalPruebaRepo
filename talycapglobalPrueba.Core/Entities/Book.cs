﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talycapglobalPrueba.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

  
        public string Description { get; set; }

      
        public int PageCount { get; set; }

        public string Excerpt { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
