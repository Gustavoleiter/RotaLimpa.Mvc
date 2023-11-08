using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Setores;
   

namespace RotaLimpa.Mvc.ViewModels.Setores
{
    public class CadastroSetorViewModel : BaseViewModel
    {
        private SetorService setorService;

        public Setor Setor { get; set; }

        public CadastroSetorViewModel()
        {
            setorService = new SetorService();
            Setor = new Setor();
        }

        public async Task CadastrarSetor()
        {
            try
            {
                // Validar os dados do setor, se necessário

                // Chamar o serviço para cadastrar o setor
                await setorService.PostSetorAsync(Setor);

                // Limpar os campos após o cadastro bem-sucedido
                Setor = new Setor();

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Setor cadastrado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar o setor: " + ex.Message, "OK");
            }
        }
    }
}
