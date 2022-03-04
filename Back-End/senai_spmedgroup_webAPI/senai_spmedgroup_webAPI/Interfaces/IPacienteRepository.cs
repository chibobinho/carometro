using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista de todos os objetos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetos</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Busca um objeto com seu respectivo ID
        /// </summary>
        /// <param name="id">ID do objeto</param>
        /// <returns>Retorna um objeto conforme seu ID</returns>
        Paciente BuscarPorId(int id);

        /// <summary>
        /// Retorna o objeto com respectivo email
        /// </summary>
        /// <param name="email">Email do objeto</param>
        /// <returns>Retorna um objeto com seu respectivo email</returns>
        Paciente BuscarPorEmail(string email);

        /// <summary>
        /// Deleta um objeto com seu respectivo ID
        /// </summary>
        /// <param name="id">ID do objeto</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um objeto com seu respectivo ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="objAtualizado">Objeto atualizado</param>
        void Atualizar(int id, Paciente objAtualizado);

        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="objAtualizado">Novo objeto</param>
        void Cadastrar(Paciente objAtualizado);
    }
}
