using RotaLimpa.Mvc.ViewModels.Frotas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class DetalhesVeiculo : ContentPage
{
    CadastroFrotaViewModel cadViewModel;
    public DetalhesVeiculo(RotaLimpa.Mvc.Models.Frota frota)
    {
        InitializeComponent();
        cadViewModel = new CadastroFrotaViewModel(frota);

        BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext
        Title = "Novo Motorista";

    }
}