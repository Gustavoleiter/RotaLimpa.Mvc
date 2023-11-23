using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Ruas
{
    public class RuaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Ruas";

        public RuaService()
        {
            _request = new Request();
        }

        public async Task<int> PostRuaAsync(Rua rua)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, rua);
        }

        public async Task<ObservableCollection<Rua>> GetRuasAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Rua> listaRuas = await _request.GetAsync<ObservableCollection<Rua>>(apiUrlBase + urlComplementar);
            return listaRuas;
        }

        public async Task<Rua> GetRuaAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var rua = await _request.GetAsync<Rua>(apiUrlBase + urlComplementar);
            return rua;
        }

        public async Task<int> PutRuaAsync(Rua rua)
        {
            var result = await _request.PutAsync(apiUrlBase, rua);
            return result;
        }

        public async Task<int> DeleteRuaAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
