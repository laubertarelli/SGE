using SGE.Application;
using SGE.Repositories;
using SGE.UI.Components;

FmsSqlite.Initialize();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    // File Use Cases
    .AddTransient<AddFileUseCase>()
    .AddTransient<DeleteFileUseCase>()
    .AddTransient<UpdateFileUseCase>()
    .AddTransient<GetAllFilesUseCase>()
    .AddTransient<GetFileByIdUseCase>()
    .AddTransient<CountAllFilesUseCase>()
    // Procedure Use Cases
    .AddTransient<AddProcedureUseCase>()
    .AddTransient<DeleteProcedureUseCase>()
    .AddTransient<UpdateProcedureUseCase>()
    .AddTransient<GetAllProceduresUseCase>()
    .AddTransient<CountAllProceduresUseCase>()
    .AddTransient<CountProceduresByLabelUseCase>()
    .AddTransient<CountProceduresByFileIdUseCase>()
    .AddTransient<GetProceduresByLabelUseCase>()
    .AddTransient<GetProcedureByIdUseCase>()
    .AddTransient<GetProceduresByFileIdUseCase>()
    // User Use Cases
    .AddTransient<SignupUserUseCase>()
    .AddTransient<LoginUserUseCase>()
    .AddTransient<DeleteUserUseCase>()
    .AddTransient<UpdateUserUseCase>()
    .AddTransient<UpdateUserPasswordUseCase>()
    .AddTransient<GetUserByIdUseCase>()
    .AddTransient<GetAllUsersUseCase>()
    .AddTransient<CountAllUsersUseCase>()
    .AddTransient<GrantUserPermissionUseCase>()
    .AddTransient<RemoveUserPermissionUseCase>()
    // Validators
    .AddTransient<FileValidator>()
    .AddTransient<ProcedureValidator>()
    .AddTransient<UserValidator>()
    // Repositories
    .AddTransient<IUserRepository, UserRepository>()
    .AddTransient<IFileRepository, FileRepository>()
    .AddTransient<IProcedureRepository, ProcedureRepository>()
    // Services
    .AddTransient<IAuthorizationService, AuthorizationService>()
    .AddTransient<IUpdateStateService, UpdateStateService>()
    .AddTransient<IHashService, HashService>()
    .AddTransient<ISpecificationStateChange, SpecificationStateChange>()
    // Context
    .AddScoped<FmsContext>()
    // Session
    .AddSingleton<Session>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
