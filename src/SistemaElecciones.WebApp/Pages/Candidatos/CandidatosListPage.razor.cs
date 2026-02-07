using BlazorBootstrap;
using CurrieTechnologies.Razor.SweetAlert2;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.WebApp.Proxy.Interfaces;

namespace SistemaElecciones.WebApp.Pages.Candidatos;

public partial class CandidatosListPage
{
    public ICollection<CandidatoDtoResponse> Lista { get; set; } = new List<CandidatoDtoResponse>();
    public Grid<CandidatoDtoResponse> Grilla { get; set; } = null!;
    public string? FiltroNombre { get; set; }
    public int PageSize { get; set; } = 10;

    private async Task OnRefresh() => await Grilla.RefreshDataAsync();

    private async Task<GridDataProviderResult<CandidatoDtoResponse>> OnReadData(GridDataProviderRequest<CandidatoDtoResponse> request)
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
            return new GridDataProviderResult<CandidatoDtoResponse> { Data = Lista, TotalCount = Lista.Count };
        }
        catch (Exception)
        {
            ToastService.ShowError("Error al cargar candidatos");
            return new GridDataProviderResult<CandidatoDtoResponse>();
        }
    }

    private void OnNuevo() => NavigationManager.NavigateTo("candidato/nuevo");
    private void OnEditar(int id) => NavigationManager.NavigateTo($"/candidato/editar/{id}");

    private async Task OnEliminar(int id)
    {
        var confirm = await Swal.FireAsync(new SweetAlertOptions("¿Eliminar candidato?") { ShowCancelButton = true, Icon = SweetAlertIcon.Warning });
        if (confirm.IsConfirmed)
        {
            await Proxy.DeleteAsync(id);
            await OnRefresh();
        }
    }
}