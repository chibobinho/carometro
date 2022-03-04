using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista de todos os objetos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetos</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Busca um objeto com seu respectivo ID
        /// </summary>
        /// <param name="id">ID do objeto</param>
        /// <returns>Retorna um objeto conforme seu ID</returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// Deleta um objeto com seu respectivo ID
        /// </summary>
        /// <param name="id">ID do objeto</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um objeto com seu respectivo ID
        /// </summary>
        /// <param name="objAtualizado">Objeto atualizado</param>
        void Atualizar(int id, Clinica objAtualizado);

        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="objAtualizado">Novo objeto</param>
        void Cadastrar(Clinica objAtualizado);
    }
}