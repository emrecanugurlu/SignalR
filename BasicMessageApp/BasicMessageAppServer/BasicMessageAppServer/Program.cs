using BasicMessageAppServer.Business;
using BasicMessageAppServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(origin => true);
    });

});

builder.Services.AddTransient<MyBusiness>();
builder.Services.AddControllers();
builder.Services.AddSignalR();
var app = builder.Build();


app.UseCors();
app.MapHub<MessageHub>("/messagehub");
app.MapControllers();
app.Run();
