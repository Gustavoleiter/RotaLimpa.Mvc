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

namespace RotaLimpa.Mvc.Services.Setores
{
    public class SetorService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/Setores";

        public SetorService()
        {
            _request = new Request();
        }

        public async Task<int> PostSetorAsync(Setor s)
        {
            // Chama a versão do método que não exige um token
            return await _request.PostReturnIntAsync(apiUrlBase, s);
        }

        public async Task<ObservableCollection<Setor>> GetSetoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Setor> listaSetores = await
            _request.GetAsync<ObservableCollection<Models.Setor>>(apiUrlBase + urlComplementar);
            return listaSetores;
        }

        public async Task<Setor> GetSetorAsync(int setorId)
        {
            string urlComplementar = string.Format("/{0}", setorId);
            var setor = await _request.GetAsync<Models.Setor>(apiUrlBase + urlComplementar);
            return setor;
        }

        public async Task<int> PutSetorAsync(Setor s)
        {
            var result = await _request.PutAsync(apiUrlBase, s);
            return result;
        }

        public async Task<int> DeleteSetorAsync(int setorId)
        {
            string urlComplementar = string.Format("/{0}", setorId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }

        public async Task<Setor> PostRegistrarSetorAsync(Setor s)
        {
            // Registrar: Rota para o método na API que registra o setor
            string urlComplementar = "/Registrar";
            s.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, s);
            return s;
        }
    }
}
