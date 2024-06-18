using SISTEMA_HOTEL.MODEL.Interfaces;
using SISTEMA_HOTEL.MODEL.Models;
using SISTEMA_HOTEL.MODEL.Repositories;
using SISTEMA_HOTEL.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_HOTEL.MODEL.Services
{
    public class ServiceQuarto
    {
        public RepositoryQuarto oRepositoryQuarto { get; set; }
        public RepositoryReserva oRepositoryReserva { get; set; }
        private SISTEMA_HOTELContext _context;
        public ServiceQuarto(SISTEMA_HOTELContext context)
        {
            _context = context;
            oRepositoryQuarto = new RepositoryQuarto(context);
            oRepositoryReserva = new RepositoryReserva(context);
        }

        public async Task<QuartoVM> IncluirQuartoAsync(QuartoVM quartoVM)
        {
            var quarto = new Quarto()
            {
                Numero = quartoVM.Numero,
                Tipo = quartoVM.Tipo,
                Preco = quartoVM.Preco,
                Status = quartoVM.Status,
                Reservas = quartoVM.Reservas,
            };

            await oRepositoryQuarto.IncluirAsync(quarto);
            return quartoVM;
        }
        public async Task<QuartoVM> AlterarQuartoAsync(QuartoVM quartoVM)
        {
            var quarto = new Quarto()
            {
                Numero = quartoVM.Numero,
                Tipo = quartoVM.Tipo,
                Preco = quartoVM.Preco,
                Status = quartoVM.Status,
                Reservas = quartoVM.Reservas,
            };

            await oRepositoryQuarto.AlterarAsync(quarto);
            return quartoVM;
        }
    }
}
