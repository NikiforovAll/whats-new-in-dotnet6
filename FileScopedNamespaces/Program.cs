using MyNamespace;
using FileScopedNamespaces;

var repository = new ProductRepository();
var product = await repository.GetProductAsync(Parse(args[0]));
WriteLine(product);
TestFramework.Assert(product is not null);
