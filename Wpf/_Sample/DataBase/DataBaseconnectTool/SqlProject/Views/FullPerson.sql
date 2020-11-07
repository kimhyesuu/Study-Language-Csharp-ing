CREATE VIEW [dbo].[FullPerson]
	AS 
	select [p].[PersonId] AS PersonId, [p].[FirstName], [p].[LastName],
		 [a].[Id] AS AddresId, 
		 [a].[City], [a].[State], [a].[ZipCode ]
	from dbo.Person p
	left join dbo.Address a on p.[PersonId] = a.PersonId

