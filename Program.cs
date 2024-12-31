using Microsoft.EntityFrameworkCore;
using Ticketier.BL.AppServices;
using Ticketier.BL.Features.Mapping.TicketMapping;
using Ticketier.BL.Interfaces;
using Ticketier.Core.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("local");
    options.UseSqlServer(ConnectionString);
});
builder.Services.AddAutoMapper(typeof(TicketProfile));
builder.Services.AddControllers();
builder.Services.AddScoped<ITicketServices, TicketServices>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
