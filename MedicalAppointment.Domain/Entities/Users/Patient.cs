﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Users
{
    [Table("Patients", Schema = "users")]
    public sealed class Patient : Base.ActiveEntity<int>
    {
        [Key]
        [ForeignKey("User")]
        [Column("PatientID")]
        public override int Id { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public int InsuranceProviderId { get; set; }
    }
}
