using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;

namespace RotaLimpa.Mvc.Services.Rotas
{
    public class RotaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Rotas";

        public RotaService()
        {
            _request = new Request();
        }

        public async Task<Rota> PostRotaAsync(Rota r)
        {
            try
            {
                // Chama a versão do método que não exige um token
                return await _request.PostAsync(apiUrlBase, r);
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao postar setor: {ex.Message}");
                throw;
            }
        }

        public async Task<ObservableCollection<Rota>> GetRotasAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Rota> listaRotas = await
            _request.GetAsync<ObservableCollection<Rota>>(apiUrlBase + urlComplementar);
            return listaRotas;
        }

        public async Task<Rota> GetRotaAsync(int rotaId)
        {
            string urlComplementar = string.Format("/{0}", rotaId);
            var rota = await _request.GetAsync<Rota>(apiUrlBase + urlComplementar);
            return rota;
        }

        public async Task<int> PutRotaAsync(Rota r)
        {
            var result = await _request.PutAsync(apiUrlBase, r);
            return result;
        }

        public async Task<int> DeleteRotaAsync(int rotaId)
        {
            string urlComplementar = string.Format("/{0}", rotaId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }

        public async Task<Rota> PostRegistrarRotaAsync(Rota r)
        {
            // Registrar: Rota para o método na API que registra a rota
            string urlComplementar = "/Registrar";
            r.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, r);
            return r;
        }

        public async Task<ObservableCollection<string>> GetLatitudeAsync(int rotaId)
        {
            string urlComplementar = string.Format("/Latitude/{0}", rotaId);
            ObservableCollection<string> listaLatitudes = await
                _request.GetAsync<ObservableCollection<string>>(apiUrlBase + urlComplementar);
            return listaLatitudes;
        }

        public async Task<ObservableCollection<string>> GetLongitudeAsync(int rotaId)
        {
            string urlComplementar = string.Format("/Longitude/{0}", rotaId);
            ObservableCollection<string> listaLongitudes = await
                _request.GetAsync<ObservableCollection<string>>(apiUrlBase + urlComplementar);
            return listaLongitudes;
        }

        public async Task<ObservableCollection<CEP>> GetCEPAsync(int rotaId)
        {
            string urlComplementar = string.Format("/CEP/{0}", rotaId);
            ObservableCollection<CEP> listaCEPs = await
                _request.GetAsync<ObservableCollection<CEP>>(apiUrlBase + urlComplementar);
            return listaCEPs;
        }
    }
}
