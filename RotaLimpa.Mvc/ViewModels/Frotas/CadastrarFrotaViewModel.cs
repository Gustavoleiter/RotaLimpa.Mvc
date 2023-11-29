using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Frotas;
using System;
using System.Threading.Tasks;
using System.Windows.Input;


namespace RotaLimpa.Mvc.ViewModels.Frotas
{
    public class CadastroFrotaViewModel : BaseViewModel
    {
        private string P_Veiculo;
        private int Tmn_Veiculo;
        private double? Kilometragem;

        public string p_Veiculo
        {
            get => P_Veiculo;
            set
            {
                P_Veiculo = value;
                OnPropertyChanged();
            }
        }

        public int tmn_Veiculo
        {
            get => Tmn_Veiculo;
            set
            {
                Tmn_Veiculo = value;
                OnPropertyChanged();
            }
        }

        public double? kilometragem
        {
            get => Kilometragem;
            set
            {
                Kilometragem = value;
                OnPropertyChanged();
            }
        }

        public ICommand SalvarVeiculoCommand { get; }

        // Evento para notificar quando as informações foram salvas
        public event EventHandler<string> VeiculoSalvo;

        public CadastroFrotaViewModel()
        {
            SalvarVeiculoCommand = new Command(async () => await SalvarVeiculo());

            // Inicialize os valores padrão ou faça outras configurações necessárias
            P_Veiculo = "";
            Tmn_Veiculo = 0;
            Kilometragem = null;
        }

        private async Task SalvarVeiculo()
        {
            try
            {
                // Valide os dados, se necessário

                // Crie o objeto de veículo
                Frota frota = new Frota();
                {
                    P_Veiculo = P_Veiculo;
                    Tmn_Veiculo = Tmn_Veiculo;
                    Kilometragem = Kilometragem;
                };

                // Chame o serviço para salvar o veículo
                // Exemplo: await veiculoService.SalvarVeiculoAsync(veiculo);

                // Notifique que o veículo foi salvo
                OnVeiculoSalvo("Veículo salvo com sucesso!");
            }
            catch (Exception ex)
            {
                // Lide com erros ou exiba mensagens de erro
                OnVeiculoSalvo($"Erro ao salvar o veículo: {ex.Message}");
            }
        }

        private void OnVeiculoSalvo(string mensagem)
        {
            VeiculoSalvo?.Invoke(this, mensagem);
        }
    }
}
