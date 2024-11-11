var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Order>  repo = new()
[
    new(1,1,1,2000, "ewtg", "weqwe", "weq", "rqw", "В ожидании", "asdwq")
]; 

app.MapGet("/", () => order);
app.MapPost("/", (Order o) => repo.Add(o));
app.MapPut("/{number}", (int number) =>
{

});

app.Run();


class Order
{
    int number;
    int day;
    int month;
    int year;
    string device;
    string problemType;
    string description;
    string client;
    string status;
    string master;


    public Order(int number, int day, int month, int year, string device, string problemType, string description, string client, string status, string master)
    {
        Number = number;
        Day = day;
        Month = month;
        Year = year;
        Device = device;
        ProblemType = problemType;
        Description = description;
        Client = client;
        Status = status;
        Master = master;
    }

    public int Number { get => number; set => number = value; }
    public int Day { get => day; set => day = value; }
    public int Month { get => month; set => month = value; }
    public int Year { get => year; set => year = value; }
    public string Device { get => device; set => device = value; }
    public string ProblemType { get => problemType; set => problemType = value; }
    public string Description { get => description; set => description = value; }
    public string Client { get => client; set => client = value; }
    public string Status { get => status; set => status = value; }
    public string Master { get => master; set => master = value; }
}