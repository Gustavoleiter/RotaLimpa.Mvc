using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Frotas
{
    public class FrotaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Frotas";

        public FrotaService()
        {
            _request = new Request();
        }

        public async Task<int> PostFrotaAsync(Frota frota)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, frota);
        }

        public async Task<ObservableCollection<Frota>> GetFrotasAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Frota> listaFrotas = await _request.GetAsync<ObservableCollection<Frota>>(apiUrlBase + urlComplementar);
            return listaFrotas;
        }

        public async Task<Frota> GetFrotaAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var frota = await _request.GetAsync<Frota>(apiUrlBase + urlComplementar);
            return frota;
        }

        public async Task<int> PutFrotaAsync(Frota frota)
        {
            var result = await _request.PutAsync(apiUrlBase, frota);
            return result;
        }

        public async Task<int> DeleteFrotaAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
