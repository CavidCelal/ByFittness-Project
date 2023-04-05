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
    
    public partial class TblKullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblKullanici()
        {
            this.TblAddress = new HashSet<TblAddress>();
            this.TblEgitim = new HashSet<TblEgitim>();
            this.TblEgitimSepet = new HashSet<TblEgitimSepet>();
            this.TblSatislar = new HashSet<TblSatislar>();
            this.TblSepet = new HashSet<TblSepet>();
        }
    
        public int KullaniciId { get; set; }
        public string Adi { get; set; }
        public string Soyad { get; set; }
        public string KullaniciEmail { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string SifreTekrar { get; set; }
        public string Telefon { get; set; }
        public string Roller { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAddress> TblAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEgitim> TblEgitim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEgitimSepet> TblEgitimSepet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatislar> TblSatislar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSepet> TblSepet { get; set; }
    }
}