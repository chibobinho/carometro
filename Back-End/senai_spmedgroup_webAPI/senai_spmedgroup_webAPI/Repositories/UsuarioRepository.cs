using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using senai_spmedgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();
        public void Atualizar(Usuario objAtualizado)
        {
            Usuario objBuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == objAtualizado.Email);

            if(objBuscado.Email != null)
            {
                objBuscado.Email = objAtualizado.Email;
                objBuscado.Sigla = objAtualizado.Sigla;
                objBuscado.NomeUsuario = objAtualizado.NomeUsuario;
                objBuscado.SenhaUsuario = objAtualizado.NomeUsuario;
            }

            ctx.Usuarios.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Cadastrar(Usuario objAtualizado)
        {
            ctx.Usuarios.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(string email)
        {
            ctx.Usuarios.Remove(ctx.Usuarios.FirstOrDefault(u => u.Email == email));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Logar(string email, string senha)
        {
            Usuario user = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if(user != null && user.SenhaUsuario == senha)
            {
                return user;
            }
            return null;
        }
    }
}
