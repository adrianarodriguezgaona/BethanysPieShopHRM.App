using Microsoft.AspNetCore.Components;
using BethanysPieShopHRM.Shared.Model;
using Microsoft.JSInterop;

namespace BethanysPieShopHRM.App.Components
{
	public partial class Map
	{
		private string elementId = $"map-{Guid.NewGuid():D}";

		[Inject] 
		public IJSRuntime JsRuntime { get; set; }

		[Parameter] 
		public double Zoom { get; set; }
		[Parameter] 
		public List<Marker> Markers { get; set; }

		protected async override Task OnAfterRenderAsync(bool firstRender)
		{
			await JsRuntime.InvokeVoidAsync(
				"deliveryMap.showOrUpdate",
				elementId,
				Markers);
		}
	}
}
