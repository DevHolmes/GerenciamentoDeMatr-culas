using GerenciamentoDeMatrículas;
using GerenciamentoDeMatrículas.Models;
using GerenciamentoDeMatrículas.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
//builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));
builder.Services.AddTransient<AlunoService>();
builder.Services.AddTransient<CursoService>();
builder.Services.AddTransient<DisciplinaService>();
builder.Services.AddTransient<MatriculaService>();

//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//builder.Services.AddSingleton(builder.Configuration);
//builder.Services.AddTransient<DatabaseContext>();
//builder.Services.BuildServiceProvider();


//builder.Services.AddDbContext<DatabaseContext>(options =>
//{
//    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"));
//});

//builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciamentoDeMatriculas", Version = "v1" }); });
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Host.ConfigureDefaults(args).ConfigureAppConfiguration((hostingContext, config) => { config.AddJsonFile("appsettings.json", optional: false); });
//public static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureAppConfiguration((hostingContext, config) =>
//        {
//            config.AddJsonFile("appsettings.json", optional: false);
//        })
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Startup>();
//        });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","GerenciamentoDeMatriculas v1"));
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
