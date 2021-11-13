
DateOnly date = DateOnly.MinValue;
Write(date, nameof(date));

TimeOnly time = TimeOnly.MinValue;
Write(time, nameof(time));

TimeOnly startTime = TimeOnly.Parse("11:00 PM");
var hoursWorked = 2;
var endTime = startTime.AddHours(hoursWorked);
Write(endTime, nameof(endTime));

Write(TimeOnly.Parse("12:00 AM").IsBetween(startTime, endTime));
