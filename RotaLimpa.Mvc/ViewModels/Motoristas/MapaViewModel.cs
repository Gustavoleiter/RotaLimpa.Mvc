using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RotaLimpa.Mvc.Services.Rotas;
using RotaLimpa.Mvc.Models;

using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Collections.ObjectModel;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace RotaLimpa.Mvc.ViewModels.Motoristas
{
    internal class MapaViewModel : BaseViewModel
    {
        private RotaService uService;
        
        public MapaViewModel()
        {
            uService = new RotaService();
        }

        private Map rotaLimpaMapa;

        public Map RotaLimpaMapa
        {
            get => rotaLimpaMapa;
            set
            {
                if (rotaLimpaMapa != value)
                {
                    rotaLimpaMapa = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void InicializarMapa()
        {
            try
            {

                //    ObservableCollection<string> latitudes = await uService.GetLongitudeAsync(int id);
                //    List<Rota> rotas = new List<Rota>();
                //    Map map = new Map();

                //    foreach (Rota r in rotas)
                //    {
                //        foreach (Rua r in  )
                //        if (r.Ruas.IdCEP.Latitude != null )
                //        {

                //        }
                //    }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
