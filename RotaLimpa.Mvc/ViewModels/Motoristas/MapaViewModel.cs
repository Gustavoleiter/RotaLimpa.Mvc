using System;
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
                MapSpan mapSpan = null;


                foreach (CEP c in ceps)
                {
                    if (c.latitude != null && c.longitude != null)
                    {
                        double latitude = (double)c.latitude;
                        double longitude = (double)c.longitude;
                        Microsoft.Maui.Devices.Sensors.Location location = new Microsoft.Maui.Devices.Sensors.Location(latitude, longitude);

                        Pin packMan = new Pin()
                        {
                            Type = PinType.SavedPin,
                            Label = c.Cidade,
                            Address = $"{c.latitude}, {c.longitude}"
                        };

                        map.Pins.Add(packMan);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



       
    }
}
