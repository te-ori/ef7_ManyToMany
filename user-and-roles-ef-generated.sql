SELECT [u].[Id], [u].[Name], [t].[RoleId], [t].[UserId], [t].[Id], [t].[Name]
FROM [User] AS [u]
LEFT JOIN (
    SELECT [u0].[RoleId], [u0].[UserId], [r].[Id], [r].[Name]
    FROM [UsersRoles] AS [u0]
    INNER JOIN [Roles] AS [r] ON [u0].[RoleId] = [r].[Id]
) AS [t] ON [u].[Id] = [t].[UserId]
ORDER BY [u].[Id], [t].[RoleId], [t].[UserId]