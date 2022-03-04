using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdMedico { get; set; }
        public int? IdClinica { get; set; }
        public short? IdEspecialidade { get; set; }
        public string Email { get; set; }
        public string NomeMed { get; set; }
        public string CrmMed { get; set; }

        public virtual Usuario EmailNavigation { get; set; }
        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
