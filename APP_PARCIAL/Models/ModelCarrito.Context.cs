﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FUENTE_SODAEntities2 : DbContext
    {
        public FUENTE_SODAEntities2()
            : base("name=FUENTE_SODAEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BOLETA> BOLETA { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<DETALLEBOLETA> DETALLEBOLETA { get; set; }
        public virtual DbSet<DISTRITO> DISTRITO { get; set; }
        public virtual DbSet<LISTAVENTA> LISTAVENTA { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<VENDEDOR> VENDEDOR { get; set; }
        public virtual DbSet<VENTA> VENTA { get; set; }
    }
}