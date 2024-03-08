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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class QuanLy
    {
        public int ID { get; set; }
        public string ten { get; set; }
        [Required(ErrorMessage = "Vui l�ng nh?p t�i kho?n")]
        public string taikhoan { get; set; }
        [Required(ErrorMessage = "Vui l�ng nh?p m?t kh?u")]
        [DataType(DataType.Password)]
        public string matkhau { get; set; }

        [NotMapped]
        [Compare("matkhau", ErrorMessage = "M?t kh?u kh�ng tr�ng kh?p!")]
        public string nhaplaimatkhau { get; set; }
        [NotMapped]
        public string loidangnhap { get; set; }
    }
}
