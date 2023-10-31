using RotaLimpa.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Colaboradores
{
    public class ColaboradorService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://rotalimpabanco.somee.com/rota/Colaboradores";

        public ColaboradorService()
        {
            _request = new Request();
        }


        public async Task<int> PostColaboradorAsync(Colaborador m)
        {
            // Chama a versão do método que não exige um token
            return await _request.PostReturnIntAsync(apiUrlBase, m);
        }
        public async Task<ObservableCollection<Colaborador>> GetColaboradoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Colaborador> listaColaboradores = await
            _request.GetAsync<ObservableCollection<Models.Colaborador>>(apiUrlBase + urlComplementar);
            return listaColaboradores;
        }
        public async Task<Colaborador> GetColaboradorAsync(int colaboradorIdColaborador)
        {
            string urlComplementar = string.Format("/{0}", colaboradorIdColaborador);
            var colaborador = await _request.GetAsync<Models.Colaborador>(apiUrlBase +
            urlComplementar);
            return colaborador;
        }
        public async Task<int> PutColaboradorAsync(Colaborador p)
        {
            var result = await _request.PutAsync(apiUrlBase, p);
            return result;
        }
        public async Task<int> DeleteColaboradorAsync(int colaboradorIdColaborador)
        {
            string urlComplementar = string.Format("/{0}", colaboradorIdColaborador);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar);
            return result;
        }
        public async Task<Colaborador> PostRegistrarColaboradorAsync(Colaborador u)
        {
            //Registrar: Rota para o método na API que registrar o usuário
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }

    }
}

