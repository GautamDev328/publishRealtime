using CRUDAPPLICATION.BLL.IRepository;
using CRUDAPPLICATION.BLL.Repository;
using CRUDAPPLICATION.DATABASE;




using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddControllers();
//builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectionss")));
builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

//builder.Services.AddAutoMapper(typeof(ForgetPassWordMapper));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddScoped<DistrictNameRepository>();
builder.Services.AddScoped<EmployeeProfileRepository>();
builder.Services.AddScoped<StateRepository>();
builder.Services.AddScoped<HRQUESTIONREPOSITORY>();
builder.Services.AddScoped<CustomerPricesRespository>();
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<CityRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<DesignationRepository>();
builder.Services.AddScoped<EmployeeQueryRepository>();
builder.Services.AddScoped<GenderRepository>();
builder.Services.AddScoped<RELATIONREPOSITORY>();
builder.Services.AddScoped<ROLEWISEREPSITORY>();
builder.Services.AddScoped<RolewiseonlyemployeeRepository>();
builder.Services.AddScoped<UserTrailRepository>();
builder.Services.AddScoped<UseRoleRepository>();
builder.Services.AddScoped<CustomerPaymentRepository>();
builder.Services.AddScoped<RegisterationFormRepository>();// ONLY FOR LOGIN PART 
builder.Services.AddScoped<AddRelationShipRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<HrRepository>();// Only for HR DETAIL DATA 
builder.Services.AddScoped<HighestQualificaitonRepository>();
builder.Services.AddScoped<ClientQureyMessageRepository>();
builder.Services.AddScoped<BankRepository>();
builder.Services.AddScoped<BillingRepository>();
builder.Services.AddScoped<SearchService>();
builder.Services.AddScoped<Auot_CustomerhelpRepository>();
//builder.Services.AddScoped<DepartmentDataRepository>();



//TestingMode work in pincode fetch
builder.Services.AddScoped<InterviewApplicationFomRepository>();
builder.Services.AddScoped<OpenPositonAppliedRepository>();
builder.Services.AddScoped<Interviewer_applieddetailRepository>();
builder.Services.AddScoped<RescheduleDateInterviewOPENINGRepository>();


//builder.Services.AddScoped<EmailSender>();
//builder.Services.AddScoped<IEmailSender, EmailSender>();

// common billing voucher
//  mapper 
//builder.Services.AddScoped<IMapper>();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(OpenPositionAppliedMapper));


builder.Services.AddHttpContextAccessor();
//builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
          c.SwaggerDoc("v1", new OpenApiInfo
          {
                    Title = "My API",
                    Version = "v1"
          });
});
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
          app.UseSwagger();

          // Replace the incorrect method call with the correct one
        //  builder.Services.AddAutoMapper(typeof(CommonBillingVoucherMapper));
                         //     app.UseSwaggerUI();
          app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();



