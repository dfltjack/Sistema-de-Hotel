using SISTEMA_HOTEL.MODEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_HOTEL.MODEL.Partials
{
    [MetadataType(typeof(MD_Hospede))]
    public partial class Hospede
    {
        public class MD_Hospede
        {
            [Display(Name = "ID")]
            public int HospedeId { get; set; }
            [Display(Name = "Nome")]
            public string Nome { get; set; }
            [Display(Name = "E-MAIL")]
            public string Email { get; set; }
            [Display(Name = "TELEFONE")]
            public string Telefone { get; set; }
            [Display(Name = "Doc Identificação")]
            public string DocumentoIdentificacao { get; set; }
            [Display(Name = "Número da Reserva")]
            public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        }
    }
}
