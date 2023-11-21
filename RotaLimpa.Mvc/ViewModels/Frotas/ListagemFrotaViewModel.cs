using RotaLimpa.Mvc.Models;
using RotaLimpa.Mvc.Services.Frotas;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RotaLimpa.Mvc.ViewModels.Frotas
{
    public class ListaFrotaViewModel : BaseViewModel
    {
        private readonly FrotaService frotaService;

        public ObservableCollection<Frota> Frotas { get; set; }

        public ListaFrotaViewModel()
        {
            frotaService = new FrotaService();
            Frotas = new ObservableCollection<Frota>();
        }

        public async Task CarregarFrotas()
        {
            try
            {
                var listaFrotas = await frotaService.GetFrotasAsync();
                Frotas.Clear();

                foreach (var frota in listaFrotas)
                {
                    Frotas.Add(frota);
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                Console.WriteLine($"Erro ao carregar frotas: {ex.Message}");
            }
        }
    }
}
