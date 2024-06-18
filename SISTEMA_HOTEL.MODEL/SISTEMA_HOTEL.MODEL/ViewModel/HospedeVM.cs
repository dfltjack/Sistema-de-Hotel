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
    public class HospedeVM
    {
        [Display(Name = "Código do Hóspede")]
        public int HospedeId { get; set; }
        [Display(Name = "Nome do Hóspede")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Tamanho não pode ser menor que 5")]
        public string Nome { get; set; }

        public string? Email { get; set; }

        public string Telefone { get; set; }

        public string DocumentoIdentificacao { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

        public HospedeVM()
        {

        }

        public async static Task<List<HospedeVM>> GetHospedeVMs()
        {
            var db = new SISTEMA_HOTELContext();
            var listaHospedes = await db.Hospedes.ToListAsync();
            return await (from hos in db.Hospedes
                          select new HospedeVM
                          {
                              HospedeId = hos.HospedeId,
                              Nome = hos.Nome,
                              Email = hos.Email,
                              Telefone = hos.Telefone,
                              DocumentoIdentificacao = hos.DocumentoIdentificacao,
                              Reservas = hos.Reservas.ToList()

                          }).ToListAsync();
        }
    }
}
