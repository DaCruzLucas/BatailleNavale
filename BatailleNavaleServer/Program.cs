using BatailleNavaleServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddSingleton<BatailleNavaleService>();
var app = builder.Build();

app.MapHub<BatailleNavaleHub>("/bn");
app.Run();