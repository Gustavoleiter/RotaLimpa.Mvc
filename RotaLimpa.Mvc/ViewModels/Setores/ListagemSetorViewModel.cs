using RotaLimpa.Mvc.Services.Motoristas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Services.Setores;
using System.Collections.ObjectModel;
using RotaLimpa.Mvc.Models;

namespace RotaLimpa.Mvc.ViewModels.Setores
{
    public class ListagemSetorViewModel : BaseViewModel
    {
        private SetorService pService;

        public ObservableCollection<Setor> Setores { get; set; }

        public ListagemSetorViewModel()
        {
            pService = new SetorService();
            Setores = new ObservableCollection<Setor>();
            _ = ObterSetores();
        }

        public async Task ObterSetores()
        {
            try
            {
                Setores = await pService.GetSetoresAsync();
                OnPropertyChanged(nameof(Setores));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
