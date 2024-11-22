using Microsoft.EntityFrameworkCore;
using System;

using System.ComponentModel.DataAnnotations;

namespace PortFolio.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public string LecturerName { get; set; }
        public string Status { get; set; }

        
        public string Department { get; set; }
        public List<Module> Modules { get; set; }
        public DateTime DateOfClaim {  get; set; }
        public byte[] SupportingDocuments { get; set; }
    }

    public class Module
    {
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
    }
}
