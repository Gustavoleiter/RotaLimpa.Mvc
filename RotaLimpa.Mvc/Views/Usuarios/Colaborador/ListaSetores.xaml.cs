
using RotaLimpa.Mvc.ViewModels;
using RotaLimpa.Mvc.ViewModels.Setores;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public partial class ListaSetores : ContentPage
{
    

    public ListaSetores()
    {
        InitializeComponent();
         BindingContext = new ListagemSetorViewModel();
       
    }

    
}
