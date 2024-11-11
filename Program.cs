var builder = WebApplication.CreateBuilder(args);

// Добавление и настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // Разрешаем доступ с любых источников
              .AllowAnyMethod()    // Разрешаем любые методы (GET, POST, PUT, DELETE и т.д.)
              .AllowAnyHeader();   // Разрешаем любые заголовки
    });
});

var app = builder.Build();

// Применение CORS политики
app.UseCors("AllowAll");

List<Order> repo =
[
    new(1, 1, 1, 2000, "ewtg", "weqwe", "weq", "rqw", "В ожидании", "asdwq"),
    new(2, 1, 1, 2000, "eqwewtg", "wweqwe", "wqweq", "rasqw", "В ожидании", "assadfdwq"),
    new(3, 1, 1, 2000, "ewtg", "weqwe", "weq", "rqw", "В ожидании", "asdwq"),
];

app.MapGet("/", () => repo);
app.MapPost("/", (Order o) => repo.Add(o));
app.MapPut("/{number}", (int number, OrderUpdateDTO dto) =>
{
    Order buffer = repo.Find(o => o.Number == number);
    if (buffer == null)
        return Results.NotFound("No yet");
    buffer.Status = dto.Status;
    buffer.Master = dto.Master;
    buffer.Description = dto.Description;
    return Results.Json(buffer);
});

app.Run();

class OrderUpdateDTO
{
    public string Status { get; set; }
    public string Description { get; set; }
    public string Master { get; set; }
}

class Order
{
    public int Number { get; set; }
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public string Device { get; set; }
    public string ProblemType { get; set; }
    public string Description { get; set; }
    public string Client { get; set; }
    public string Status { get; set; }
    public string Master { get; set; }

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
}