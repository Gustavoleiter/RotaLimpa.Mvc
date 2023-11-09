using RotaLimpa.Mvc.ViewModels.Colaboradores;
using RotaLimpa.Mvc.ViewModels.Motoristas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador
{
    public partial class CadastroColaborador : ContentPage
    {
        CadastroColaboradorViewModel viewModel;

        public CadastroColaborador()
        {
            InitializeComponent();
            viewModel = new CadastroColaboradorViewModel();
            BindingContext = viewModel;
        }
    }
}
