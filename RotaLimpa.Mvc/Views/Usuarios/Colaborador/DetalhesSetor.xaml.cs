using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.ViewModels.Setores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class DetalhesSetor : ContentPage
{
    CadastroSetorViewModel cadViewModel;
    public DetalhesSetor(Setor setor)
    {
        InitializeComponent();
        cadViewModel = new CadastroSetorViewModel(setor);

        BindingContext = cadViewModel; // Atribuir a instância de viewModel ao BindingContext
        Title = "Novo Motorista";

    }
}