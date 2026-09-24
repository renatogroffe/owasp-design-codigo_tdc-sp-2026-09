app.MapPost("/admin/users/{id}/delete", (HttpContext httpContext, int id) =>
{
    // Verifica se um usuário está autenticado, sem contudo checar suas permissões... 

    users.Remove(user); // ❌ VULNERÁVEL: sem verificar papel do usuário

    return Results.Ok(new
    {
        Message = "User deleted successfully",
        DeletedUser = user
    });
});