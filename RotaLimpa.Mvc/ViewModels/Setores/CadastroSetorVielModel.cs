using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Models.Enuns;
using RotaLimpa.Mvc.Services.Setores;
using RotaLimpa.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AppRpgEtec.ViewModels.Setores
{
    [QueryProperty("SetorSelecionadoId", "sId")]

    public class CadastroSetorViewModel : BaseViewModel
    {
        private SetorService sService;

        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; set; }

        private string setorSelecionadoId;

        public string SetorSelecionadoId
        {
            set
            {
                if (value != null)
                {
                    setorSelecionadoId = Uri.UnescapeDataString(value);
                    CarregarSetor();
                }
            }
        }

        public CadastroSetorViewModel()
        {
            sService = new SetorService();
            _ = ObterTiposServico();

            SalvarCommand = new Command(async () => { await SalvarSetor(); });
            CancelarCommand = new Command(async () => CancelarCadastro());
        }

        private ServicoEnum tipoServicoSelecionado;

        public ServicoEnum TipoServicoSelecionado
        {
            get { return tipoServicoSelecionado; }
            set
            {
                if (value != null)
                {
                    tipoServicoSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        private int id;
        private int idColaborador;
        private int idEmpresa;
        private DateTime diSetor;
        private DateTime daSetor;
        private string stSetor;
        private List<Rota> rotas;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public int IdColaborador
        {
            get => idColaborador;
            set
            {
                idColaborador = value;
                OnPropertyChanged();
            }
        }

        public int IdEmpresa
        {
            get => idEmpresa;
            set
            {
                idEmpresa = value;
                OnPropertyChanged();
            }
        }

        public DateTime DiSetor
        {
            get => diSetor;
            set
            {
                diSetor = value;
                OnPropertyChanged();
            }
        }

        public DateTime DaSetor
        {
            get => daSetor;
            set
            {
                daSetor = value;
                OnPropertyChanged();
            }
        }

        public string StSetor
        {
            get => stSetor;
            set
            {
                stSetor = value;
                OnPropertyChanged();
            }
        }

        public List<Rota> Rotas
        {
            get => rotas;
            set
            {
                rotas = value;
                OnPropertyChanged();
            }
        }


        public int TiposServico
        {
            get => tiposServico;
            set
            {
                TiposServico = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ServicoEnum> listaTiposServico;
        private int tiposServico;

        public ObservableCollection<ServicoEnum> ListaTiposServico
        {
            get { return listaTiposServico; }
            set
            {
                if (value != null)
                {
                    listaTiposServico = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task ObterTiposServico()
        {
            try
            {
                ListaTiposServico = new ObservableCollection<ServicoEnum>
                {
                    ServicoEnum.ColetarLixo,
                    ServicoEnum.ColetarVarricao,
                    ServicoEnum.Coleta
                    // Adicione mais tipos conforme necessário
                };

                OnPropertyChanged(nameof(ListaTiposServico));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public string SetorSelecionado { get => setorSelecionadoId; set => setorSelecionadoId = value; }

        public async Task SalvarSetor()
        {
            try
            {
                Setor model = new Setor()
                {
                    IdColaborador = this.idColaborador,
                    IdEmpresa = this.idEmpresa,
                    Di_Setor = DateTime.Now,
                    Da_Setor = DateTime.Now,
                    StSetor = this.stSetor,
                    Id = this.id,
                    TipoServico = (ServicoEnum)TiposServico,
                };

                if (model.Id == 0)
                {
                    // Use a função PostSetorAsync para criar um novo setor
                    int newSetorId = await sService.PostSetorAsync(model);
                    model.Id = newSetorId; // Atualiza o ID com o valor retornado pela API
                }
                else
                {
                    // Use a função PutSetorAsync para atualizar um setor existente
                    await sService.PutSetorAsync(model);
                }

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

                // Limpar os campos ou executar outras ações após o salvamento

                if (Application.Current.MainPage is NavigationPage navigationPage)
                {
                    await navigationPage.PopAsync(); // Isso remove a página atual
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
            }
        }

        private async void CancelarCadastro()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async void CarregarSetor()
        {
            try
            {
                Setor s = await sService.GetSetorAsync(int.Parse(setorSelecionadoId));

                this.IdColaborador = s.IdColaborador;
                this.IdEmpresa = s.IdEmpresa;
                this.DiSetor = s.Di_Setor;
                this.DaSetor = s.Da_Setor;
                this.StSetor = s.StSetor;
                this.Id = s.Id;
                this.Rotas = (List<Rota>)s.Rotas;

                TipoServicoSelecionado = this.ListaTiposServico
                    .FirstOrDefault(tipoServico => tipoServico == s.TipoServico);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
