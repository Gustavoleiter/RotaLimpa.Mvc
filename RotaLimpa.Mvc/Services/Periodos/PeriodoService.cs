using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Periodos
{
    public class PeriodoService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Periodo";

        public PeriodoService()
        {
            _request = new Request();
        }

        public async Task<Periodo> PostPeriodoAsync(Periodo periodo)
        {
            try
            {
                // Chama a versão do método que não exige um token
                return await _request.PostAsync(apiUrlBase, periodo);
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao postar setor: {ex.Message}");
                throw;
            }
        }

        public async Task<ObservableCollection<Periodo>> GetPeriodosAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Periodo> listaPeriodos = await _request.GetAsync<ObservableCollection<Periodo>>(apiUrlBase + urlComplementar);
            return listaPeriodos;
        }

        public async Task<Periodo> GetPeriodoAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var periodo = await _request.GetAsync<Periodo>(apiUrlBase + urlComplementar);
            return periodo;
        }

        public async Task<int> PutPeriodoAsync(Periodo periodo)
        {
            var result = await _request.PutAsync(apiUrlBase, periodo);
            return result;
        }

        public async Task<int> DeletePeriodoAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
