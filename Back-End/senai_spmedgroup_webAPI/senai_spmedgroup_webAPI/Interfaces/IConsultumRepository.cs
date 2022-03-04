using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Interfaces
{
    interface IConsultumRepository
    {
        /// <summary>
        /// Lista de todos os objetos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetos</returns>
        List<Consultum> ListarTodos();

        /// <summary>
        /// Lista de todos os objetos cadastrados com o id do médico
        /// </summary>
        /// <param name="id">Id médico</param>
        /// <returns>Uma lista de consultas</returns>
        List<Consultum> ListarPorMed(int id);

        /// <summary>
        /// Lista de todos os objetos cadastrados com o id do paciente
        /// </summary>
        /// <param name="id">Id paciente</param>
        /// <returns>Lista de consultas</returns>
        List<Consultum> ListarPorPac(int id);

        /// <summary>
        /// Busca um objeto com seu respectivo ID
        /// </summary>
        /// <param name="id">ID do objeto</param>
        /// <returns>Retorna um objeto conforme seu ID</returns>
        Consultum BuscarPorId(int id);

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
        void Atualizar(int id, Consultum objAtualizado);

        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="objAtualizado">Novo objeto</param>
        void Cadastrar(Consultum objAtualizado);
    }
}
