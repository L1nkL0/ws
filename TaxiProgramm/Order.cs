//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxiProgramm
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public string ClientNumber { get; set; }
        public string DriverNumver { get; set; }
        public System.DateTime TimeOfOrder { get; set; }
        public Nullable<System.DateTime> StartOfTheTrip { get; set; }
        public Nullable<System.DateTime> EndOfTheTrip { get; set; }
        public Nullable<bool> Completed { get; set; }
        public Nullable<bool> Cancelled { get; set; }
        public Nullable<System.TimeSpan> TravelTime { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual TaxiDriver TaxiDriver { get; set; }
    }
}
