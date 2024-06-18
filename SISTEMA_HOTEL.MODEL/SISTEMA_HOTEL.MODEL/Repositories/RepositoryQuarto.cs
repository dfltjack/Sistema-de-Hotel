using SISTEMA_HOTEL.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_HOTEL.MODEL.Repositories
{
    public class RepositoryQuarto : RepositoryBase<Quarto>
    {
        public RepositoryQuarto(SISTEMA_HOTELContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }
    }
}
