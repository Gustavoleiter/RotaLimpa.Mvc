using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Empresas
{
    public class EmpresaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/Empresas";

        public EmpresaService()
        {
            _request = new Request();
        }

        public async Task<int> PostEmpresaAsync(Empresa empresa)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, empresa);
        }

        public async Task<ObservableCollection<Empresa>> GetEmpresasAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Empresa> listaEmpresas = await _request.GetAsync<ObservableCollection<Empresa>>(apiUrlBase + urlComplementar);
            return listaEmpresas;
        }

        public async Task<Empresa> GetEmpresaAsync(int empresaId)
        {
            string urlComplementar = $"/{empresaId}";
            var empresa = await _request.GetAsync<Empresa>(apiUrlBase + urlComplementar);
            return empresa;
        }

        public async Task<int> PutEmpresaAsync(Empresa empresa)
        {
            var result = await _request.PutAsync(apiUrlBase, empresa);
            return result;
        }

        public async Task<int> DeleteEmpresaAsync(int empresaId)
        {
            string urlComplementar = $"/{empresaId}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }

        public async Task<Empresa> PostRegistrarEmpresaAsync(Empresa empresa)
        {
            string urlComplementar = "/Registrar";
            empresa.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, empresa);
            return empresa;
        }
        public async Task<Empresa> ObterEmpresaAssociadaAsync(int colaboradorId)
        {
            // Implemente a lógica real para obter a empresa associada de maneira assíncrona
            // Substitua o retorno e adicione tratamento de exceções conforme necessário
            return await _request.GetAsync<Empresa>(apiUrlBase + $"/ObterEmpresaAssociada/{colaboradorId}");
        }
    }
}
