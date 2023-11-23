using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.HisLoginMs
{
    public class HisLoginMService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/HisLoginM";

        public HisLoginMService()
        {
            _request = new Request();
        }

        public async Task<int> PostHisLoginMAsync(HisLoginM hisLoginM)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, hisLoginM);
        }

        public async Task<ObservableCollection<HisLoginM>> GetHisLoginMsAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<HisLoginM> listaHisLoginMs = await _request.GetAsync<ObservableCollection<HisLoginM>>(apiUrlBase + urlComplementar);
            return listaHisLoginMs;
        }

        public async Task<HisLoginM> GetHisLoginMAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var hisLoginM = await _request.GetAsync<HisLoginM>(apiUrlBase + urlComplementar);
            return hisLoginM;
        }

        public async Task<int> PutHisLoginMAsync(HisLoginM hisLoginM)
        {
            var result = await _request.PutAsync(apiUrlBase, hisLoginM);
            return result;
        }

        public async Task<int> DeleteHisLoginMAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
