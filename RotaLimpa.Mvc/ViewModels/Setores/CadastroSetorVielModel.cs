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

        private int tipoServicoSelecionado;

        public int TipoServicoSelecionado
        {
            get { return tipoServicoSelecionado; }
            set
            {
                tipoServicoSelecionado = value;
                OnPropertyChanged();
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

        private ObservableCollection<DescricaoOcorrencia> listaTiposServico;
        private int tiposServico;

        public ObservableCollection<DescricaoOcorrencia> ListaTiposServico
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
                ListaTiposServico = new ObservableCollection<DescricaoOcorrencia>();
                ListaTiposServico.Add(new DescricaoOcorrencia() { Id = 1, Descricao = "ColetaVarricao" });
                ListaTiposServico.Add(new DescricaoOcorrencia() { Id = 2, Descricao = "ColetaLixo" });
                ListaTiposServico.Add(new DescricaoOcorrencia() { Id = 3, Descricao = "Coleta" });

                OnPropertyChanged(nameof(ListaTiposServico));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
        public async Task SalvarSetor()
        {
            try
            {
                Setor model = new Setor()
                {
                    Id = this.id,
                    idColaborador = this.IdColaborador,
                    idEmpresa = this.IdEmpresa,
                    diSetor = DateTime.Now,
                    daSetor = DateTime.Now,
                    stSetor = this.stSetor,
                    tipoServico = (ServicoEnum)TipoServicoSelecionado
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

                this.IdColaborador = s.idColaborador;
                this.IdEmpresa = s.idEmpresa;
                this.DiSetor = s.diSetor;
                this.DaSetor = s.daSetor;
                this.StSetor = s.stSetor;
                this.Id = s.Id;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
//using System;
//using System.Collections.ObjectModel;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using RotaLimpa.Mvc.Models;
//using RotaLimpa.Mvc.Models.Enuns;
//using RotaLimpa.Mvc.Services.Setores;
//using RotaLimpa.Mvc.ViewModels;


//namespace AppRpgEtec.ViewModels.Setores
//{
//    [QueryProperty("SetorSelecionadoId", "sId")]

//    public class CadastroSetorViewModel : BaseViewModel
//    {
//        private SetorService setorService;

//        public ICommand SalvarCommand { get; }
//        public ICommand CancelarCommand { get; set; }

//        private string setorSelecionadoId;

//        public string SetorSelecionadoId
//        {
//            set
//            {
//                if (value != null)
//                {
//                    setorSelecionadoId = Uri.UnescapeDataString(value);
//                    CarregarSetor();
//                }
//            }
//        }

//        public CadastroSetorViewModel()
//        {
//            setorService = new SetorService();
//            _ = ObterTiposServico();

//            SalvarCommand = new Command(async () => { await SalvarSetor(); });
//            CancelarCommand = new Command(async () => CancelarCadastro());
//        }

//        private string tipoServicoSelecionadoDescricao;

//        public string TipoServicoSelecionadoDescricao
//        {
//            get { return tipoServicoSelecionadoDescricao; }
//            set
//            {
//                if (value != null)
//                {
//                    tipoServicoSelecionadoDescricao = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        private int id;
//        private int idColaborador;
//        private int idEmpresa;
//        private DateTime diSetor;
//        private DateTime daSetor;
//        private string stSetor;
//        private List<Rota> rotas;

//        public int Id
//        {
//            get => id;
//            set
//            {
//                id = value;
//                OnPropertyChanged();
//            }
//        }

//        public ObservableCollection<DescricaoOcorrencia> ListaTiposServico { get; private set; }

//        public async Task ObterTiposServico()
//       {
//            try
//            {
//                ListaTiposServico = new ObservableCollection<DescricaoOcorrencia>();
//                ListaTiposServico.Add(new DescricaoOcorrencia() { Id = 1, Descricao = "ColetaVarricao" });
//                ListaTiposServico.Add(new DescricaoOcorrencia() { Id = 2, Descricao = "ColetaLixo" });
//                ListaTiposServico.Add(new DescricaoOcorrencia() { Id = 3, Descricao = "Coleta" });

//                OnPropertyChanged(nameof(ListaTiposServico));
//            }
//            catch (Exception ex)
//            {
//                await Application.Current.MainPage
//                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
//            }
//        }

//        public async Task SalvarSetor()
//        {
//            try
//            {
//                Setor model = new Setor()
//                {
//                    idColaborador = this.idColaborador,
//                    idEmpresa = this.idEmpresa,
//                    diSetor = DateTime.Now,
//                    daSetor = DateTime.Now,
//                    stSetor = this.stSetor,
//                    Id = this.id,
//                    tipoServico = (ServicoEnum)Enum.Parse(typeof(ServicoEnum), TipoServicoSelecionadoDescricao)
//                };

//                if (model.Id == 0)
//                {
//                    // Use a função PostSetorAsync para criar um novo setor
//                    int newSetorId = await setorService.PostSetorAsync(model);
//                    model.Id = newSetorId; // Atualiza o ID com o valor retornado pela API
//                }
//                else
//                {
//                    // Use a função PutSetorAsync para atualizar um setor existente
//                    await setorService.PutSetorAsync(model);
//                }

//                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

//                // Limpar os campos ou executar outras ações após o salvamento

//                if (Application.Current.MainPage is NavigationPage navigationPage)
//                {
//                    await navigationPage.PopAsync(); // Isso remove a página atual
//                }
//            }
//            catch (Exception ex)
//            {
//                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
//            }
//        }

//        private async void CancelarCadastro()
//        {
//            await Shell.Current.GoToAsync("..");
//        }

//        public async void CarregarSetor()
//        {
//            try
//            {
//                Setor s = await setorService.GetSetorAsync(int.Parse(setorSelecionadoId));

//                this.idColaborador = s.idColaborador;
//                this.idEmpresa = s.idEmpresa;
//                this.diSetor = s.diSetor;
//                this.daSetor = s.daSetor;
//                this.stSetor = s.stSetor;
//                this.Id = s.Id;

//                // Restante do código permanece inalterado

//            }
//            catch (Exception ex)
//            {
//                await Application.Current.MainPage
//                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
//            }
//        }
//    }
//}
