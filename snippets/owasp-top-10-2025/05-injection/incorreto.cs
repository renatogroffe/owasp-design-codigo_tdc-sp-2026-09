using Dapper;

// ...

app.MapPost("/api/users/search", async ([FromBody] UserSearchRequest request) =>
{
    using var connection = new SqlConnection(connectionString);

    // ❌ Vulnerável: concatenação de entrada do body na query
    var sql = $"SELECT * FROM Users WHERE Email = '{request.Email}' AND Active = {request.Active.ToString().ToLower()}";

    var users = await connection.QueryAsync<User>(sql);

    return Results.Ok(users);
});