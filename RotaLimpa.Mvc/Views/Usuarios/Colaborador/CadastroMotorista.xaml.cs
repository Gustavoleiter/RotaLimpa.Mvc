using RotaLimpa.Mvc.ViewModels.Motoristas;


namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador
{
    public partial class CadastroMotorista : ContentPage
    {
        private CadastroMotoristaViewModel cadViewModel;

        public CadastroMotorista(RotaLimpa.Mvc.Models.Motorista motorista)
        {
            InitializeComponent();
            cadViewModel = new CadastroMotoristaViewModel(motorista);            

            BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext
            Title = "Novo Motorista";

        }

        public CadastroMotorista()
        {
            
            InitializeComponent();
            cadViewModel = new CadastroMotoristaViewModel();
            BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext
            Title = "Novo Motorista";

        }
       

    }
}
