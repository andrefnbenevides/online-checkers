using Microsoft.AspNetCore.ResponseCompression;
using OnlineCheckers.Server.Data;
using OnlineCheckers.Server.Hubs;
using OnlineCheckers.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<GameManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapHub<MultiplayerHub>(SharedConstants.MULTIPLAYER_HUB_PATTERN_CONNECT);
app.MapFallbackToFile("index.html");

app.Run();
