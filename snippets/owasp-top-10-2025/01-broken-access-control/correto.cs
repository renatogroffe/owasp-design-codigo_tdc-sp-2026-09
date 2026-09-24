    [HttpPatch("{employeeId}/salary")]
    [Authorize(Roles = "HR,FinanceManager,Admin")]
    public async Task<IActionResult> UpdateSalary(int employeeId, [FromBody] UpdateSalaryRequest request)
    {
        if (request.NewSalary <= 0 || request.NewSalary > 1_000_000m)
            return BadRequest("Salário inválido.");

        var employee = await _employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
            return NotFound();

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var currentUserRoles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToHashSet();

        var isAdmin = currentUserRoles.Contains("Admin");
        var isHr = currentUserRoles.Contains("HR");
        var isFinanceManager = currentUserRoles.Contains("FinanceManager");

        var belongsToSameDepartment =
            await _employeeRepository.UserManagesDepartmentAsync(currentUserId!, employee.DepartmentId);

        // ✅ Política de autorização explícita
        if (!isAdmin && !isHr && !(isFinanceManager && belongsToSameDepartment))
            return Forbid();

        employee.Salary = request.NewSalary;
        await _employeeRepository.SaveChangesAsync();

        return Ok(new
        {
            employee.Id,
            employee.Name,
            employee.Salary
        });
    }