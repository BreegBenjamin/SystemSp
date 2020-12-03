using System.Collections.Generic;
using SystemSP.Entitys;
using SystemSP.I18nText;

namespace SystemSP.Intelligence
{
    public class SetChangeLanguage
    {
        private List<ListaCategoriaVista> _getListElements(TextCategoriasIndex text) 
        {
            var categorias = new List<ListaCategoriaVista>()
            {
                new ListaCategoriaVista("SupermarketsAndStores.svg",text.Shop),
                new ListaCategoriaVista("VehiclesAndMotorcycles.svg",text.Motorcycle),
                new ListaCategoriaVista("education.svg",text.Education),
                new ListaCategoriaVista("Transport.svg",text.Transport),
                new ListaCategoriaVista("Environment.svg",text.Environment),
                new ListaCategoriaVista("IndustryAndCommerce.svg",text.Commerce),
                new ListaCategoriaVista("Veterinary.svg",text.Veterinary),
                new ListaCategoriaVista("AgricultureAndFarms.svg",text.Farms),
                new ListaCategoriaVista("RealEstateAndHome.svg",text.Home),
                new ListaCategoriaVista("BooksAndLibraries.svg",text.Libraries),
                new ListaCategoriaVista("HealthAndWellness.svg",text.Health),
                new ListaCategoriaVista("TravelsAndTourism.svg",text.Travel),
                new ListaCategoriaVista("MusicAndAudio.svg",text.Music),
                new ListaCategoriaVista("Photography.svg",text.Photography),
                new ListaCategoriaVista("ArtAndDesign.svg",text.Art),
                new ListaCategoriaVista("FoodAndDelivery.svg",text.Food),
                new ListaCategoriaVista("ToolsAndProductivity.svg",text.Tool),
                new ListaCategoriaVista("OfficeComplement.svg",text.Office),
                new ListaCategoriaVista("EntertainmentAndEvents.svg",text.Event),
                new ListaCategoriaVista("FinanceAndJobs.svg",text.Finance),
                new ListaCategoriaVista("other.svg",text.Other)
            };
            return categorias;
        }
        private List<string> _getCategoys(TextCategoriasIndex text) 
        {
            return new List<string>() 
            {
                text.Shop,
                text.Motorcycle,
                text.Education,
                text.Transport,
                text.Environment,
                text.Commerce,
                text.Veterinary,
                text.Farms,
                text.Home,
                text.Libraries,
                text.Health,
                text.Travel,
                text.Music,
                text.Photography,
                text.Art,
                text.Food,
                text.Tool,
                text.Office,
                text.Environment,
                text.Finance,
                text.Other
            };
        }
        public List<string> GetCategorys(TextCategoriasIndex text) 
            => _getCategoys(text);
        public List<ListaCategoriaVista> GetListCategorys(TextCategoriasIndex text) => 
            _getListElements(text);
    }
}
