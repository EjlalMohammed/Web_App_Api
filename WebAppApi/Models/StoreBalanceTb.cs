﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAppApi.Models
{
    public partial class StoreBalanceTb
    {
        public int StoreBalanceId { get; set; }
        public int? StoreId { get; set; }
        public int? CurrencyId { get; set; }

        public virtual CurrencyTb Currency { get; set; }
        public virtual Store Store { get; set; }
    }
}