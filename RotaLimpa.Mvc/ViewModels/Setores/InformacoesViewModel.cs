using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Motoristas;
using RotaLimpa.Mvc.Services.Frotas;
using RotaLimpa.Mvc.Services.Setores;

namespace RotaLimpa.Mvc.ViewModels
{
    public class InformacoesViewModel : BaseViewModel
    {
        private MotoristaService motoristaService;
        private FrotaService frotaService;
        private SetorService setorService;

        public ObservableCollection<Motorista> Motoristas { get; set; }
        public ObservableCollection<Frota> Frotas { get; set; }
        public ObservableCollection<SetorVeiculoViewModel> SetoresVeiculos { get; set; }

        public ICommand ObterInformacoesCommand { get; }

        public InformacoesViewModel()
        {
            motoristaService = new MotoristaService();
            frotaService = new FrotaService();
            setorService = new SetorService();

            Motoristas = new ObservableCollection<Motorista>();
            Frotas = new ObservableCollection<Frota>();
            SetoresVeiculos = new ObservableCollection<SetorVeiculoViewModel>();

            ObterInformacoesCommand = new Command(async () => await ObterInformacoes());
        }

        public async Task ObterInformacoes()
        {
            try
            {
                Motoristas = await motoristaService.GetMotoristasAsync();
                Frotas = await frotaService.GetFrotasAsync();

                // Obter Setores
                var setores = await setorService.GetSetoresAsync();

                // Limpar a coleção existente
                SetoresVeiculos.Clear();

                // Criar instâncias de SetorVeiculoViewModel para cada setor e veículo associado
                foreach (var setor in setores)
                {
                    var setorVeiculo = setor.SetorVeiculos?.FirstOrDefault(); // Assumindo que há apenas um veículo associado
                    var setorVeiculoViewModel = new SetorVeiculoViewModel(setor, setorVeiculo);
                    SetoresVeiculos.Add(setorVeiculoViewModel);
                }

                OnPropertyChanged(nameof(Motoristas));
                OnPropertyChanged(nameof(Frotas));
                OnPropertyChanged(nameof(SetoresVeiculos));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter informações: {ex.Message}");
            }
        }
    }
}
