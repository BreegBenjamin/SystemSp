using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace SystemSP.Intelligence
{
    public static class IJSExtensions
    {
        public static async Task DeshabilitarScroll(this IJSRuntime JsRun, bool Login = false)
            => await JsRun.InvokeVoidAsync(identifier: "salirMenu.DeshabilitarScroll", Login);
        public static async Task HabilitarScroll(this IJSRuntime JsRun)
            => await JsRun.InvokeVoidAsync(identifier: "salirMenu.HabilitarScroll");
        public static async Task DeshabilitarScrollApp(this IJSRuntime JsRun)
            => await JsRun.InvokeVoidAsync(identifier: "salirMenu.DeshabilitarScrollPage");
        public static async Task MensajesRegistro(this IJSRuntime JsRun, string msPass, string msMail)
            => await JsRun.InvokeVoidAsync(identifier: "seetAlert.SweetMensaje", msPass, msMail);
        public static async Task MoverCategoriaDerecha(this IJSRuntime JsRun)
            => await JsRun.InvokeVoidAsync(identifier : "scroll.MoverCategoriasDerecha");
        public static async Task MoverCategoriasIzquierda(this IJSRuntime JsRun)
            => await JsRun.InvokeVoidAsync(identifier: "scroll.MoverCategoriasIzquierda");
        public static async Task EjecutarJavaScriptFunc(this IJSRuntime JsRun, string funcionJS, params string[] paramters)
            => await JsRun.InvokeVoidAsync(identifier: funcionJS, paramters);
    }
}
