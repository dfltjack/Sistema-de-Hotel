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
    public class QuartoVM
    {
        [Display(Name = "Código do Quarto")]
        public int QuartoId { get; set; }
        [Display(Name = "Número do Quarto")]
        public int Numero { get; set; }

        public string Tipo { get; set; }

        public decimal? Preco { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

        public QuartoVM() 
        {

        }

        public async static Task<List<QuartoVM>> GetQuartoVMs()
        {
            var db = new SISTEMA_HOTELContext();
            var listaQuartos = await db.Quartos.ToListAsync();
            return await (from qua in db.Quartos
                          select new QuartoVM
                          {
                              QuartoId = qua.QuartoId,
                              Numero = qua.Numero,
                              Tipo = qua.Tipo,
                              Preco = qua.Preco,
                              Status = qua.Status,
                              Reservas = qua.Reservas.ToList()

                          }).ToListAsync();
        }
    }
}
