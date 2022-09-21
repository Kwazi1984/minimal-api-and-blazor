using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddCors();

// Add Keycloak authorization
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
{
    o.RequireHttpsMetadata = false;
    o.Authority = builder.Configuration["Keycloak:AuthorityUrl"];
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidAudience = builder.Configuration["Keycloak:ClientId"],
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Keycloak:AuthorityUrl"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Minimal Api Documents is working!");

app.MapGet("/documents", async (DataContext db) =>
    await db.Doucments.OrderByDescending(x => x.Id).ToListAsync());

app.MapGet("/documents/{id}", async (int id, DataContext db) =>
    await db.Doucments.FindAsync(id)
        is Document document
            ? Results.Ok(document)
            : Results.NotFound());

app.MapPost("/documents", async (Document document, DataContext db) =>
{
    db.Doucments.Add(document);
    await db.SaveChangesAsync();

    return Results.Created($"/documents/{document.Id}", document);
});

app.MapPut("/documents/{id}", async (int id, Document inputDocument, DataContext db) =>
{
    var document = await db.Doucments.FindAsync(id);

    if (document is null) return Results.NotFound();

    document.Index = inputDocument.Index;
    document.Title = inputDocument.Title;
    document.Subject = inputDocument.Subject;
    document.Company = inputDocument.Company;
    document.Date = inputDocument.Date;
    document.Amount = inputDocument.Amount;
    document.Currency = inputDocument.Currency;
    document.Author = inputDocument.Author;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/documents/{id}", async (int id, DataContext db) =>
{
    if (await db.Doucments.FindAsync(id) is Document documemnt)
    {
        db.Doucments.Remove(documemnt);
        await db.SaveChangesAsync();
        return Results.Ok(documemnt);
    }

    return Results.NotFound();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

class Document
{
    public int Id { get; set; }
    public string? Index { get; set; }
    public string? Title { get; set; }
    public string? Subject { get; set; }
    public string? Company { get; set; }
    public DateTime Date { get; set; }
    public int Amount { get; set; }
    public string? Currency { get; set; }
    public string? Author { get; set; }
}

class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<Document> Doucments => Set<Document>();
}