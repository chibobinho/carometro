using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Médico é necessário para agendar uma consulta.")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "Paciente é necessário para agendar uma consulta.")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "Situação é necessário para agendar uma consulta.")]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "Data é necessário para agendar uma consulta.")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "Valor é necessário para agendar uma consulta.")]
        public decimal? Valor { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao SituacaoNavigation { get; set; }
    }
}
