using System.Text;
using FluentEmail.MailKitSmtp;
using FluentValidation;
using Hospital_System.Extensions;
using Hospital_System.Profiles;
using Hospital.Email.Services;
using Hospital.Email.Services.Interfaces;
using HospitalSystem.BLL;
using HospitalSystem.BLL.Services.Appointment;
using HospitalSystem.BLL.Services.Appointment.Interfaces;
using HospitalSystem.BLL.Services.Auth;
using HospitalSystem.BLL.Services.Auth.Interfaces;
using HospitalSystem.BLL.Services.Doctor;
using HospitalSystem.BLL.Services.Doctor.Interfaces;
using HospitalSystem.Common.Models.Configs;
using HospitalSystem.DAL.Context;
using HospitalSystem.DAL.Entities.Base;
using HospitalSystem.DAL.Repository;
using HospitalSystem.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Configs
var jwtConfig = new JwtConfig();
builder.Configuration.Bind("Jwt", jwtConfig);
builder.Services.AddSingleton(jwtConfig);

var emailConfig = new EmailConfig();
builder.Configuration.Bind("Email", emailConfig);
emailConfig.TamplatePath = emailConfig.TamplatePath.ToAbsolutePath();
builder.Services.AddSingleton(emailConfig);

//Services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLoggerFactory(LoggerFactory.Create(cfg => cfg.AddConsole())));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<IDoctorsService, DoctorsService>();
builder.Services.AddScoped<IDoctorsSpecialtyService, DoctorsSpecialtyService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorTimeSlotsService, DoctorTimeSlotsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(AuthProfile));
builder.Services.AddAutoMapper(typeof(DoctorProfile));
builder.Services.AddAutoMapper(typeof(SpecialtyProfile));
builder.Services.AddAutoMapper(typeof(DoctorTimeSlotProfile));
builder.Services.AddAutoMapper(typeof(AppointmentProfile));
//Email
builder.Services.AddFluentEmail(emailConfig.UserName)
    .AddRazorRenderer(emailConfig.TamplatePath)
    .AddMailKitSender(new SmtpClientOptions {
        Server = emailConfig.SmtpServer,
        Port = emailConfig.SmtpPort,
        User = emailConfig.UserName,
        Password = emailConfig.Password,
        UseSsl = false,
        RequiresAuthentication = true,
    });

builder.Services.AddScoped<IEmailSender, EmailSender>();

//Auth
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)),
    ValidIssuer = jwtConfig.Issuer,
    ValidAudience = jwtConfig.Audience,
    ClockSkew = jwtConfig.ClockSkew
};
builder.Services.AddSingleton(tokenValidationParameters);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = tokenValidationParameters;
    });

//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Storage API", Version = "v1" });

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

await app.SetupRolesAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

await app.SetupRolesAsync();

app.Run();