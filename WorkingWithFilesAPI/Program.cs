using WorkingWithFilesAPI.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IMapperService, MapperService>();
builder.Services.AddScoped<IChangeRecordMapper, ChangeRecordMapper>();

builder.Services.AddScoped<IDbChangeTracker, DbChangeToFileTracker>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
