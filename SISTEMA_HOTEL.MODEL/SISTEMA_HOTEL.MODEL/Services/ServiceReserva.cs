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
    public class ServiceReserva
    {
        public RepositoryQuarto oRepositoryQuarto { get; set; }
        public RepositoryReserva oRepositoryReserva { get; set; }
        public RepositoryHospede oRepositoryHospede { get; set; }
        private SISTEMA_HOTELContext _context;
        public ServiceReserva(SISTEMA_HOTELContext context)
        {
            _context = context;
            oRepositoryQuarto = new RepositoryQuarto(context);
            oRepositoryReserva = new RepositoryReserva(context);
            oRepositoryHospede = new RepositoryHospede(context);
        }

        public async Task<ReservaVM> IncluirReservaAsync(ReservaVM reservaVM)
        {
            var reserva = new Reserva()
            {
                DataCheckin = reservaVM.DataCheckin,
                DataCheckout = reservaVM.DataCheckout,
                Status = reservaVM.Status,
                //Quarto = reservaVM.Quarto,
                //Hospede = reservaVM.Hospede,
            };

            await oRepositoryReserva.IncluirAsync(reserva);

            return reservaVM;
        }

        public async Task<ReservaVM> AlterarReservaAsync(ReservaVM reservaVM)
        {
            var reserva = new Reserva()
            {
                DataCheckin = reservaVM.DataCheckin,
                DataCheckout = reservaVM.DataCheckout,
                Status = reservaVM.Status,
                //Quarto = reservaVM.Quarto,
                //Hospede = reservaVM.Hospede,
            };

            await oRepositoryReserva.AlterarAsync(reserva);

            return reservaVM;
        }

    }
}
