using static System.Console;
using Bogus;

var faker = new OrderFaker();

var orders = faker.Generate(100);

for (var i = 0; i < orders.Count; i++)
{
    orders[i].Index = i + 1;
}

// ================================================================
Header("Chunking");
// ================================================================

foreach (var chunk in orders.Chunk(25))
{
    var sum = chunk.Sum(o => o.Quantity);

    WriteLine($"chunk[{chunk.Length}].Quantity={sum}");
}

// ================================================================
Header("Index Support for ElementAt");
// ================================================================

var order1 = orders.ElementAt(^5);

WriteLine(order1);

// ================================================================
Header("Range Support for Take");
// ================================================================

var orders2 = orders.Take(^5..);

WriteLine(string.Join(Environment.NewLine, orders2));

// ================================================================
Header("Three way zipping");
// ================================================================

string[] a1 = { "1", "2", "3" };
string[] a2 = { "One", "Two", "Three" };
float[] a3 = { 1f, 2f, 3f };

foreach ((string i, string i2, float i3) in a1.Zip(a2, a3))
{
    WriteLine($"{i}-{i2}-{i3}");
}

// ================================================================
Header("Default Parameters for Common Methods");
// ================================================================

var order2 = orders.FirstOrDefault(
    o => o.Address.Contains("Odesa"), defaultValue: orders.ElementAt(^10));

WriteLine(order2);

// ================================================================
Header("Avoiding Enumeration with TryGetNonEnumeratedCount");
// ================================================================

if (orders.TryGetNonEnumeratedCount(out int count))
    WriteLine($"The count is {count}");

// ================================================================
Header("MaxBy and MinBy");
// ================================================================

WriteLine(orders.MaxBy(o => o.Quantity));

//-----------------------------------------------------------------

void Header (string header) => WriteLine(header);

public record class Order
{
    public int OrderId { get; init; }
    public string Address { get; init; }
    public int Quantity { get; init; }

    public int Index { get; set; }
}

public class OrderFaker : Faker<Order>
{
    public OrderFaker()
    {
        RuleFor(o => o.OrderId, f => f.Random.Number(1, 100));
        RuleFor(o => o.Address, f => f.Address.FullAddress());
        RuleFor(o => o.Quantity, f => f.Random.Number(1, 10));
    }
}

