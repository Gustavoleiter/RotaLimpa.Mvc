using RotaLimpa.Mvc.ViewModels.Setores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador
{
    public partial class CadastroSetor : ContentPage
    {
        private CadastroSetorViewModel cadViewModel;

        public CadastroSetor()
        {
            InitializeComponent();
            cadViewModel = new CadastroSetorViewModel();
            BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext

            Title = "Novo Setor";

        }
    }
}
