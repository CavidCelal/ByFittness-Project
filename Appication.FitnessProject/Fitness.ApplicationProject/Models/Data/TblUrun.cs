//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fitness.ApplicationProject.Models.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUrun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUrun()
        {
            this.TblSatislar = new HashSet<TblSatislar>();
            this.TblSepet = new HashSet<TblSepet>();
        }
    
        public int UrunId { get; set; }
        public Nullable<int> KategoriId { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<int> Stok { get; set; }
        public Nullable<bool> Populer { get; set; }
        public string Resim { get; set; }
    
        public virtual TblKategori TblKategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatislar> TblSatislar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSepet> TblSepet { get; set; }
    }
}
