//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class DangKy
    {
        public int isbn { get; set; }
        public int ma_docgia { get; set; }
        public Nullable<System.DateTime> ngaygio_dk { get; set; }
        public string ghichu { get; set; }
    
        public virtual DauSach DauSach { get; set; }
        public virtual DocGia DocGia { get; set; }
    }
}