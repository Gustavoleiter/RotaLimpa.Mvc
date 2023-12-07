using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Colaboradores;
using System;
using System.Security;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.ViewModels.Colaboradores
{
    public class DetalhesColaboradorViewModel : BaseViewModel
    {
        private readonly ColaboradorService colaboradorService;

        private Colaborador colaborador;

        public Colaborador Colaborador
        {
            get => colaborador;
            set
            {
                colaborador = value;
                OnPropertyChanged();
            }
        }

        private string _nomeCompleto;

        public string NomeCompleto
        {
            get => _nomeCompleto;
            set
            {
                _nomeCompleto = value;
                OnPropertyChanged();
            }
        }

        private string _nomeEmpresa;
        public string NomeEmpresa
        {
            get => _nomeEmpresa;
            set
            {
                _nomeCompleto = value;
                OnPropertyChanged();
            }
        }

        public string DataInclusao
        {
            get => _nomeEmpresa;
            set
            {
                _nomeCompleto = value;
                OnPropertyChanged();
            }
        }

        private string _situacaoColab;
        public string SituacaoColab
        {
            get => _situacaoColab;
            set
            {
                _nomeCompleto = value;
                OnPropertyChanged();
            }
        }

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set
            {
                _cpf = value;
                OnPropertyChanged();
            }
        }
    }
}
