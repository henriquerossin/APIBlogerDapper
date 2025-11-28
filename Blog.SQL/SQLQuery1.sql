use Blog

SELECT *
FROM [User] u
JOIN UserRole ur
ON u.id = ur.UserId
JOIN [Role] r
ON r.Id = ur.RoleId

SELECT u.Id, u.Name, u.Email, u.PasswordHash, u.Bio, u.Image, u.Slug, r.Id, r.Name
FROM [User] u
JOIN UserRole ur
ON u.id = ur.UserId
JOIN [Role] r
ON r.Id = ur.RoleId

SELECT u.Id, u.Name, u.Email, u.PasswordHash, u.Bio, u.Image, u.Slug, r.Name, r.Slug
                FROM [User] u
                JOIN UserRole ur
                ON u.id = ur.UserId
                JOIN [Role] r
                ON r.Id = ur.RoleId
                WHERE u.Id = 1

use Blog