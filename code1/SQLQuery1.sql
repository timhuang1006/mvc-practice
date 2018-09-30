USE TSQL2012;
GO
/*�Ĥ@�D*/	--EMLPLOYEE IS MAIN TABLE   --COUNT *>ORDERDATE
SELECT HR.EmployeeID AS EMPID,FirstName,LastName,YEAR(OrderDate) AS ORDERDATE,COUNT(OrderDate) AS ORDERCENT
FROM Sales.Orders AS SO RIGHT JOIN HR.Employees AS HR ON SO.EmployeeID=HR.EmployeeID
GROUP BY HR.EmployeeID,FirstName,LastName,LastName,YEAR(OrderDate)
ORDER BY HR.EmployeeID,YEAR(OrderDate);
/*��SO �� HR*/

/*�ĤG�D*/
SELECT TOP(5) SD.productid,ProductName,SUM(SD.Qty)AS qty
FROM Sales.Orders AS SO JOIN Sales.OrderDetails AS SD ON SO.OrderID=SD.OrderID 
	JOIN Production.Products AS P ON P.ProductID=SD.ProductID 
GROUP BY SD.productid,ProductName
ORDER BY qty DESC

--�ĤT�D   --�����ܰʩ�> �Nrange�]���ܼ�	-- MAX ���̤j�� �Y�w�����ץi��
SELECT CONVERT(varchar(MAX) ,(DATEDIFF(yyyy , BirthDate , GETDATE()) /10 * 10 ) )
+ '~' + CONVERT(varchar(MAX),(DATEDIFF(yyyy , BirthDate , GETDATE()) /10 * 10 + 9)) ,COUNT((DATEDIFF(yyyy , BirthDate , GETDATE()) /10 ))
FROM HR.Employees AS HR 
Group by (DATEDIFF(yyyy , BirthDate , GETDATE()) /10 )

--�ĥ|�D
select *
from ( select row_number() over( partition by shipcountry order by count(*) desc) as seq,shipcountry,hr.EmployeeID as empid,firstname,lastname,count(*) as cnt
		from Sales.Orders as so join  HR.Employees as hr on so.EmployeeID=hr.EmployeeID
		 group by ShipCountry,hr.EmployeeID,FirstName,LastName) as a
where seq<=3
order by ShipCountry,cnt desc;



/*��5�D*/
SELECT EMPID,FirstName,LastName,[2006] as cnt2006,[2007] as cnt2007,[2008] as cnt2008
FROM (SELECT SO.EmployeeID AS EMPID,FirstName,LastName,YEAR(OrderDate) AS ORDERDATE,COUNT(*) AS ORDERCENT
	FROM Sales.Orders AS SO INNER JOIN HR.Employees AS HR ON SO.EmployeeID=HR.EmployeeID
GROUP BY SO.EmployeeID,FirstName,LastName,LastName,YEAR(OrderDate)
) AS D
PIVOT(sum(ORDERCENT) FOR OrderDate			/*���B�Y�ϥ�COUNT�h���p��*/  -- IF   *  ?
  	IN([2006],[2007],[2008])
		) AS pvt
GROUP BY EMPID,FirstName,LastName,[2006],[2007],[2008]

--�Ĥ��D
SELECT so.OrderID AS �q��N��,
	Convert(Date,OrderDate) AS �q�ʤ��,
	Convert(Date,RequiredDate) AS �ݭn���,
	Convert(varchar(max), so.CustomerID) + '-'+CompanyName AS ���q�W��,FirstName++'  '+LastName as �޲z��,
	Convert(varchar(max), p.ProductID) +'-'+ProductName as �ӫ~,sd.UnitPrice as ���,qty as �ƶq,(Qty*sd.UnitPrice) as �p�p
FROM Sales.Orders as so , Sales.OrderDetails as sd   , Production.Products as p ,Sales.Customers as sc,HR.Employees AS HR
 where so.OrderID='11070'and so.OrderID= sd.OrderID and sd.UnitPrice= p.UnitPrice and 
 sd.ProductID=p.ProductID and sc.CustomerID=so.CustomerID and hr.EmployeeID = so.EmployeeID
/* GROUP BY so.OrderID,Convert(Date,OrderDate),Convert(Date,RequiredDate),
Convert(varchar(max), so.CustomerID) +'-'+ CompanyName,
Convert(varchar(max), so.EmployeeID) +'-'+ContactName,
Convert(varchar(max), p.ProductID) +'-'+ProductName,sd.UnitPrice,qty;
*/
SELECT *FROM Sales.Orders WHERE OrderID='11070';
SELECT *FROM Production.Products;
SELECT *FROM Sales.OrderDetails WHERE OrderID='11070'
SELECT *FROM Sales.Customers WHERE CompanyName='Customer OXFRU';
select(
SELECT *FROM Sales.OrderDetails) as a
from Production.Products
where ProductID='38'

--�ĤC�D
insert into Sales.OrderDetails
values (11070,38,263.5,2,0.000);


update Sales.Orders
set RequiredDate= DATEADD(MONTH,0,'2008-10-10')
where OrderID='11070';

SELECT so.OrderID AS �q��N��,Convert(Date,OrderDate) AS �q�ʤ��,Convert(Date,RequiredDate) AS �ݭn���,
  Convert(varchar(max), so.CustomerID) + '-'+CompanyName AS ���q�W��,
  FirstName++'  '+LastName as �޲z��,
  Convert(varchar(max), p.ProductID) +'-'+ProductName as �ӫ~,sd.UnitPrice as ���,
   qty as �ƶq,(Qty*sd.UnitPrice) as �p�p
FROM Sales.Orders as so , Sales.OrderDetails as sd   , Production.Products as
 p ,Sales.Customers as sc,HR.Employees AS HR
 where so.OrderID='11070'and so.OrderID= sd.OrderID and sd.UnitPrice= p.UnitPrice and 
 sd.ProductID=p.ProductID and sc.CustomerID=so.CustomerID and hr.EmployeeID = so.EmployeeID
 
 
 --�ĤK�D
 delete from Sales.OrderDetails
 where OrderID='11070'and ProductID='38';

 SELECT so.OrderID AS �q��N��,Convert(Date,OrderDate) AS �q�ʤ��,Convert(Date,RequiredDate) AS �ݭn���,
  Convert(varchar(max), so.CustomerID) + '-'+CompanyName AS ���q�W��,
  FirstName++'  '+LastName as �޲z��,
  Convert(varchar(max), p.ProductID) +'-'+ProductName as �ӫ~,sd.UnitPrice as ���,
   qty as �ƶq,(Qty*sd.UnitPrice) as �p�p
FROM Sales.Orders as so , Sales.OrderDetails as sd   , Production.Products as
 p ,Sales.Customers as sc,HR.Employees AS HR
 where so.OrderID='11070'and so.OrderID= sd.OrderID and sd.UnitPrice= p.UnitPrice and 
 sd.ProductID=p.ProductID and sc.CustomerID=so.CustomerID and hr.EmployeeID = so.EmployeeID
 