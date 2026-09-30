namespace DormAPI.DTOs
{
    public class ExpenseOverviewDTO
    {
        public int ExpenseID { get; set; }
        public int ExpenseGategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ExpenseCategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class AddExpenseDTO
    {
        public int ExpenseGategoryID { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
