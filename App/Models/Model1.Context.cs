﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTV.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class qltvEntities : DbContext
    {
        public qltvEntities()
            : base("name=qltvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CuonSach> CuonSaches { get; set; }
        public virtual DbSet<DangKy> DangKies { get; set; }
        public virtual DbSet<DauSach> DauSaches { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<Muon> Muons { get; set; }
        public virtual DbSet<NguoiLon> NguoiLons { get; set; }
        public virtual DbSet<QuanLy> QuanLies { get; set; }
        public virtual DbSet<QuaTrinhMuon> QuaTrinhMuons { get; set; }
        public virtual DbSet<TuaSach> TuaSaches { get; set; }
    }
}
