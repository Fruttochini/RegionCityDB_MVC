//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegionCityDB_MVC.DataLayer.DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public string CityName { get; set; }
    
        public virtual Region Region { get; set; }
    }
}