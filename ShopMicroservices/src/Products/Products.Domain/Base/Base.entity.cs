﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Base
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
