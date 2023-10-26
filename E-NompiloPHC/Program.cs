using E_NompiloPHC.Data;
using E_NompiloPHC.Interface;
using E_NompiloPHC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail= false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IContact, ContactRepository>();
builder.Services.AddScoped<IBill, BillRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IHospitalInformation, HospitalInformationRepository>();
builder.Services.AddTransient<ISupplier, SupplierRepository>();
builder.Services.AddTransient<IRoom, RoomRepository>();
builder.Services.AddTransient<IMedicine, MedicineRepository>();
builder.Services.AddTransient<IInsurance, InsuranceRepository>();
builder.Services.AddTransient<ITestPrice, TestPriceRepository>();
builder.Services.AddTransient<IPrescribedMedicine, PrescribedMedicineRepository>();
builder.Services.AddTransient<IPatientReport, PatientReportRepository>();
builder.Services.AddTransient<IDoctor, DoctorRepository>();
builder.Services.AddTransient<IMedicalReport, MedicalReportRepository>();
//builder.Services.AddTransient<ILaboratory, LaboratoryRepository>();
builder.Services.AddTransient<IReferral, ReferralRepository>();
builder.Services.AddTransient<IPatient, PatientRepository>();

builder.Services.AddTransient<IApplicationUser, ApplicationUserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
DataSedding();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
void DataSedding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}

