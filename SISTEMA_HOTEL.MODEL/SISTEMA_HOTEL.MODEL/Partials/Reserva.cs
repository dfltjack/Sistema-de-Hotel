using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_HOTEL.MODEL.Partials
{
    [MetadataType(typeof(MD_Reserva))]
    public partial class Reserva
    {
        public class MD_Reserva
        {
            [Display(Name = "ID")]
            public int ReservaId { get; set; }
            [Display(Name = "ID do Quarto")]
            public int? QuartoId { get; set; }
            [Display(Name = "ID do Hóspede")]
            public int? HospedeId { get; set; }
            [Display(Name = "Data do Check-In")]
            public DateOnly DataCheckin { get; set; }
            [Display(Name = "Data do Check-Out")]
            public DateOnly DataCheckout { get; set; }
            [Display(Name = "Status da Reserva")]
            public string Status { get; set; }

            public virtual Hospede Hospede { get; set; }

            public virtual Quarto Quarto { get; set; }
        }
    }
}
