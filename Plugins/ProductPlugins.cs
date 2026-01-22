using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace first_project_semantic_kernel.Plugins;

public class ProductPlugins
{
    private readonly List<Product> _products =
    [
        new Product(1, "Mousepad", true, 10),
        new Product(2, "Mouse Gamer", false, 8),
        new Product(3, "Teclado Gamer", true, 1),
        new Product(4, "Capa Monitor", false, 1),
        new Product(5, "Monitor Gamer", true, 5)
    ];

    [KernelFunction("get_products")]
    [Description("Return list of products")]
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        await Task.Delay(1);
        return _products;
    }
    
    [KernelFunction("get_state")]
    [Description("Get the state of a particular product")]
    public async Task<Product?> GetStateAsync(
        [Description("The ID of the product")] int id)
    {
        await Task.Delay(1);
        return _products.FirstOrDefault(x => x.Id == id);
    }
    
    [KernelFunction("change_state")]
    [Description("Chages the state of the product")]
    public async Task<Product?> ChangeStateAsync(
        [Description("The ID of the product")] int id,
        [Description("The content of the product to be modified")] Product model)
    {
        await Task.Delay(1);
        
        var product = _products.FirstOrDefault(x => x.Id == id);

        return product is null 
            ? null 
            : new Product(model.Id, model.Title, model.IsActive, model.Quantity);
    }
}

public record Product(int Id, string Title, bool IsActive, int Quantity);