using MyNamespace;
using FileScopedNamespaces;

var repository = new ProductRepository();
var product = await repository.GetProductAsync(1);
WriteLine(product);
TestFramework.Assert(product is not null);
