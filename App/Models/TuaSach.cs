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
    
    public partial class TuaSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TuaSach()
        {
            this.DauSaches = new HashSet<DauSach>();
        }
    
        public int ma_tuasach { get; set; }
        public string TuaSach1 { get; set; }
        public string tacgia { get; set; }
        public string tomtat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DauSach> DauSaches { get; set; }
    }
}
