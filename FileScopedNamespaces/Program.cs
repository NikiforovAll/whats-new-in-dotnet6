using FileScopedNamespaces;

var repository = new ProductRepository();
var product = await repository.GetProductAsync(1);
WriteLine(product);
TestFramework.Assert(product is not null);
// C# 9
TestFramework.Assert(product is { Address: { City: "Newtown"} });
// [new] Extended property patterns
TestFramework.Assert(product is { Address.City: "Newtown" });
