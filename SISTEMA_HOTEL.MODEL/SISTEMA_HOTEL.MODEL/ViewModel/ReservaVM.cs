using Microsoft.EntityFrameworkCore;
using SISTEMA_HOTEL.MODEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_HOTEL.MODEL.ViewModel
{
    public class ReservaVM
    {
        [Display(Name = "Código da Reserva")]
        public int ReservaId { get; set; }
        [Display(Name = "Código do Quarto")]
        //public int? QuartoId { get; set; }
        //[Display(Name = "Código do Hóspede")]
        //public int? HospedeId { get; set; }

        public DateOnly DataCheckin { get; set; }

        public DateOnly DataCheckout { get; set; }

        public string Status { get; set; }

        //public virtual Hospede Hospede { get; set; }

        //public virtual Quarto Quarto { get; set; }

        public ReservaVM()
        {

        }

        public async static Task<List<ReservaVM>> GetReservaVMs()
        {
            var db = new SISTEMA_HOTELContext();
            var listaReservas = await db.Reservas.ToListAsync();
            return await (from res in db.Reservas
                          select new ReservaVM
                          {
                              ReservaId = res.ReservaId,
                              DataCheckin = res.DataCheckin,
                              DataCheckout = res.DataCheckout,
                              Status = res.Status,
                              //HospedeId = res.HospedeId,
                              //QuartoId = res.QuartoId,

                          }).ToListAsync();
        }
    }
}
