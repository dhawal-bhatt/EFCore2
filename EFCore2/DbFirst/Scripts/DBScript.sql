create proc usp_getproduct
@ProductId int
as
begin
	select * from Products where ProductId = @ProductId
end
go

create function fn_getproduct(@ProductId int)
returns table
return select * from Products where ProductId = @ProductId