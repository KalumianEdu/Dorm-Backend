namespace DormAPI.DTOs
{
    public class IncomeOverviewDTO
    {
        public int IncomeID { get; set; }
        public int IncomeCategoryID { get; set; }
        public decimal IncomeAmount { get; set; }
        public DateTime IncomeDate { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class IncomeCategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class AddIncomeDTO
    {
        public int IncomeCategoryID { get; set; }
        public decimal IncomeAmount { get; set; }
        public DateTime IncomeDate { get; set; }
    }

    public class IncomeStatisticsDTO
    {
        public decimal TotalDeposit { get; set; }
        public decimal PendingStudentRent { get; set; }
    }

    public class FinancialOverviewBundleDTO
    {
        public decimal TotalIncomeThisMonth { get; set; }
        public decimal TotalExpenseThisMonth { get; set; }
        public decimal NetBalanceThisMonth { get; set; }
        public decimal TotalDepositHeld { get; set; }
        public decimal PendingStudentRent { get; set; }
        public decimal TotalIncomeAllTime { get; set; }
        public decimal TotalExpenseAllTime { get; set; }
        public List<IncomeOverviewDTO> Incomes { get; set; } = new List<IncomeOverviewDTO>();
        public List<ExpenseOverviewDTO> Expenses { get; set; } = new List<ExpenseOverviewDTO>();
    }
}
