select * 
from dbo.Invoice i
join dbo.Contractor c on i.ContractorID = c.ID
join dbo.InvoiceElement e on e.InvoiceID = i.ID
join dbo.Product p on e.ProductID = p.ID