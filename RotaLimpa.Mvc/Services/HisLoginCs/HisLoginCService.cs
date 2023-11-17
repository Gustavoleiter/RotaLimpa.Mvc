using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.HisLoginCs
{
    public class HisLoginCService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/HisLoginC";

        public HisLoginCService()
        {
            _request = new Request();
        }

        public async Task<int> PostHisLoginCAsync(HisLoginC hisLoginC)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, hisLoginC);
        }

        public async Task<ObservableCollection<HisLoginC>> GetHisLoginCsAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<HisLoginC> listaHisLoginCs = await _request.GetAsync<ObservableCollection<HisLoginC>>(apiUrlBase + urlComplementar);
            return listaHisLoginCs;
        }

        public async Task<HisLoginC> GetHisLoginCAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var hisLoginC = await _request.GetAsync<HisLoginC>(apiUrlBase + urlComplementar);
            return hisLoginC;
        }

        public async Task<int> PutHisLoginCAsync(HisLoginC hisLoginC)
        {
            var result = await _request.PutAsync(apiUrlBase, hisLoginC);
            return result;
        }

        public async Task<int> DeleteHisLoginCAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
