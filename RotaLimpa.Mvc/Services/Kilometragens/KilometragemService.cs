using RotaLimpa.Mvc.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Kilometragens
{
    public class KilometragemService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Kilometragem";

        public KilometragemService()
        {
            _request = new Request();
        }

        public async Task<Kilometragem> PostKilometragem(Kilometragem kilometragem)
        {

            try
            {
                // Chama a versão do método que não exige um token
                return await _request.PostAsync(apiUrlBase, kilometragem);
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao postar setor: {ex.Message}");
                throw;
            }
        }

        public async Task<ObservableCollection<Kilometragem>> GetKilometragensAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Kilometragem> listaKilometragens = await _request.GetAsync<ObservableCollection<Kilometragem>>(apiUrlBase + urlComplementar);
            return listaKilometragens;
        }

        public async Task<Kilometragem> GetKilometragemAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var kilometragem = await _request.GetAsync<Kilometragem>(apiUrlBase + urlComplementar);
            return kilometragem;
        }

        public async Task<int> PutKilometragensAsync(Kilometragem kilometragem)
        {
            var result = await _request.PutAsync(apiUrlBase, kilometragem);
            return result;
        }

        public async Task<int> DeleteKilometragemAsync(int Id)
        {
            string urlComplementar = $"/{Id}";
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
    }
}
