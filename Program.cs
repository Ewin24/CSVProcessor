using CSVProcessor.Parsers;
using CSVProcessor.Persistence.DataProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/csv", () =>
{
    //readData
    CSVContactDataProvider provider = new CSVContactDataProvider("./Persistence/data/username.csv");
    var fileReaded = provider.Read();

    //parseData
    CSVContactParser contactParser = new CSVContactParser();
    var dataParsed = contactParser.Parse(fileReaded);

    return dataParsed;
})
.WithOpenApi();

app.Run();