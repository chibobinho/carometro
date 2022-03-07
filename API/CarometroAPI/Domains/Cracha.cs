using System;
using System.Collections.Generic;

#nullable disable

namespace CarometroAPI.Domains
{
    public partial class Cracha
    {
        public int IdCracha { get; set; }
        public int? IdUsuario { get; set; }
        public string Token { get; set; }
        public DateTime UltimaAtualizacao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
