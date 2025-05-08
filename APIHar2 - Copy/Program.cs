using API_Har2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QuestDB>(opt => opt.UseInMemoryDatabase("Quest"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/Quests", async (QuestDB db) => 
    await db.Quests.ToListAsync());

app.MapGet("/Quests/{id}", async (int id, QuestDB db) =>
    await db.Quests.FindAsync(id)
        is Quest quest
            ? Results.Ok(quest)
            : Results.NotFound());

app.MapPost("/Quests", async (Quest quest, QuestDB db) =>
{
    db.Quests.Add(quest);
    await db.SaveChangesAsync();

    return Results.Created($"/Quests/{quest.Id}", quest);
});

app.Run();