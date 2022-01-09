using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TLA.Persistence;
using TLA.Persistence.Repository.Implementations;
using TLA.Persistence.Repository.Interfaces;
using TLA.Persistence.Repository.Transactor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPooledDbContextFactory<TranslationDb>(
    (options) =>
    {
        options.UseSqlite($"Data Source=translation.db");
    }, 1);

builder.Services.AddTransient<IWordsRepository, WordsRepository>();
builder.Services.AddTransient(typeof(ITransactor<>), typeof(Transactor<>));

builder.Services.AddMediatR(typeof(TLA.BackEnd.Infrastructure.MediatrHandlersMarkerClass));

builder.Services.AddSwaggerGen();

var app = builder.Build();

var ctxFactory = app.Services.GetService<IDbContextFactory<TranslationDb>>();
using (var ctx = ctxFactory!.CreateDbContext())
{
    ctx.Database.Migrate();

    // password hash not available now - testing purposes only
    if (!ctx.Users.Any())
    {
        ctx.Users.Add(new TLA.Persistence.Models.User
        {
            Login = "x",
            Password = "x",
            VisibleName = "Basic User",
            GuidIdentifier = Guid.NewGuid()
        });

        ctx.SaveChanges();
    }
}

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
