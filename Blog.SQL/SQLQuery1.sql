use Blog

SELECT *
FROM [User] u
JOIN UserRole ur
ON u.id = ur.UserId
JOIN [Role] r
ON r.Id = ur.RoleId