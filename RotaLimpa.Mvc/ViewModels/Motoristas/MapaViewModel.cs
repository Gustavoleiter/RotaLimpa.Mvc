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



        public async void InicializarMapa(int id)
        {
            try
            {
                int idRota = await uService.GetRotaSetorAsync(id);
                ObservableCollection<CEP> ocCEPs = await uService.GetCEPAsync(idRota);
                List<CEP> ceps = new List<CEP>(ocCEPs);
                Map map = new Map();

                var polyline = new Polyline();

                foreach (CEP c in ceps)
                {
                    if (c.latitude != null && c.longitude != null)
                    {
                        double latitude = (double)c.latitude;
                        double longitude = (double)c.longitude;
                        Location location = new Location(latitude, longitude);

                        Pin pinAtual = new Pin()
                        {
                            Type = PinType.SavedPin,
                            Label = c.Cidade,
                            Address = $"{c.latitude}, {c.longitude}"
                        };
                        map.Pins.Add(pinAtual);
                    }

                    //polyline.Geopath.Add(new Position(c.latitude, c.longitude));
                    //map.MapElements.Add(polyline);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
