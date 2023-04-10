﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Prueba.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSucces { get; set; }

        public string Message { get; set; }
        
    }
}
