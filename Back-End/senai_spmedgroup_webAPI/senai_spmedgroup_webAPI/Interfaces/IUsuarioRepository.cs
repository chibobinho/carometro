using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista de todos os objetos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetos</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Retorna o objeto com respectivo email
        /// </summary>
        /// <param name="email">Email do objeto</param>
        /// <returns>Retorna um objeto com seu respectivo email</returns>
        Usuario BuscarPorEmail(string email);

        /// <summary>
        /// Retorna o usuário se condizente
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="senha">Senha</param>
        /// <returns>Objeto usuário</returns>
        Usuario Logar(string email, string senha);

        /// <summary>
        /// Deleta um objeto com seu respectivo ID
        /// </summary>
        /// <param name="email">ID do objeto</param>
        void Deletar(string email);

        /// <summary>
        /// Atualiza o objeto com seu respectivo ID
        /// </summary>
        /// <param name="objAtualizado">Objeto atualizado</param>
        void Atualizar(Usuario objAtualizado);

        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="objAtualizado">Novo objeto</param>
        void Cadastrar(Usuario objAtualizado);
    }
}
