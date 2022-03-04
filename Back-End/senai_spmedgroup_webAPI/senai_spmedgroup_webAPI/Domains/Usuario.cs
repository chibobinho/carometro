using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public string Email { get; set; }
        public string Sigla { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        public virtual Tipousuario SiglaNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
