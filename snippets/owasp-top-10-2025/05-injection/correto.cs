using Dapper;

// ...

app.MapPost("/api/users/search", async ([FromBody] UserSearchRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains("@"))
    {
        return Results.BadRequest(new { error = "Email inválido." });
    }

    using var connection = new SqlConnection(connectionString);

    // ✅ Seguro: parâmetros separados da query
    var sql = "SELECT * FROM Users WHERE Email = @Email AND Active = @Active";

    var users = await connection.QueryAsync<User>(
        sql,
        new
        {
            Email = request.Email,
            Active = request.Active
        });

    return Results.Ok(users);
});