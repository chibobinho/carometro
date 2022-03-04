using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using senai_spmedgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();
        public void Atualizar(int id, Paciente objAtualizado)
        {
            Paciente objBuscado = ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == id);

            if(objBuscado.NomePac != null)
            {
                objBuscado.Email = objAtualizado.Email;
                objBuscado.NomePac = objAtualizado.NomePac;
                objBuscado.DataNascPac = objAtualizado.DataNascPac;
                objBuscado.TelefonePac = objAtualizado.TelefonePac;
                objBuscado.RgPac = objAtualizado.RgPac;
                objBuscado.CpfPac = objAtualizado.CpfPac;
                objBuscado.EnderecoPac = objAtualizado.EnderecoPac;
            }
            ctx.Pacientes.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorEmail(string email)
        {
            return ctx.Pacientes.FirstOrDefault(u => u.Email == email);
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == id);
        }

        public void Cadastrar(Paciente objAtualizado)
        {
            ctx.Pacientes.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pacientes.Remove(ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == id));
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
