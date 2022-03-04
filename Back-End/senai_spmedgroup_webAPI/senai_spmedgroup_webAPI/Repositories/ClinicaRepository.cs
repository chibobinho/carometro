using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using senai_spmedgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();
        public void Atualizar(int id, Clinica objAtualizado)
        {
            Clinica objBuscado = ctx.Clinicas.FirstOrDefault(u => u.IdClinica == id);

            if (objBuscado.NomeFantasiaClinica != null)
            {
                objBuscado.NomeFantasiaClinica = objAtualizado.NomeFantasiaClinica;
                objBuscado.RazaoSocialClinica = objAtualizado.RazaoSocialClinica;
                objBuscado.CnpjClinica = objAtualizado.CnpjClinica;
                objBuscado.EnderecoClinica = objAtualizado.EnderecoClinica;
                objBuscado.HorarioFechaClinica = objAtualizado.HorarioFechaClinica;
            }

            ctx.Clinicas.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(u => u.IdClinica == id);
        }

        public void Cadastrar(Clinica objAtualizado)
        {
            ctx.Clinicas.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(ctx.Clinicas.FirstOrDefault(u => u.IdClinica == id));
            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
