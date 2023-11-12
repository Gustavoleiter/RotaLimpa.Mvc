using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Colaboradores;
using RotaLimpa.Mvc.Services.Empresas;
using RotaLimpa.Mvc.Services.Setores;
using System;
using System.Threading.Tasks;
using System.Windows.Input;


namespace RotaLimpa.Mvc.ViewModels.Setores
{
    public class CadastroSetorViewModel : BaseViewModel
    {
        private SetorService setorService;
        private ColaboradorService colaboradorService;
        private EmpresaService empresaService;

        private Colaborador colaboradorLogado;
        private Empresa empresaAssociada;

        private Setor setor;

        public Setor Setor
        {
            get { return setor; }
            set
            {
                setor = value;
                OnPropertyChanged(nameof(Setor));
            }
        }

        public DateTime DiSetor { get; set; }

        public ICommand CadastrarSetorCommand { get; private set; }

        public CadastroSetorViewModel()
        {
            setorService = new SetorService();
            colaboradorService = new ColaboradorService();
            empresaService = new EmpresaService();

            CadastrarSetorCommand = new Command(async () => await CadastrarSetor());

            // Obtenha o colaborador logado e a empresa associada no construtor

            

            // Inicialize o Setor após obter as informações necessárias
            Setor = new Setor
            {
                ColaboradorId = colaboradorLogado?.Id ?? 0,
                EmpresaId = empresaAssociada?.Id ?? 0,
            };

            DiSetor = DateTime.Now;
        }


        public async Task CadastrarSetor()
        {
            try
            {
                
                empresaAssociada = await ObterEmpresaAssociadaAsync(colaboradorLogado);
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

     


        private async Task<Empresa> ObterEmpresaAssociadaAsync(Colaborador colaborador)
        {
            try
            {
                // Implemente a lógica real para obter a empresa associada de maneira assíncrona
                return await empresaService.GetEmpresaAsync(colaborador?.EmpresaId ?? 0);
            }
            catch (Exception ex)
            {
                // Lide com a exceção (por exemplo, log, exiba uma mensagem de erro, etc.)
                Console.WriteLine($"Erro ao obter empresa associada: {ex.Message}");
                return null; // Ou outra lógica de tratamento de erro
            }
        }
    }
}
