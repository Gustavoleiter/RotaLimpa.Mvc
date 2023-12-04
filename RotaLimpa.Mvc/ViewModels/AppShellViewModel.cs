using RotaLimpa.Mvc.Services.Colaboradores;
using RotaLimpa.Mvc.Services.Motoristas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.ViewModels
{
   public  class AppShellViewModel : BaseViewModel
    {
        private MotoristaService motoristaService;
        private ColaboradorService colaboradorService;

        public AppShellViewModel()
        {
            motoristaService = new MotoristaService();
            colaboradorService = new ColaboradorService();
        }
    }
}
