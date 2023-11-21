using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Relatorios
{
    public class RelatorioFinalService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/RelatorioFinal";

        public RelatorioFinalService()
        {
            _request = new Request();
        }

        public async Task<int> PostRelatorioFinalAsync(RelatorioFinal relatorioFinal)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, relatorioFinal);
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
