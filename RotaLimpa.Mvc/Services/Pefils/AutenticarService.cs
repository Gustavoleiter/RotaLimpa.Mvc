using RotaLimpa.Mvc.Services.Colaboradores;
using RotaLimpa.Mvc.Services.Motoristas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.Services.Autenticar
{
    public class AutenticarService
    {
        public async Task<bool> AutenticarAsync(string username, string senha)
        {
            //// Verifica se é um motorista
            //var motorista = await MotoristaService.AutenticarMotoristaAsync(username, senha);
            //if (motorista != null)
            //{
            //    perfil = "Motorista";
            //    return true;
            //}

            //// Verifica se é um colaborador
            //var colaborador = await ColaboradorService.AutenticarColaboradorAsync(username, senha);
            //if (colaborador != null)
            //{
            //    perfil = "Colaborador";
            //    return true;
            //}

            //// Não foi possível autenticar
            //perfil = string.Empty;
            return false;
        }
    }
}
