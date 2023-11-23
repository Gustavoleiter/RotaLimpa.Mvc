using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Trajeto
{
    public class TrajetoService
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Trajetos";

        public TrajetoService()
        {
            _request = new Request();
        }

        public async Task<int> PostTrajetoAsync(Models.Trajeto trajeto)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, trajeto);
        }

        public async Task<ObservableCollection<Models.Trajeto>> GetTrajetosAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Models.Trajeto> listaTrajetos = await _request.GetAsync<ObservableCollection<Models.Trajeto>>(apiUrlBase + urlComplementar);
            return listaTrajetos;
        }

        public async Task<Models.Trajeto> GetTrajetoAsync(int trajetoId)
        {
            string urlComplementar = $"/{trajetoId}";
            var trajeto = await _request.GetAsync<Models.Trajeto>(apiUrlBase + urlComplementar);
            return trajeto;
        }

        public async Task<int> PutTrajetoAsync(Models.Trajeto trajeto)
        {
            var result = await _request.PutAsync(apiUrlBase, trajeto);
            return result;
        }

        public async Task<int> DeleteTrajetoAsync(int trajetoId)
        {
            string urlComplementar = $"/{trajetoId}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
