//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APP_PARCIAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LISTAVENTA
    {
        public int ID_LIS_VEN { get; set; }
        public Nullable<int> ID_VEN { get; set; }
        public Nullable<int> ID_PRO { get; set; }
        public Nullable<int> CAN_LIS_VEN { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual VENTA VENTA { get; set; }
    }
}
