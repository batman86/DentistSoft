//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentistManager.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        public Material()
        {
            this.MaterialTreatments = new HashSet<MaterialTreatment>();
            this.RecivingItems = new HashSet<RecivingItem>();
            this.Warehouses = new HashSet<Warehouse>();
            this.opperations = new HashSet<opperation>();
        }
    
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string PartNumber { get; set; }
        public int CatID { get; set; }
        public Nullable<int> ProdCompany { get; set; }
        public string ScaleType { get; set; }
        public Nullable<int> ReOrder { get; set; }
        public string Note { get; set; }
        public decimal MaterialCost { get; set; }
    
        public virtual ICollection<MaterialTreatment> MaterialTreatments { get; set; }
        public virtual ICollection<RecivingItem> RecivingItems { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
        public virtual ICollection<opperation> opperations { get; set; }
    }
}
