using System;

namespace DAL.ViewModel
{
    public class ContractDTO
    {
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public int Type { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
