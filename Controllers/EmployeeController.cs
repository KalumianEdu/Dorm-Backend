using DormAPI.Database.Ado.Repositories;
using DormAPI.Database.EF.Contexts;
using DormAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repository;
        private readonly AppDbContext _dormDbContext;

        public EmployeeController(EmployeeRepository repository, AppDbContext context)
        {
            _repository = repository;
            _dormDbContext = context;
        }

        [HttpGet("get/all/employees")]
        public async Task<ActionResult<EmployeePaginationResponseDTO>> GetEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            try
            {
                var response = await _repository.GetEmployeesAsync(page, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add/employee")]
        public async Task<ActionResult> AddEmployee([FromBody] AddEmployeeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool isSuccess = await _repository.AddEmployeeAsync(dto);
                if (isSuccess)
                {
                    return Ok(new { message = "Employee added successfully." });
                }
                return BadRequest("Failed to add employee.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get/all/employee-types")]
        public async Task<ActionResult<List<EmployeeTypeDTO>>> GetEmployeeTypes()
        {
            try
            {
                var response = await _repository.GetEmployeeTypesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete/employee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                bool isSuccess = await _repository.DeleteEmployeeAsync(id);
                if (isSuccess)
                {
                    return Ok(new { message = "Employee deleted successfully." });
                }
                return NotFound(new { message = "Employee not found or could not be deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("get/contract/active/{employeeId}")]
        public async Task<ActionResult<EmployeeContractDTO>> GetActiveEmployeeContract(int employeeId)
        {
            try
            {
                var response = await _repository.GetActiveEmployeeContractByIdAsync(employeeId);
                if (response != null)
                {
                    return Ok(response);
                }
                return NotFound(new { message = "Active contract not found for this employee." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("add/contract")]
        public async Task<ActionResult> AddEmployeeContract([FromBody] AddEmployeeContractDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool isSuccess = await _repository.AddEmployeeContractAsync(dto);
                if (isSuccess)
                {
                    return Ok(new { message = "Employee contract added successfully." });
                }
                return BadRequest("Failed to add employee contract.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("total/employee")]
        public async Task<ActionResult> GetTotalEmployee()
        {
            // Example: return total employees count
            var total = await _dormDbContext.Employees.CountAsync();
            return Ok(new { TotalEmployees = total });
        }


        [HttpPut("update/contract")]
        public async Task<ActionResult> UpdateEmployeeContract([FromBody] UpdateEmployeeContractDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool isSuccess = await _repository.UpdateEmployeeContractAsync(dto);
                if (isSuccess)
                {
                    return Ok(new { message = "Employee contract updated successfully." });
                }
                return BadRequest("Failed to update employee contract.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get/all/shifts")]
        public async Task<ActionResult<List<ShiftDTO>>> GetShifts()
        {
            try
            {
                var response = await _repository.GetShiftsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("get/leaves/{employeeId}")]
        public async Task<IActionResult> GetEmployeeLeaves(int employeeId)
        {
            var leaves = await _repository.GetEmployeeLeavesAsync(employeeId);
            return Ok(leaves);
        }

        [HttpPost("add/leave")]
        public async Task<IActionResult> RequestLeave([FromBody] AddEmployeeLeaveDTO dto)
        {
            var leaveId = await _repository.AddEmployeeLeaveAsync(dto);
            if (leaveId > 0)
            {
                return Ok(new { LeaveId = leaveId });
            }
            return BadRequest("Failed to add leave.");
        }

        [HttpGet("get/all/leavetypes")]
        public async Task<IActionResult> GetLeaveTypes()
        {
            var types = await _repository.GetLeaveTypesAsync();
            return Ok(types);
        }
    }
}
