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
    
    public partial class TblAddress
    {
        public int AddressId { get; set; }
        public Nullable<int> KullaniciId { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Il { get; set; }
        public string Address { get; set; }
        public string PostaKodu { get; set; }
    
        public virtual TblKullanici TblKullanici { get; set; }
    }
}
