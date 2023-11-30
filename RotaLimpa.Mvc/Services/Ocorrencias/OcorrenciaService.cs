using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Ocorrencias
{
    public class OcorrenciaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Ocorrencia";

        public OcorrenciaService()
        {
            _request = new Request();
        }

        public async Task<Ocorrencia> PostOcorrenciaAsync(Ocorrencia ocorrencia)
        {

            try
            {
                // Chama a versão do método que não exige um token
                return await _request.PostAsync(apiUrlBase, ocorrencia);
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao postar setor: {ex.Message}");
                throw;
            }
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
