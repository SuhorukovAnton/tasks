SELECT ClientName, COUNT(*) AS ContactCount
FROM Clients c
LEFT JOIN ClientContacts cc ON c.id = cc.ClientId
GROUP BY ClientName