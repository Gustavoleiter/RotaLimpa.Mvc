using RotaLimpa.Mvc.ViewModels.Motoristas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador
{
    public partial class CadastroMotorista : ContentPage
    {
        private CadastroMotoristaViewModel viewModel;

        public CadastroMotorista()
        {
            viewModel = new CadastroMotoristaViewModel();
            InitializeComponent();
        }

        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            viewModel.CadastrarMotoristaCommand.Execute(null);
        }
    }
}
