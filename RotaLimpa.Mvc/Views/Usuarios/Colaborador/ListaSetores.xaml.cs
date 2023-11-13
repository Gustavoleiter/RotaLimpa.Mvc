
using RotaLimpa.Mvc.Models;
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
    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Setor selectedItem)
        {
            // Navegue para a página de detalhes passando o item selecionado
            // Certifique-se de ajustar a classe de destino e a lógica de navegação conforme necessário
            await Shell.Current.GoToAsync($"DetalhesSetorPage?sId={selectedItem.Id}");
        }

    // Limpe a seleção para que o evento possa ser acionado novamente
    ((CollectionView)sender).SelectedItem = null;
    }


}
