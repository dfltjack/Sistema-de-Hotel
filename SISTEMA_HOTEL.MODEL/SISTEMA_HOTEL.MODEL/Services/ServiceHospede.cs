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
    public class ServiceHospede
    {
        public RepositoryHospede oRepositoryHospede { get; set; }
        public RepositoryReserva oRepositoryReserva { get; set; }
        private SISTEMA_HOTELContext _context;

        public ServiceHospede( SISTEMA_HOTELContext context)
        {
            _context = context;
            oRepositoryHospede = new RepositoryHospede(context);
            oRepositoryReserva = new RepositoryReserva(context);
            
        }

        public async Task<HospedeVM> IncluirHospedeAsync(HospedeVM hospedeVM)
        {
            var hospede = new Hospede()
            {
                Nome = hospedeVM.Nome,
                Email = hospedeVM.Email,
                Telefone = hospedeVM.Telefone,
                DocumentoIdentificacao = hospedeVM.DocumentoIdentificacao,
                Reservas = hospedeVM.Reservas,
            };            

            await oRepositoryHospede.IncluirAsync(hospede);

            return hospedeVM;
        }

        public async Task<HospedeVM> AlterarHospedeAsync(HospedeVM hospedeVM)
        {
            var hospede = new Hospede()
            {
                Nome = hospedeVM.Nome,
                Email = hospedeVM.Email,
                Telefone = hospedeVM.Telefone,
                DocumentoIdentificacao = hospedeVM.DocumentoIdentificacao,
                Reservas = hospedeVM.Reservas,
            };

            await oRepositoryHospede.AlterarAsync(hospede);

            return hospedeVM;
        }
    }
}
