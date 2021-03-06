//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TruyenTranh_ManagermentPage
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comic()
        {
            this.Chuongs = new HashSet<Chuong>();
            this.ListFavourites = new HashSet<ListFavourite>();
        }
    
        public int idComic { get; set; }
        public string nameComic { get; set; }
        public string imgComic { get; set; }
        public int idTypeComic { get; set; }
        public string decription { get; set; }
        public string author { get; set; }
        public Nullable<int> idAccount { get; set; }
        public Nullable<bool> status { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chuong> Chuongs { get; set; }
        public virtual Type_Comic Type_Comic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListFavourite> ListFavourites { get; set; }
    }
}
