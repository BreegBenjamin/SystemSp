#pragma checksum "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f517c672bf7686b30a7d7d49fef5b932ac00a82"
// <auto-generated/>
#pragma warning disable 1591
namespace SystemSP.ComponentesCompartidos
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using Toolbelt.Blazor.I18nText;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.ComponentsBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.Intelligence;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.Entitys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.ComponentsProyecto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.ComponentesCompartidos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.ComponentsVista;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.ComponentesAdmin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using SystemSP.I18nText;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using DTOSystemSp.EntitysInicioApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\_Imports.razor"
using DTOSystemSp.EntitysFormProject;

#line default
#line hidden
#nullable disable
    public partial class SelectorIdioma : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "contenedorSelect imgSelect");
            __builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 2 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
                                                    ()=>_habilitarCambio = true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "style", "margin:6.5px 0 0 0");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "img");
            __builder.AddAttribute(8, "src", "/images/PageImage/" + (
#nullable restore
#line 4 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
                                     _imgLanguage1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "height", "25");
            __builder.AddAttribute(10, "width", "25");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.OpenElement(13, "p");
            __builder.AddContent(14, 
#nullable restore
#line 6 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
        _language1

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n");
#nullable restore
#line 8 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
 if (_habilitarCambio)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(17, "    ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "postionSelect");
            __builder.AddMarkupContent(20, "\r\n        ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "contenedorPais");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
                                              _changedLanguage

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(24, "\r\n            ");
            __builder.OpenElement(25, "div");
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "img");
            __builder.AddAttribute(28, "src", "/images/PageImage/" + (
#nullable restore
#line 13 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
                                             _imgLanguage2

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(29, "height", "25");
            __builder.AddAttribute(30, "width", "25");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "p");
            __builder.AddContent(34, 
#nullable restore
#line 15 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
                _language2

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n");
#nullable restore
#line 18 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 20 "C:\Desarrollo\SenaSystemSP\SystemSP\SystemSP\ComponentesCompartidos\SelectorIdioma.razor"
       
    private string idioma = "es";
    private bool _habilitarCambio = false;
    private string _imgLanguage1 = "spain.svg";
    private string _language1 = "Español";
    private string _language2 = "English";
    private string _imgLanguage2 = "uk.svg";

    private async Task _changedLanguage()
    {
        if (_language2 == "Español")
        {
            _imgLanguage1 = "spain.svg";
            _language1 = "Español";
            _language2 = "English";
            _imgLanguage2 = "uk.svg";
            idioma = "es";
        }
        else
        {
            _imgLanguage1 = "uk.svg";
            _language1 = "English";
            _language2 = "Español";
            _imgLanguage2 = "spain.svg";
            idioma = "en";
        }
        _habilitarCambio = false;
        await _changeCurrentLang(idioma);
    }

    private async Task _changeCurrentLang(string lang)
        => await serviceTranslate.SetCurrentLanguageAsync(lang);

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private I18nText serviceTranslate { get; set; }
    }
}
#pragma warning restore 1591