use Blog
SELECT *
FROM [User] u
JOIN UserRole ur
ON u.id = ur.UserId
JOIN [Role] r
ON r.Id = ur.RoleId

use Blog
SELECT u.Id, u.Name, u.Email, u.PasswordHash, u.Bio, u.Image, u.Slug, r.Id, r.Name
FROM [User] u
JOIN UserRole ur
ON u.id = ur.UserId
JOIN [Role] r
ON r.Id = ur.RoleId

use Blog
SELECT u.Id, u.Name, u.Email, u.PasswordHash, u.Bio, u.Image, u.Slug, r.Name, r.Slug
FROM [User] u
JOIN UserRole ur
ON u.id = ur.UserId
JOIN [Role] r
ON r.Id = ur.RoleId
WHERE u.Id = 1

select * from Tag;
select * from Category;
select * from [User];
select * from UserRole;
select * from [Role];

insert into Tag (Name, Slug) 
VALUES 
('tec','tec'),
('tec2','tec2'),
('tec3','tec3');

INSERT INTO [User] (Name, Email, PasswordHash, Bio, Image, Slug)
VALUES
('João Silva', 'joao@email.com', 'hash123', 'Bio do João', 'a', 'joao-silva'),
('Maria Souza', 'maria@email.com', 'hash456', 'Bio da Maria', 'b', 'maria-souza'),
('Carlos Lima', 'carlos@email.com', 'hash789', 'Bio do Carlos', 'c', 'carlos-lima');

INSERT INTO [Role] (Name, Slug)
VALUES
('Administrador', 'admin'),
('Editor', 'editor'),
('Leitor', 'reader');

INSERT INTO UserRole (UserId, RoleId)
VALUES
(2, 3), -- João -> Admin
(3, 4), -- Maria -> Editor
(4, 5); -- Carlos -> Reader
