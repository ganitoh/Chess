var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("", appbuilder =>
{
    appbuilder.Run(async context =>
    {
        var response = context.Response;
        response.ContentType = "text/html";

        await response.SendFileAsync(@"html/chess.html");

    });
});

app.Map("/maxim", appBuilder => 
{
    appBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("Maxim");
    });
});

app.Run();
