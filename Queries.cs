using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace App;
// public class ProductId
// {
//     public int Id {get; set;}
//     public ProductId(int id) {
//         Id = id;
//     }
//     public ProductId() { }
// }

public record ProductId(int Id);

[Node]
public class Product
{
    public ProductId Id { get; set; }
    public string Name { get; set; }
}

public class ProductType : ObjectType<Product>
{
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(n => n.Id).ID();
        descriptor.Field(n => n.Name);
    }
}

[QueryType]
public static class ProductQueries
{
    [NodeResolver]
    public static Product GetProduct(ProductId id)
    {
        return new Product { Id = id, Name = "Book" };
    }

    public static List<Product> GetProducts()
    {
        var products = new List<Product>(){
            new Product{Id=new ProductId(1), Name = "Book"}
        };
        return products;
    }
}