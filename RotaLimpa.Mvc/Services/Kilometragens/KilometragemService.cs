using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Kilometragens
{
    public class KilometragemService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/Kilometragem";

        public KilometragemService()
        {
            _request = new Request();
        }

        public async Task<int> PostKilometragem(Kilometragem kilometragem)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, kilometragem);
        }

        public async Task<ObservableCollection<Kilometragem>> GetKilometragensAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Kilometragem> listaKilometragens = await _request.GetAsync<ObservableCollection<Kilometragem>>(apiUrlBase + urlComplementar);
            return listaKilometragens;
        }

        public async Task<Kilometragem> GetKilometragemAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var kilometragem = await _request.GetAsync<Kilometragem>(apiUrlBase + urlComplementar);
            return kilometragem;
        }

        public async Task<int> PutKilometragensAsync(Kilometragem kilometragem)
        {
            var result = await _request.PutAsync(apiUrlBase, kilometragem);
            return result;
        }

        public async Task<int> DeleteKilometragemAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
