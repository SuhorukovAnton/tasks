SELECT ClientName
FROM Clients c
JOIN ClientContacts cc ON c.id = cc.ClientId
GROUP BY ClientName
HAVING COUNT(cc.Id) > 2