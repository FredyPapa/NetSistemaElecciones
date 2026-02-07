using BlazorBootstrap;
using CurrieTechnologies.Razor.SweetAlert2;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.WebApp.Proxy.Interfaces;

namespace SistemaElecciones.WebApp.Pages.Campanias;

public partial class CampaniasListPage
{
    // Inicializamos con una lista vacía para evitar el ArgumentNullException
    public ICollection<CampaniaDtoResponse> Lista { get; set; } = new List<CampaniaDtoResponse>();
    public Grid<CampaniaDtoResponse> Grilla { get; set; } = null!;
    public bool IsLoading { get; set; }
    public string? FiltroNombre { get; set; }
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }

    private async Task OnRefresh()
    {
        await Grilla.RefreshDataAsync();
    }

    private void OnLimpiar()
    {
        FiltroNombre = null;
    }

    private async Task<GridDataProviderResult<CampaniaDtoResponse>> OnReadData(
        GridDataProviderRequest<CampaniaDtoResponse> request)
    {
        try
        {
            IsLoading = true;
            
            // Llamada al Proxy (devuelve ICollection<CampaniaDtoResponse>)
            var response = await Proxy.ListAsync();

            if (response != null)
            {
                if (!string.IsNullOrWhiteSpace(FiltroNombre))
                {
                    Lista = response
                        .Where(x => x.Denominacion.Contains(FiltroNombre, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
                else
                {
                    Lista = response.ToList();
                }
            }
            else
            {
                Lista = new List<CampaniaDtoResponse>();
            }

            TotalCount = Lista.Count;

            return await Task.FromResult(new GridDataProviderResult<CampaniaDtoResponse>
            {
                Data = Lista,
                TotalCount = TotalCount
            });
        }
        catch (Exception ex)
        {
            ToastService.ShowError("Error al cargar las campañas");
            return new GridDataProviderResult<CampaniaDtoResponse> { Data = new List<CampaniaDtoResponse>() };
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void OnNuevo() => NavigationManager.NavigateTo("campania/nuevo");

    private void OnEditar(int id) => NavigationManager.NavigateTo($"/campania/editar/{id}");

    private async Task OnEliminar(int id)
    {
        var confirm = await Swal.FireAsync(new SweetAlertOptions("¿Desea eliminar la campaña?")
        {
            ShowCancelButton = true,
            CancelButtonText = "Cancelar",
            ConfirmButtonText = "Sí, eliminar",
            Icon = SweetAlertIcon.Warning
        });

        if (confirm.IsConfirmed)
        {
            try
            {
                await Proxy.DeleteAsync(id);
                ToastService.ShowSuccess("Campaña eliminada");
                await OnRefresh();
            }
            catch (Exception)
            {
                ToastService.ShowError("No se pudo eliminar");
            }
        }
    }
}