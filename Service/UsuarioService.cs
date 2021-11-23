using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Worki.Data;
using Worki.Data.Models;
using Worki.Models;

namespace Worki.Service
{
    public interface IUsuarioService
    {
        Task<UsuUsuario> GetUsuarioAsync(string email);

        Task<UsuUsuario?> InsertAsync(RegisterRequest request, string password);

        Task<UsuUsuario> UpdateAsync(UsuUsuario model, string password);

        Task<bool> AuthenticateAsync(string email, string password);

        Task<bool> IsLogged();

        Task<bool> IsAdministrador();
    }

    public class UsuarioService : IUsuarioService
    {
        public enum ROLES
        {
            ADMINISTRADOR, USUARIO
        };

        private readonly WorkiContext _context;
        private readonly HttpContext httpContext;


        public UsuarioService(WorkiContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContext = httpContextAccessor.HttpContext;
        }

        async Task<UsuUsuario> IUsuarioService.GetUsuarioAsync(string email)
        {
            return await _context.UsuUsuarios.FirstOrDefaultAsync(
                a => a.UsuCorreo == email
            );
        }

        public async Task<UsuUsuario?> InsertAsync(RegisterRequest request, string password)
        {
            if (await _context.UsuUsuarios.AnyAsync(
                a => a.UsuCorreo == request.UsuCorreo
            ))
                return null;

            var empresa = new EmpEmpresa()
            {
                EmpNombre = request.EmpNombre
            };
            _context.EmpEmpresas.Add(empresa);

            // hash password
            //model.PasswordHash = BC.HashPassword(password);

            // save account
            var model = request as UsuUsuario;
            model.Emp = empresa;
            _context.UsuUsuarios.Add(model);

            PerPerfil perfil = new PerPerfil()
            {
                Usu = model,
                PerEstado = "Nuevo Usuario"
            };
            _context.PerPerfils.Add(perfil);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<UsuUsuario> UpdateAsync(UsuUsuario model, string password)
        {
            if (await _context.UsuUsuarios.AnyAsync(
                a => a.UsuCorreo == model.UsuCorreo && a.UsuId != model.UsuId
            ))
                throw new Exception("Email ya esta registrado en el sistema");

            // hash password
            // model.PasswordHash = BC.HashPassword(password);

            // save account
            _context.UsuUsuarios.Update(model);
            await _context.SaveChangesAsync();

            return await _context.UsuUsuarios.FirstOrDefaultAsync(
                a => a.UsuId == model.UsuId
            );
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var usuario = await _context.UsuUsuarios.FirstOrDefaultAsync(
                x => x.UsuCorreo == email
            );

            if (usuario == null)
                throw new Exception("Verifique Usuario");
            /*
            if (!BC.Verify(model.Password, administrador.PasswordHash))
                throw new Exception("Verifique Password");
            */

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.UsuNombre));
            identity.AddClaim(new Claim(ClaimTypes.Email, usuario.UsuCorreo));

            identity.AddClaim(new Claim(ClaimTypes.Role, ROLES.USUARIO.ToString()));
            if (usuario.UsuAdministrador)
                identity.AddClaim(new Claim(ClaimTypes.Role, ROLES.ADMINISTRADOR.ToString()));

            var principal = new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return true;
        }

        public async Task<bool> IsLogged()
        {
            var result = await httpContext.AuthenticateAsync();
            return result.Succeeded;
        }

        public async Task<bool> IsAdministrador()
        {
            if (!await IsLogged())
                return false;

            var claims = httpContext.User.Claims.Where(
                c => c.Type == ClaimTypes.Role
            );
            if (!claims.Any(c => c.Value == ROLES.ADMINISTRADOR.ToString()))
                return false;

            return true;
        }
    }
}
