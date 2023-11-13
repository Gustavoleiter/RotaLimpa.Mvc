// Importe o serviço de Setores
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

namespace AppRpgEtec.ViewModels.Setores // Altere o namespace para Setores
{
    [QueryProperty("SetorSelecionadoId", "sId")] // Altere para SetorSelecionadoId

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
        private int colaboradorId;
        private int empresaId;
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

        public int ColaboradorId
        {
            get => colaboradorId;
            set
            {
                colaboradorId = value;
                OnPropertyChanged();
            }
        }

        public int EmpresaId
        {
            get => empresaId;
            set
            {
                empresaId = value;
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

        private ObservableCollection<ServicoEnum> listaTiposServico;

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
                  
                    ColaboradorId = this.colaboradorId,
                    EmpresaId = this.empresaId,
                    DiSetor = this.diSetor,
                    DaSetor = DateTime.Now,
                    StSetor = this.stSetor,
                    Id = this.id,
                    TipoServico = this.tipoServicoSelecionado,
                    Rotas = this.rotas
                };

                if (model.Id == 0)
                    await sService.PostSetorAsync(model);
                else
                    await sService.PutSetorAsync(model);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
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

                this.ColaboradorId = s.ColaboradorId;
                this.EmpresaId = s.EmpresaId;
                this.DiSetor = s.DiSetor;
                this.DaSetor = s.DaSetor;
                this.StSetor = s.StSetor;
                this.Id = s.Id;
                this.Rotas = s.Rotas;

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
