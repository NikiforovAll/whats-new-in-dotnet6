using static System.Console;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;

JsonSerializerOptions options = new() { WriteIndented = true };

// ================================================================
Header("Serialization Notification");
// ================================================================

string invalidOrderJson = "{}";

var success = IgnoreErrors(() => JsonSerializer.Deserialize<Order2>(invalidOrderJson));
WriteLine($"Exception thrown: {!success}");

// ================================================================
Header("Property Ordering");
// ================================================================

Order3 order = new()
{
    OrderId = 1,
    Address = "Address",
    Quantity = 1,
    Comments = new() { "Cool", "Awesome" }
};
var serializedOrder = JsonSerializer.Serialize(order, options);
WriteLine(serializedOrder);

// ================================================================
Header("IAsyncEnumerable support && Working with Streams");
// ================================================================

var data = new { Data = RangeAsync(1, 5) };

// SerializeAsync
using var stream = new MemoryStream();
await JsonSerializer.SerializeAsync(stream, RangeAsync(1, 5), options);
stream.Position = 0;

// DeserializeAsyncEnumerable
await foreach (var i in JsonSerializer.DeserializeAsyncEnumerable<int>(stream, options))
{
    WriteLine(i);
}

// ================================================================
Header("Working with JSON DOM");
// ================================================================

// Parse

var node = JsonNode.Parse(serializedOrder);

WriteLine($"OrderId: {node["OrderId"].GetValue<int>()}");
WriteLine($"Order.Comments[0]: {node["Comments"][0].GetValue<string>()}");

// Create DOM Object via API

var jObjectOrder = new JsonObject
{
    ["OrderId"] = 1,
    ["Discounts"] = new JsonArray(
        new JsonObject
        {
            ["DiscountId"] = 1,
            ["Value"] = .05,
        },
        new JsonObject
        {
            ["DiscountId"] = 2,
            ["Value"] = .1,
        }
    ),
};

WriteLine(jObjectOrder.ToJsonString(options));

static async IAsyncEnumerable<int> RangeAsync(int start, int count)
{
    for (int i = 0; i < count; i++)
    {
        await Task.Delay(i);
        yield return start + i;
    }
}

static bool IgnoreErrors(Action operation)
{
    if (operation == null)
        return false;

    try
    {
        operation.Invoke();
    }
    catch
    {
        return false;
    }

    return true;
}

void Header (string header) => WriteLine(header);

public record class Order
{
    public int OrderId { get; init; }
    public string Address { get; init; }
    public int Quantity { get; init; }
}

// IJsonOnDeserialized, IJsonOnDeserializing, IJsonOnSerialized, IJsonOnSerializing
public record class Order2 : Order, IJsonOnDeserialized
{
    public void OnDeserialized() => this.Validate();

    private void Validate()
    {
        if (this.OrderId <= 0)
            throw new ArgumentException();
    }
}

public record class Order3
{
    [JsonPropertyOrder(-1)]
    public int OrderId { get; init; }

    [JsonPropertyOrder(1)]
    public string Address { get; init; }

    [JsonPropertyOrder(2)]
    public int Quantity { get; init; }

    [JsonPropertyOrder(99)]
    public List<string> Comments { get; init; }
}

