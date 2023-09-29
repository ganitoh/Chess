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

app.Map("/step", appBuilder => 
{
    
});

app.Run();
