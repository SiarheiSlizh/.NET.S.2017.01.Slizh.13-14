﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Shape
    {
        public void Accept(IShapeVisitor visitor) => visitor.Visit((dynamic)this);
    }
}
