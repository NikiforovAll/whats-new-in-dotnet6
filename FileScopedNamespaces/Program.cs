using MyNamespace;

var repository = new ProductRepository();
var product = await repository.GetProductAsync(Parse(args[0]));
WriteLine(product);
