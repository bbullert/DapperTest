using DapperTest.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers(options =>
//{
//    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
//}).ConfigureApiBehaviorOptions(options => 
//    {
//        options.SuppressModelStateInvalidFilter = true;
//        options.SuppressInferBindingSourcesForParameters = true;
//    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterServices();

//builder.Services.AddFluentValidation(options =>
//{
//    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder
        .WithOrigins("http://localhost:5000", "https://localhost:5001")
        .WithOrigins("http://localhost:8080", "https://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
