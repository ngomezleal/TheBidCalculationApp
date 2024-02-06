using BidCalculationApi.Persistence;
using BidCalculationApi.Services.AssociationFees;
using BidCalculationApi.Services.BasicFees;
using BidCalculationApi.Services.Bid;
using BidCalculationApi.Services.SpecialFees;
using BidCalculationApi.Services.StorageFees;
using BidCalculationApi.Services.VehicleTypes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BidCalculationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var allowsOrigins = builder.Configuration.GetValue<string>("AllowsOrigins")!;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowsOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("bid", builder => builder.Expire(TimeSpan.FromSeconds(30)).Tag("bid-calculation"));
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IBidCalculationService, BidCalculationService>();
builder.Services.AddScoped<IBasicFeeService, BasicFeeService>();
builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();
builder.Services.AddScoped<ISellerSpecialFeeService, SellerSpecialFeeService>();
builder.Services.AddScoped<IAssociationFeeService, AssociationFeeService>();
builder.Services.AddScoped<IStorageFeeService, StorageFeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseOutputCache();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();