using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace RotaLimpa.Mvc.Services.Motoristas
{
    public class MotoristaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/Motoristas";

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
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Motorista> listaMotoristas = await
            _request.GetAsync<ObservableCollection<Models.Motorista>>(apiUrlBase + urlComplementar);
            return listaMotoristas;
        }
        public async Task<Motorista> GetMotoristaAsync(int motoristaIdMotorista)
        {
            string urlComplementar = string.Format("/{0}", motoristaIdMotorista);
            var motorista = await _request.GetAsync<Models.Motorista>(apiUrlBase +
            urlComplementar);
            return motorista;
        }
        public async Task<int> PutMotoristaAsync(Motorista p)
        {
            var result = await _request.PutAsync(apiUrlBase, p);
            return result;
        }
        public async Task<int> DeleteMotoristaAsync(int motoristaIdMotorista)
        {
            string urlComplementar = string.Format("/{0}", motoristaIdMotorista);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
        public async Task<Motorista> PostRegistrarMotoristaAsync(Motorista u)
        {
            //Registrar: Rota para o método na API que registrar o usuário
            string urlComplementar = "/Registrar";
            u.IdMotorista = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }

    }
}
