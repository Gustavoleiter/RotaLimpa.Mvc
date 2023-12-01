using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Frotas;
using System;
using System.Threading.Tasks;
using System.Windows.Input;


namespace RotaLimpa.Mvc.ViewModels.Frotas
{
    public class CadastroFrotaViewModel : BaseViewModel
    {
        private readonly FrotaService frotaService;

        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; }

        private string pVeiculo;
        private double tmnVeiculo;
        private DateTime diVeiculo;
        private string stVeiculo;

        public string PVeiculo
        {
            get => pVeiculo;
            set
            {
                pVeiculo = value;
                OnPropertyChanged();
            }
        }

        public double TmnVeiculo
        {
            get => tmnVeiculo;
            set
            {
                tmnVeiculo = value;
                OnPropertyChanged();
            }
        }

        public DateTime DiVeiculo
        {
            get => diVeiculo;
            set
            {
                diVeiculo = value;
                OnPropertyChanged();
            }
        }

        public string StVeiculo
        {
            get => stVeiculo;
            set
            {
                stVeiculo = value;
                OnPropertyChanged();
            }
        }

        public CadastroFrotaViewModel()
        {
            frotaService = new FrotaService();

            SalvarCommand = new Command(async () => await SalvarFrota());
            CancelarCommand = new Command(CancelarCadastro);
        }

        public async Task SalvarFrota()
        {
            try
            {
                Frota frota = new Frota
                {
                    PVeiculo = PVeiculo,
                    TmnVeiculo = TmnVeiculo,
                    Di_Veiculo = DiVeiculo,
                    St_Veiculo = StVeiculo
                    // Adicione outras propriedades conforme necessário
                };

                await frotaService.PostFrotaAsync(frota);

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Frota cadastrada com sucesso!", "Ok");

                // Limpe os campos ou faça qualquer outra ação necessária após o cadastro bem-sucedido

                // Exemplo: Limpar campos
                PVeiculo = string.Empty;
                TmnVeiculo = 0;
                DiVeiculo = DateTime.Now;
                StVeiculo = string.Empty;

                // Navegar para a página de listagem de frotas ou realizar outra ação
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar a frota: " + ex.Message, "Ok");
            }
        }

        private void CancelarCadastro()
        {
            // Implemente a lógica para cancelar o cadastro, se necessário
        }
    }
}
