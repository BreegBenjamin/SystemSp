using System.Collections.Generic;
using SystemSp.DTOS.EntitisViewApp;
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
        public List<PopularCategory> GetPopularCategories() 
        {
            return new List<PopularCategory> 
            {
                new PopularCategory()
                {
                    Nombre = "Educación",
                    UrlImage = "education.svg",
                    IdCategoria = 1
                },
                new PopularCategory()
                {
                    Nombre = "Industria y Comercio",
                    UrlImage = "IndustryAndCommerce.svg",
                    IdCategoria = 2
                },
                new PopularCategory()
                {
                    Nombre = "Herramientas y Productividad",
                    UrlImage = "ToolsAndProductivity.svg",
                    IdCategoria = 3
                },
                new PopularCategory()
                {
                    Nombre = "Entretenimiento y Eventos",
                    UrlImage = "EntertainmentAndEvents.svg",
                    IdCategoria = 4
                },
                new PopularCategory()
                {
                    Nombre = "Salud y Bienestar",
                    UrlImage = "HealthAndWellness.svg",
                    IdCategoria = 5
                },
                new PopularCategory()
                {
                    Nombre = "Arte y Diseño",
                    UrlImage = "ArtAndDesign.svg",
                    IdCategoria = 6
                },
                new PopularCategory()
                {
                    Nombre = "Fotografía",
                    UrlImage = "Photography.svg",
                    IdCategoria = 7
                },
                new PopularCategory()
                {
                    Nombre = "Veterinaria",
                    UrlImage = "Veterinary.svg",
                    IdCategoria = 7
                }
            };
        }
        public List<ListaCategoriaVista> GetListCategorys(TextCategoriasIndex text) => 
            _getListElements(text);
    }
}
