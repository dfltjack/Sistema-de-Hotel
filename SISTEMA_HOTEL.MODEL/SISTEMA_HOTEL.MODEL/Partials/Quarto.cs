using SISTEMA_HOTEL.MODEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_HOTEL.MODEL.Partials
{
    [MetadataType(typeof(MD_Quarto))]
    public partial class Quarto
    {
        public class MD_Quarto 
        {
            [Display(Name = "ID")]
            public int QuartoId { get; set; }
            [Display(Name = "Número do Quarto")]
            public int Numero { get; set; }
            [Display(Name = "Tipo do Quarto")]
            public string Tipo { get; set; }
            [Display(Name = "Preço")]
            public decimal? Preco { get; set; }
            [Display(Name = "Status do Quarto")]
            public string Status { get; set; }
            [Display(Name = "Número da Reserva")]
            public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        }
    }
}
