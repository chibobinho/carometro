using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public string NomeFantasiaClinica { get; set; }
        public string RazaoSocialClinica { get; set; }
        public string EnderecoClinica { get; set; }
        public TimeSpan? HorarioAbreClinica { get; set; }
        public TimeSpan? HorarioFechaClinica { get; set; }
        public string CnpjClinica { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
