using AutoMapper;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;
using SistemaElecciones.Entities.Infos;

namespace SistemaElecciones.Services.Profiles;

public class CampaniaProfile : Profile
{
    public CampaniaProfile()
    {
        // 1. Mapeo de LECTURA (Desde la Entidad hacia el DTO para el GET)
        CreateMap<Campania, CampaniaDtoResponse>()
            .ForMember(dest => dest.PermiteVotoBlanco, 
                opt => opt.MapFrom(src => src.PermiteVotoBlanco ? "SÍ" : "NO"));
        
        // 1. Mapeo de LECTURA (Desde la base de datos hacia el DTO de respuesta)
        CreateMap<CampaniaInfo, CampaniaDtoResponse>()
            .ForMember(dest => dest.FechaInicio, 
                opt => opt.MapFrom(src => src.FechaInicio.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.FechaFin, 
                opt => opt.MapFrom(src => src.FechaFin.ToString("dd/MM/yyyy")))
            // Ajuste aquí: Forzamos la evaluación para el string del DTO
            .ForMember(dest => dest.PermiteVotoBlanco, opt => 
                opt.MapFrom(src => src.PermiteVotoBlanco));

        // 2. Mapeo de ESCRITURA (Desde la solicitud hacia la Entidad)
        CreateMap<CampaniaDtoRequest, Campania>()
            .ForMember(dest => dest.FechaCreacion, 
                opt => opt.MapFrom(src => src.FechaCreacion.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.PermiteVotoBlanco, 
                opt => opt.MapFrom(src => src.PermiteVotoBlanco == 1))
            // Mapeo explícito por diferencia de nombre (U vs u)
            .ForMember(dest => dest.usuarioCreacionId, 
                opt => opt.MapFrom(src => src.UsuarioCreacionId));
        
        // 3. Para el GET por ID (Recuperar para editar)
        CreateMap<Campania, CampaniaDtoRequest>()
            // Conversión de DateTime a DateOnly
            .ForMember(dest => dest.FechaCreacion, 
                opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FechaCreacion)))
            // Conversión de bool a int (la que ya teníamos)
            .ForMember(dest => dest.PermiteVotoBlanco, 
                opt => opt.MapFrom(src => src.PermiteVotoBlanco ? 1 : 0));
        
    }
}