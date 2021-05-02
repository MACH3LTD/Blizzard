CREATE TABLE [dbo].[signupinfo]
(
    [username] NVARCHAR(50) NOT NULL, 
    [name] NVARCHAR(50) NOT NULL, 
    [DOB] DATE NOT NULL, 
    [phno] BIGINT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [secque] NVARCHAR(MAX) NULL, 
    [secans] NVARCHAR(MAX) NULL
)
