using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Motoristas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RotaLimpa.Mvc.ViewModels.Motoristas
{
    public class CadastroMotoristaViewModel : INotifyPropertyChanged
    {
        private readonly MotoristaService motoristaService;
        private string _nomeMotorista;
        private DateTime _dc_Motorista = DateTime.Now;
        private string _stMotorista;

        private Motorista _novoMotorista;
        public Motorista NovoMotorista
        {
            get { return _novoMotorista; }
            set
            {
                if (_novoMotorista != value)
                {
                    _novoMotorista = value;
                    OnPropertyChanged(nameof(NovoMotorista));
                }
            }
        }

        public string NomeMotorista
        {
            get => _nomeMotorista;
            set
            {
                if (_nomeMotorista != value)
                {
                    _nomeMotorista = value;
                    OnPropertyChanged(nameof(NomeMotorista));
                }
            }
        }

        public DateTime Dc_Motorista
        {
            get => _dc_Motorista;
            set
            {
                if (_dc_Motorista != value)
                {
                    _dc_Motorista = value;
                    OnPropertyChanged(nameof(Dc_Motorista));
                }
            }
        }

        public string StMotorista
        {
            get => _stMotorista;
            set
            {
                if (_stMotorista != value)
                {
                    _stMotorista = value;
                    OnPropertyChanged(nameof(StMotorista));
                }
            }
        }

        public ICommand CadastrarMotoristaCommand { get; private set; }

        public CadastroMotoristaViewModel()
        {
            motoristaService = new MotoristaService();
            NovoMotorista = new Motorista();
            CadastrarMotoristaCommand = new Command(async () => await CadastrarMotoristaAsync());
        }

        private async Task CadastrarMotoristaAsync()
        {
            try
            {
                // Validar os dados do motorista, se necessário

                // Chamar o serviço para cadastrar o motorista
                await motoristaService.PostMotoristaAsync(NovoMotorista);

                // Limpar os campos após o cadastro bem-sucedido
                NovoMotorista = new Motorista();

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Motorista cadastrado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar o motorista: " + ex.Message, "OK");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
