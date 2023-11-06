using RotaLimpa.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Setores
{
    public class SetorService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/Setores";

        public SetorService()
        {
            _request = new Request();
        }

        public async Task<Setor> PostSetorAsync(Setor s)
        {
            string urlComplementar = "/Registrar";
            s.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, s);
            return s;
                
        }

        public async Task<ObservableCollection<Setor>> GetSetoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Setor> listaSetores = await
            _request.GetAsync<ObservableCollection<Setor>>(apiUrlBase + urlComplementar);
            return listaSetores;
        }

        public async Task<Setor> GetSetorAsync(int setorId)
        {
            string urlComplementar = string.Format("/{0}", setorId);
            var setor = await _request.GetAsync<Setor>(apiUrlBase + urlComplementar);
            return setor;
        }

        public async Task<int> PutSetorAsync(Setor s)
        {
            var result = await _request.PutAsync(apiUrlBase, s);
            return result;
        }

        public async Task<int> DeleteSetorAsync(int setorId)
        {
            string urlComplementar = string.Format("/{0}", setorId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }

    }
}

