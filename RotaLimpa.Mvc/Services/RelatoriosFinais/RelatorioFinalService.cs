using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Relatorios
{
    public class RelatorioFinalService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/RelatorioFinal";

        public RelatorioFinalService()
        {
            _request = new Request();
        }

        public async Task<RelatorioFinal> PostRelatorioFinalAsync(RelatorioFinal relatorioFinal)
        {
            try
            {
                // Chama a versão do método que não exige um token
                return await _request.PostAsync(apiUrlBase, relatorioFinal);
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao postar setor: {ex.Message}");
                throw;
            }
        }

        public async Task<ObservableCollection<RelatorioFinal>> GetRelatoriosFinaisAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<RelatorioFinal> listaRelatoriosFinais = await _request.GetAsync<ObservableCollection<RelatorioFinal>>(apiUrlBase + urlComplementar);
            return listaRelatoriosFinais;
        }

        public async Task<RelatorioFinal> GetRelatorioFinalAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var relatorioFinal = await _request.GetAsync<RelatorioFinal>(apiUrlBase + urlComplementar);
            return relatorioFinal;
        }

        public async Task<int> PutRelatorioFinalAsync(RelatorioFinal relatorioFinal)
        {
            var result = await _request.PutAsync(apiUrlBase, relatorioFinal);
            return result;
        }

        public async Task<int> DeleteRelatorioFinalAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
