﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.PowerBI.Api.Models;

namespace Contract.Api.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public EContractStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public uint ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime FinishDate { get; set; }
        public virtual ICollection<ContractProduct>? Products { get; set; }
    }
}
