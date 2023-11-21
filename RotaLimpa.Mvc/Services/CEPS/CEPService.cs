using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.CEPs
{
    public class CEPService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/CEPs";

        public CEPService()
        {
            _request = new Request();
        }

        public async Task<int> PostCEPAsync(CEP cep)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, cep);
        }

        public async Task<ObservableCollection<CEP>> GetCEPsAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<CEP> listaCEPs = await _request.GetAsync<ObservableCollection<CEP>>(apiUrlBase + urlComplementar);
            return listaCEPs;
        }

        public async Task<CEP> GetCEPAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var cep = await _request.GetAsync<CEP>(apiUrlBase + urlComplementar);
            return cep;
        }

        public async Task<int> PutCEPAsync(CEP cep)
        {
            var result = await _request.PutAsync(apiUrlBase, cep);
            return result;
        }

        public async Task<int> DeleteCEPAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }

        internal Task<bool> CepExisteAsync(int cep)
        {
            throw new NotImplementedException();
        }
    }
}
