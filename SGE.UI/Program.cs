using SGE.Aplicacion;
using SGE.Repositorios;
using SGE.UI.Components;

BaseSqlite.Inicializar();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    // CASOS DE EXPEDIENTE
    .AddTransient<CasoDeUsoExpedienteAlta>()
    .AddTransient<CasoDeUsoExpedienteBaja>()
    .AddTransient<CasoDeUsoExpedienteModificacion>()
    .AddTransient<CasoDeUsoExpedienteListar>()
    .AddTransient<CasoDeUsoExpedienteConsultaId>()
    .AddTransient<CasoDeUsoExpedienteContarTotal>()
    // CASOS DE TRAMITE
    .AddTransient<CasoDeUsoTramiteAlta>()
    .AddTransient<CasoDeUsoTramiteBaja>()
    .AddTransient<CasoDeUsoTramiteModificacion>()
    .AddTransient<CasoDeUsoTramiteListar>()
    .AddTransient<CasoDeUsoTramiteContarTotal>()
    .AddTransient<CasoDeUsoTramiteContarPorEtiqueta>()
    .AddTransient<CasoDeUsoTramiteContarPorExpId>()
    .AddTransient<CasoDeUsoTramiteConsultaEtiqueta>()
    .AddTransient<CasoDeUsoTramiteConsultaId>()
    .AddTransient<CasoDeUsoTramiteConsultaExpId>()
    // CASOS DE USUARIO
    .AddTransient<CasoDeUsoUsuarioSignup>()
    .AddTransient<CasoDeUsoUsuarioLogin>()
    .AddTransient<CasoDeUsoUsuarioEliminar>()
    .AddTransient<CasoDeUsoUsuarioModificacion>()
    .AddTransient<CasoDeUsoUsuarioModContrase˝a>()
    .AddTransient<CasoDeUsoUsuarioConsultaId>()
    .AddTransient<CasoDeUsoUsuarioListar>()
    .AddTransient<CasoDeUsoUsuarioContarTotal>()
    .AddTransient<CasoDeUsoUsuarioOtorgarPermiso>()
    .AddTransient<CasoDeUsoUsuarioQuitarPermiso>()
    // VALIDADORES
    .AddTransient<ExpedienteValidador>()
    .AddTransient<TramiteValidador>()
    .AddTransient<UsuarioValidador>()
    // REPOSITORIOS
    .AddTransient<IUsuarioRepositorio, RepositorioUsuarios>()
    .AddTransient<IExpedienteRepositorio, RepositorioExpediente>()
    .AddTransient<ITramiteRepositorio, RepositorioTramite>()
    // SERVICIOS
    .AddTransient<IServicioAutorizacion, ServicioAutorizacion>()
    .AddTransient<IServicioActualizacionEstado, ServicioActualizacionEstado>()
    .AddTransient<IServicioHash, ServicioHash>()
    .AddTransient<IEspecificacionCambioEstado, EspecificacionCambioEstado>()
    // CONTEXTO
    .AddScoped<BaseContext>()
    // SESION
    .AddSingleton<SesionActual>();

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
