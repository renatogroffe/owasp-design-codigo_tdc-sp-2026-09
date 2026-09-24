    [HttpPatch("{employeeId}/salary")]
    [Authorize]
    public async Task<IActionResult> UpdateSalary(int employeeId, [FromBody] UpdateSalaryRequest request)
    {
        // ✅ Pega o funcionário pelo ID enviado pelo cliente
        var employee = await _employeeRepository.GetByIdAsync(employeeId);

        if (employee is null)
            return NotFound();

        // ❌ Problema: qualquer usuário autenticado pode mudar qualquer salário
        employee.Salary = request.NewSalary;

        await _employeeRepository.SaveChangesAsync();

        return Ok(new
        {
            employee.Id,
            employee.Name,
            employee.Salary
        });
    }