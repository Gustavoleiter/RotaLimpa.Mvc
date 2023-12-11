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
/*using Google.Maps.Routing.V2;
using Google.Api.Gax.Grpc;
using Google.Type;
using Google.Maps;
using static Android.Webkit.WebStorage;*/
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using GMap.NET.MapProviders;

namespace RotaLimpa.Mvc.ViewModels.Motoristas
{
    internal class MapaViewModel : BaseViewModel
    {
        private RotaService uService;

        private List<PointLatLng> _points;

        public MapaViewModel()
        {
            uService = new RotaService();
            _points = new List<PointLatLng>();
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

                var polyline = new Microsoft.Maui.Controls.Maps.Polyline();

                foreach (CEP c in ceps)
                {
                    if (c.latitude != null && c.longitude != null)
                    {
                        double latitude = (double)c.latitude;
                        double longitude = (double)c.longitude;
                        Microsoft.Maui.Devices.Sensors.Location location = new Microsoft.Maui.Devices.Sensors.Location(latitude, longitude);

                        _points.Add(new PointLatLng(latitude, longitude));

                        Pin packMan = new Pin()
                        {
                            Type = PinType.SavedPin,
                            Label = c.Cidade,
                            Address = $"{c.latitude}, {c.longitude}"
                        };

                        map.Pins.Add(packMan);

                        if (mapSpan == null)
                        {
                            mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5));
                        }

                        if (map.Pins.Count >= 2)
                        {
                            var route = await ComputeRouteAsync(map.Pins[map.Pins.Count - 2], map.Pins[map.Pins.Count - 1]);
                            polyline.Geopath.Add(route.Polyline.(p => new Microsoft.Maui.Devices.Sensors.Location(p.Latitude, p.Longitude)));
                            map.MapElements.Add(polyline);
                        }
                    }
                }

                int i = 0;

                while (i <= _points.Count())
                {
                    var route = GoogleMapProvider.Instance
                        .GetRoute(_points[i], _points[(i + 1)], false, false, 14);
                    var r = new GMapRoute(route.Points, "Rota funcionando");

                    var routes = new GMapOverlay("routes");
                    routes.Routes.Add(r);
                    map.Overlays.Add(routes);
                    i++;
                }

                if (mapSpan != null)
                {
                    map.MoveToRegion(mapSpan);
                }

                _points.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<Google.Maps.Routing.V2.Route> ComputeRouteAsync(Pin origin, Pin destination)
        {
            RoutesClient client = RoutesClient.Create();
            CallSettings callSettings = CallSettings.FromHeader("X-Goog-FieldMask", "*");

            var request = new ComputeRoutesRequest
            {
                Origin = new Google.Maps.Routing.V2.Waypoint
                {
                    Location = new Google.Maps.Routing.V2.Location
                    {
                        LatLng = new Google.Type.LatLng
                        {
                            Latitude = origin.Location.Latitude,
                            Longitude = origin.Location.Longitude
                        }
                    }
                },
                Destination = new Google.Maps.Routing.V2.Waypoint
                {
                    Location = new Google.Maps.Routing.V2.Location
                    {
                        LatLng = new Google.Type.LatLng
                        {
                            Latitude = origin.Location.Latitude,
                            Longitude = origin.Location.Longitude
                        }
                    }
                },
                TravelMode = RouteTravelMode.Drive,
                RoutingPreference = RoutingPreference.TrafficAware
            };

            ComputeRoutesResponse response = await client.ComputeRoutesAsync(request, callSettings);
            return response.Routes.FirstOrDefault();
        }
    }
}
