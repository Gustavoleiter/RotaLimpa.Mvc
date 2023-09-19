namespace RotaLimpa.Mvc.Views.Usuarios.Gestor;

public partial class CadastroColaborador : ContentPage
{
	public CadastroColaborador()
	{
        InitializeComponent();
        DropDown.SelectedIndexChanged += DropDown_SelectedIndexChanged;
    }
    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        // Navegue para a segunda página (CadastroRota.xaml)
        await Navigation.PushAsync(new CadastroRota());
    }
    private void DropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Obtenha a opção selecionada pelo usuário
        string selectedOption = (string)DropDown.SelectedItem;

        // Navegue para a página correspondente com base na seleção
        if (selectedOption == "SETORES")
        {
            Navigation.PushAsync(new CadastroSetor());
        }
        else if (selectedOption == "VEICULOS")
        {
            Navigation.PushAsync(new CadastroVeiculo());
        }
        else if (selectedOption == "COLABORADORES")
        {
            Navigation.PushAsync(new CadastroColaborador());
        }
        else if (selectedOption == "MENU")
        {
            Navigation.PushAsync(new ListaSetores());
        }
    }


}