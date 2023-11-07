<<<<<<< HEAD
﻿using RotaLimpa.Mvc.Models;
=======
﻿using Newtonsoft.Json;
>>>>>>> 84eb21e8e13be8d463f8a5c17d114d97f1b362c8
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RotaLimpa.Mvc.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

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

<<<<<<< HEAD
        public async Task<Setor> PostSetorAsync(Setor s)
        {
            string urlComplementar = "/Registrar";
            s.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, s);
            return s;
                
=======
        public async Task<int> PostSetorAsync(Setor s)
        {
            // Chama a versão do método que não exige um token
            return await _request.PostReturnIntAsync(apiUrlBase, s);
>>>>>>> 84eb21e8e13be8d463f8a5c17d114d97f1b362c8
        }

        public async Task<ObservableCollection<Setor>> GetSetoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
<<<<<<< HEAD
            ObservableCollection<Setor> listaSetores = await
            _request.GetAsync<ObservableCollection<Setor>>(apiUrlBase + urlComplementar);
=======
            ObservableCollection<Models.Setor> listaSetores = await
            _request.GetAsync<ObservableCollection<Models.Setor>>(apiUrlBase + urlComplementar);
>>>>>>> 84eb21e8e13be8d463f8a5c17d114d97f1b362c8
            return listaSetores;
        }

        public async Task<Setor> GetSetorAsync(int setorId)
        {
            string urlComplementar = string.Format("/{0}", setorId);
<<<<<<< HEAD
            var setor = await _request.GetAsync<Setor>(apiUrlBase + urlComplementar);
=======
            var setor = await _request.GetAsync<Models.Setor>(apiUrlBase + urlComplementar);
>>>>>>> 84eb21e8e13be8d463f8a5c17d114d97f1b362c8
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

<<<<<<< HEAD
=======
        public async Task<Setor> PostRegistrarSetorAsync(Setor s)
        {
            // Registrar: Rota para o método na API que registra o setor
            string urlComplementar = "/Registrar";
            s.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, s);
            return s;
        }
>>>>>>> 84eb21e8e13be8d463f8a5c17d114d97f1b362c8
    }
}

