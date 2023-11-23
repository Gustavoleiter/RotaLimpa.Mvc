using RotaLimpa.Mvc.ViewModels.Frotas;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class ListaFrota : ContentPage
{
    public ListaFrota()
    {
        InitializeComponent();
        BindingContext = new ListagemFrotaViewModel();
    }
}