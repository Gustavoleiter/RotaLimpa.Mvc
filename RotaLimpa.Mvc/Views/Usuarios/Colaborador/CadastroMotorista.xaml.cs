using AppRpgEtec.ViewModels.Motoristas;
using RotaLimpa.Mvc.ViewModels.Motoristas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador
{
    public partial class CadastroMotorista : ContentPage
    {
        private CadastroMotoristaViewModel cadViewModel;

        public CadastroMotorista()
        {
            
            InitializeComponent();
            cadViewModel = new CadastroMotoristaViewModel();
            BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext
            Title = "Novo Motorista";

        }


    }
}
