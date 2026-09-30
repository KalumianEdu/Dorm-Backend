using System;
using System.Collections.Generic;

namespace DormAPI.DTOs
{
    public class EmployeeDTO
    {
        // Employee specifics
        public int EmployeeID { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        // Person specifics
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string PassportNumber { get; set; }
        public string IdentityNumber { get; set; }
        public int NationalityID { get; set; }

        // Contact specifics
        public int ContactID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public int RelationshipTypeID { get; set; }
        public string RelationshipName { get; set; }
    }

    public class AddEmployeeDTO
    {
        public int EmployeeTypeID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string PassportNumber { get; set; }
        public string IdentityNumber { get; set; }
        public int NationalityID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public int RelationshipTypeID { get; set; }
    }

    public class EmployeePaginationResponseDTO
    {
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class EmployeeTypeDTO
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
    }

    public class EmployeeContractDTO
    {
        public int EmployeeContractId { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ShiftId { get; set; }
        public decimal? Salary { get; set; }
        public int WorkingHours { get; set; }
        public int WorkingDaysId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }

    public class AddEmployeeContractDTO
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ShiftId { get; set; }
        public double Salary { get; set; }
        public double? WorkingHours { get; set; }
        public int? WorkingDays { get; set; }
        public int? AssignedBuildingId { get; set; }
    }
}
