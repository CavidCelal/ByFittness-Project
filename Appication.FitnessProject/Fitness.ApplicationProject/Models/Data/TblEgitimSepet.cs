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
    
    public partial class TblEgitimSepet
    {
        public int EgitimSepetId { get; set; }
        public Nullable<int> EgitimId { get; set; }
        public Nullable<int> KullaniciId { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Resim { get; set; }
    
        public virtual TblEgitim TblEgitim { get; set; }
        public virtual TblKullanici TblKullanici { get; set; }
    }
}
