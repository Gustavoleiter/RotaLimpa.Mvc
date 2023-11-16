using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Ruas;

namespace RotaLimpa.Mvc.ViewModels.Ruas
{
    public class CadastroRuaViewModel : BaseViewModel
    {
        private readonly RuaService ruaService;

        public Rua Rua { get; set; }

        public ICommand SalvarCommand { get; }
        public ICommand AlterarCommand { get; }
        public ICommand CancelarCommand { get; }

        public CadastroRuaViewModel()
        {
            ruaService = new RuaService();
            Rua = new Rua();

            SalvarCommand = new Command(async () => await SalvarRua());
            AlterarCommand = new Command(async () => await AlterarRua());
            CancelarCommand = new Command(CancelarCadastro);
        }

        public async Task SalvarRua()
        {
            try
            {
                // Validar os dados da rua, se necessário

                // Chamar o serviço para cadastrar a rua
                await ruaService.PostRuaAsync(Rua);

                // Limpar os campos após o cadastro bem-sucedido
                Rua = new Rua();

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Rua cadastrada com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar a rua: " + ex.Message, "OK");
            }
        }

        public async Task AlterarRua()
        {
            try
            {
                // Validar os dados da rua, se necessário

                // Chamar o serviço para alterar a rua
                await ruaService.PutRuaAsync(Rua);

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Rua alterada com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao alterar a rua: " + ex.Message, "OK");
            }
        }

        private async void CancelarCadastro()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
