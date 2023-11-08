using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Colaboradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.ViewModels.Colaboradores
{
    public class CadastroColaboradorViewModel : BaseViewModel
    {
        private readonly ColaboradorService colaboradorService;

        public Colaborador Colaborador { get; set; }

        public CadastroColaboradorViewModel()
        {
            colaboradorService = new ColaboradorService();
            Colaborador = new Colaborador();
        }

        public async Task CadastrarColaborador()
        {
            try
            {
                // Validar os dados do colaborador, se necessário

                // Chamar o serviço para cadastrar o colaborador
                await colaboradorService.PostColaboradorAsync(Colaborador);

                // Limpar os campos após o cadastro bem-sucedido
                Colaborador = new Colaborador();

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Colaborador cadastrado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Erro ao cadastrar o colaborador: " + ex.Message, "OK");
            }
        }
    }
}
