using Newtonsoft.Json;
using RotaLimpa.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Colaboradores
{
    public class ColaboradorService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Colaboradores";

        public ColaboradorService()
        {
            _request = new Request();
        }


        public async Task<Colaborador> PostColaboradorAsync(Colaborador m)
        {
            try
            {
                // Chama a versão do método que não exige um token
                return await _request.PostAsync(apiUrlBase, m);
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao postar setor: {ex.Message}");
                throw;
            }
        }
        public async Task<ObservableCollection<Colaborador>> GetColaboradoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Colaborador> listaColaboradores = await
            _request.GetAsync<ObservableCollection<Models.Colaborador>>(apiUrlBase + urlComplementar);
            return listaColaboradores;
        }
        public async Task<Colaborador> GetColaboradorAsync(int colaboradorIdColaborador)
        {
            string urlComplementar = string.Format("/{0}", colaboradorIdColaborador);
            var colaborador = await _request.GetAsync<Models.Colaborador>(apiUrlBase +
            urlComplementar);
            return colaborador;
        }
        public async Task<int> PutColaboradorAsync(Colaborador p)
        {
            var result = await _request.PutAsync(apiUrlBase, p);
            return result;
        }
        public async Task<int> DeleteColaboradorAsync(int colaboradorIdColaborador)
        {
            string urlComplementar = string.Format("/{0}", colaboradorIdColaborador);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
        public async Task<Colaborador> PostRegistrarColaboradorAsync(Colaborador u)
        {
            //Registrar: Rota para o método na API que registrar o usuário
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }
        public async Task<Colaborador> ObterColaboradorLogadoAsync()
        {
            // Implemente a lógica real para obter o colaborador logado de maneira assíncrona
            // Substitua o retorno e adicione tratamento de exceções conforme necessário
            return await _request.GetAsync<Colaborador>(apiUrlBase + "/ObterColaboradorLogado");
        }

        public async Task<Colaborador> PostAutenticarUsuarioAsync(int Id, Colaborador c)
        {
            try
            {
                // Log para verificar os valores antes de enviar a solicitação
                Debug.WriteLine($"Autenticar Colaborador - Id: {c.Id}, Login: {c.Login}, Senha: {c.Senha}");

                // Autenticar: Rota para o método na API que autentica com login e senha
                string urlComplementar = $"/Authenticate/{c.Id}";
                c = await _request.PostAsync(apiUrlBase + urlComplementar, c);

                // Log para verificar a resposta da API
                Debug.WriteLine($"Resposta da API: {JsonConvert.SerializeObject(c)}");

                return c;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro na autenticação do colaborador: {ex.Message}");
                throw; // Rejoga a exceção para que ela possa ser tratada no código chamador
            }
        }
    }
}

