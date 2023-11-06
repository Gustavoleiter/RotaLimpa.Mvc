using RotaLimpa.Mvc.Services.Colaboradores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;

namespace RotaLimpa.Mvc.ViewModels.Colaboradores
{ 
    public class ListagemColaboradorViewModel : BaseViewModel
    {
        private ColaboradorService pService;
        
        public ObservableCollection<Colaborador> Colaboradores { get; set; }

        public ListagemColaboradorViewModel() 
        {
            pService = new ColaboradorService();
            Colaboradores = new ObservableCollection<Colaborador>();
            _= ObterColaboradores();
        }
        public async Task ObterColaboradores()
        {
            try
            {
                Colaboradores = await pService.GetColaboradoresAsync();
                OnPropertyChanged(nameof(Colaboradores));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "ok");
            }
        }

       
    }
}
