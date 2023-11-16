using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;
using Newtonsoft.Json.Linq;

namespace RotaLimpa.Mvc.Services.Motoristas
{
    public class MotoristaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota";

        public MotoristaService()
        {
            _request = new Request();
        }

        public async Task<int> PostMotoristaAsync(Motorista m)
        {
            // Chama a versão do método que não exige um token
            return await _request.PostReturnIntAsync(apiUrlBase, m);
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
