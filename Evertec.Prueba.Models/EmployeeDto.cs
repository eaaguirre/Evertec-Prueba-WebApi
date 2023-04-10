using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Prueba.Models
{
    /// <summary>
    /// 
    /// </summary>
    public  class EmployeeDto:Employee
    {
        /// <summary>
        /// 
        /// </summary>
        public string MaritalStatus { get; set; }
        public byte[] Photo { get; set; }
        public int Id_marital { get; set; }

        public int TotalRecords { get; set; }


    }
}
