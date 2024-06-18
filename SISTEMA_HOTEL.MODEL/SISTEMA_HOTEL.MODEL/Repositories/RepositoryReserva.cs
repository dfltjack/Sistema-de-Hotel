using SISTEMA_HOTEL.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_HOTEL.MODEL.Repositories
{
    public class RepositoryReserva : RepositoryBase<Reserva>
    {
        public RepositoryReserva(SISTEMA_HOTELContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }
    }
}
