
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;


namespace RotaLimpa.Mvc.Services.Motoristas
{
    public class MotoristaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Motoristas";

        public MotoristaService()
        {
            _request = new Request();
        }

        public async Task<Motorista> PostMotoristaAsync(Motorista m)
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

        public async Task<ObservableCollection<Motorista>> GetMotoristasAsync()
        {
            string urlComplementar = string.Format("/GetAll");
            ObservableCollection<Models.Motorista> listaMotoristas = await
            _request.GetAsync<ObservableCollection<Models.Motorista>>(apiUrlBase + urlComplementar);
            return listaMotoristas;
        }

        public async Task<Motorista> GetMotoristaAsync(int motoristaId)
        {
            string urlComplementar = string.Format("/{0}", motoristaId);
            var motorista = await _request.GetAsync<Models.Motorista>(apiUrlBase + urlComplementar);
            return motorista;
        }

        public async Task<int> PutMotoristaAsync(Motorista m)
        {
            var result = await _request.PutAsync(apiUrlBase, m);
            return result;
        }

        public async Task<int> DeleteMotoristaAsync(int motoristaId)
        {
            string urlComplementar = string.Format("/{0}", motoristaId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }

        public async Task<Motorista> PostRegistrarMotoristaAsync(Motorista m)
        {
            // Registrar: Rota para o método na API que registra o motorista
            string urlComplementar = "/Registrar";
            m.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, m);
            return m;
        }
    }
}
