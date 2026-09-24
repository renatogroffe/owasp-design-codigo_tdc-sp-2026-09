app.MapPost("/admin/users/{id}/delete", (HttpContext httpContext, int id) =>
{
    // Verifica se um usuário está autenticado, sem contudo checar suas permissões... 

    // ✅ CORRIGIDO: verifica se o usuário tem permissão
    if (currentUser.Role != "Admin")
        return Results.Forbid();

    users.Remove(user);

    return Results.Ok(new
    {
        Message = "User deleted successfully",
        DeletedUser = user
    });
});