﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCasesPorts.FormProducto
{
    public interface ICreateProductoOutputPort
    {
        Task Handle(int Id);

    }
}
