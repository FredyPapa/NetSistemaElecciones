using BlazorBootstrap;
using CurrieTechnologies.Razor.SweetAlert2;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.WebApp.Proxy.Interfaces;

namespace SistemaElecciones.WebApp.Pages.Padron;

public partial class PadronListPage
{
    public ICollection<PadronDtoResponse> Lista { get; set; } = new List<PadronDtoResponse>();
    public Grid<PadronDtoResponse> Grilla { get; set; } = null!;
    public string? FiltroNombre { get; set; }
    public int PageSize { get; set; } = 10;

    private async Task OnRefresh() => await Grilla.RefreshDataAsync();

    private async Task<GridDataProviderResult<PadronDtoResponse>> OnReadData(GridDataProviderRequest<PadronDtoResponse> request)
    {
        try
        {
            var response = await Proxy.ListAsync();
            if (response != null)
            {
                if (!string.IsNullOrWhiteSpace(FiltroNombre))
                {
                    Lista = response.Where(x => x.TrabajadorNombreCompleto.Contains(FiltroNombre, StringComparison.OrdinalIgnoreCase) || 
                                               x.CampaniaDenominacion.Contains(FiltroNombre, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    Lista = response.ToList();
                }
            }
            return new GridDataProviderResult<PadronDtoResponse> { Data = Lista, TotalCount = Lista.Count };
        }
        catch (Exception)
        {
            ToastService.ShowError("Error al cargar el padrón");
            return new GridDataProviderResult<PadronDtoResponse>();
        }
    }

    private void OnNuevo() => NavigationManager.NavigateTo("padron/nuevo");
    private void OnEditar(int id) => NavigationManager.NavigateTo($"/padron/editar/{id}");

    private async Task OnEliminar(int id)
    {
        var confirm = await Swal.FireAsync(new SweetAlertOptions("¿Retirar del padrón?") { ShowCancelButton = true, Icon = SweetAlertIcon.Warning });
        if (confirm.IsConfirmed)
        {
            try
            {
                await Proxy.DeleteAsync(id);
                ToastService.ShowSuccess("Registro eliminado");
                await OnRefresh();
            }
            catch (Exception)
            {
                ToastService.ShowError("No se pudo eliminar");
            }
        }
    }
}