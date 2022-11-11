using api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<Censor>();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var url = app.Configuration["blacklistUrl"] ?? "https://localhost:7241";

app.MapPost(
        "/censor",
        async (string text, Censor censor, HttpClient client) =>
        {
            censor.Blacklist = await client.GetFromJsonAsync<List<string>>(url);
            text = censor.CensorText(text);
            return text;
        }
    )
    .WithName("Censor");

app.UseFileServer();
app.MapHealthChecks("/healthz");
app.Run();
