
public record class Point(double X, double Y, double Z);

// public record class Point
// {
//     public double X {  get; init; }
//     public double Y {  get; init; }
//     public double Z {  get; init; }
// }

public readonly record struct Point2(double X, double Y, double Z);

// public record struct Point2
// {
//     public double X {  get; init; }
//     public double Y {  get; init; }
//     public double Z {  get; init; }
// }

public record struct Point3(double X, double Y, double Z);

// public record struct Point3
// {
//     public double X { get; set; }
//     public double Y { get; set; }
//     public double Z { get; set; }
// }
