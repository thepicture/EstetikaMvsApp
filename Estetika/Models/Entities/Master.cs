//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Estetika.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Master()
        {
            this.Zapis = new HashSet<Zapis>();
        }
    
        public int ID_Master { get; set; }
        public string Imya_Master { get; set; }
        public string Opisanie_Master { get; set; }
        public byte[] Photo { get; set; }
        public string Opit { get; set; }
        public Nullable<int> ID_Tip_Master { get; set; }
    
        public virtual Tip_Master Tip_Master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zapis> Zapis { get; set; }
    }
}