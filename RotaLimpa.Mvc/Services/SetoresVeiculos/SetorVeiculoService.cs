using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.SetoresVeiculos
{
    public class SetorVeiculoService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/SetorVeiculo";

        public SetorVeiculoService()
        {
            _request = new Request();
        }

        public async Task<int> PostSetorVeiculoAsync(SetorVeiculo setorVeiculo)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, setorVeiculo);
        }

        public async Task<ObservableCollection<SetorVeiculo>> GetSetoresVeiculosAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<SetorVeiculo> listaSetoresVeiculos = await _request.GetAsync<ObservableCollection<SetorVeiculo>>(apiUrlBase + urlComplementar);
            return listaSetoresVeiculos;
        }

        public async Task<SetorVeiculo> GetSetorVeiculoAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var setorVeiculo = await _request.GetAsync<SetorVeiculo>(apiUrlBase + urlComplementar);
            return setorVeiculo;
        }

        public async Task<int> PutSetorVeiculoAsync(SetorVeiculo setorVeiculo)
        {
            var result = await _request.PutAsync(apiUrlBase, setorVeiculo);
            return result;
        }

        public async Task<int> DeleteSetorVeiculoAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
