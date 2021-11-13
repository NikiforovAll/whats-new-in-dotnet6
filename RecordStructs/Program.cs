using Points;

// [new] Record struct
var p1 = new Point2(1, 0, 0);
var p2 = p1 with { X = 2 };

double p2x = 0;
(p2x, var y, var z) = p2;

Write(p1);
Write(p2);
Write(p2x);

// [new] Expression 'with' in structs​
var p3 = new Point4 { X = 3 };
var p4 = p3 with { X = 4 };

Write(p3);
Write(p4);

// [new] Expression 'with' in anonymous types​
var p5 = new { X = 5, Y = 0, Z = 0 };
var p6 = p5 with { X = 6 };

Write(p5);
Write(p6);
