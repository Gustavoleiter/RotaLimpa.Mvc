using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;
using Newtonsoft.Json.Linq;

namespace RotaLimpa.Mvc.Services.Setores
{
    public class SetorService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rotalimpa/Setores";

        public SetorService()
        {
            _request = new Request();
        }

        public async Task<int> PostSetorAsync(Setor s)
        {
            try
            {
                // Chama a versão do método que não exige um token
                return await _request.PostReturnIntAsync(apiUrlBase, s);
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao postar setor: {ex.Message}");
                throw;
            }
        }

        public async Task<int> PutSetorAsync(Setor s)
        {
            try
            {
                var result = await _request.PutAsync(apiUrlBase, s);

                // Adicione tratamento apropriado para lidar com a resposta da API, se necessário

                return result;
            }
            catch (Exception ex)
            {
                // Adicione tratamento de erro apropriado
                Console.WriteLine($"Erro ao atualizar setor: {ex.Message}");
                throw;
            }
        }


        public async Task<ObservableCollection<Setor>> GetSetoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Setor> listaSetores = await
            _request.GetAsync<ObservableCollection<Models.Setor>>(apiUrlBase + urlComplementar);
            return listaSetores;
        }

        public async Task<Setor> GetSetorAsync(int setorId)
        {
            string urlComplementar = string.Format("/{0}", setorId);
            var setor = await _request.GetAsync<Models.Setor>(apiUrlBase + urlComplementar);
            return setor;
        }


        public async Task<int> DeleteSetorAsync(int setorId)
        {
            string urlComplementar = string.Format("/{0}", setorId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }

        public async Task<Setor> PostRegistrarSetorAsync(Setor s)
        {
            // Registrar: Rota para o método na API que registra o setor
            string urlComplementar = "/Registrar";
            s.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, s);
            return s;
        }
    }
}
