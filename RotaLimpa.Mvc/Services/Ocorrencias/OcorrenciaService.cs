using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Ocorrencias
{
    public class OcorrenciaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/Ocorrencia";

        public OcorrenciaService()
        {
            _request = new Request();
        }

        public async Task<int> PostOcorrenciaAsync(Ocorrencia ocorrencia)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, ocorrencia);
        }

        public async Task<ObservableCollection<Ocorrencia>> GetOcorrenciasAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Ocorrencia> listaOcorrencias = await _request.GetAsync<ObservableCollection<Ocorrencia>>(apiUrlBase + urlComplementar);
            return listaOcorrencias;
        }

        public async Task<Ocorrencia> GetOcorrenciaAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var ocorrencia = await _request.GetAsync<Ocorrencia>(apiUrlBase + urlComplementar);
            return ocorrencia;
        }

        public async Task<int> PutOcorrenciaAsync(Ocorrencia ocorrencia)
        {
            var result = await _request.PutAsync(apiUrlBase, ocorrencia);
            return result;
        }

        public async Task<int> DeleteOcorrenciaAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
