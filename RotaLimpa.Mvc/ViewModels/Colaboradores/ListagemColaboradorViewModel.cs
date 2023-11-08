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
        private readonly ColaboradorService colaboradorService;

        public ObservableCollection<Colaborador> Colaboradores { get; set; }

        public ListagemColaboradorViewModel()
        {
            colaboradorService = new ColaboradorService();
            Colaboradores = new ObservableCollection<Colaborador>();
            _ = ObterColaboradores();
        }

        public async Task ObterColaboradores()
        {
            try
            {
                Colaboradores = await colaboradorService.GetColaboradoresAsync();
                OnPropertyChanged(nameof(Colaboradores));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao obter a lista de colaboradores: " + ex.Message, "OK");
            }
        }


    }
}
