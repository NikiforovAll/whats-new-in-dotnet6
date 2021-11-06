using MyNamespace;
using FileScopedNamespaces;

var repository = new ProductRepository();
var product = await repository.GetProductAsync(Parse(args[0]));
WriteLine(product);
ExpressionPrinter.Print(product is not null);
