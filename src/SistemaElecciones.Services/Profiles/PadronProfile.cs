using AutoMapper;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;

namespace SistemaElecciones.Services.Profiles;

public class PadronProfile : Profile
{
    public PadronProfile()
    {
        // 1. LECTURA (GET / Listados)
        CreateMap<Padron, PadronDtoResponse>()
            .ForMember(dest => dest.CampaniaDenominacion, 
                opt => opt.MapFrom(src => src.Campania.Denominacion))
            .ForMember(dest => dest.TrabajadorNombreCompleto, 
                opt => opt.MapFrom(src => $"{src.Trabajador.Nombres} {src.Trabajador.ApellidoPaterno} {src.Trabajador.ApellidoMaterno}"))
            .ForMember(dest => dest.TrabajadorNroDocumento, 
                opt => opt.MapFrom(src => src.Trabajador.NroDocumento));

        // 2. ESCRITURA (POST / PUT)
        CreateMap<PadronDtoRequest, Padron>()
            // Evitamos que intente insertar un ID manual (Error 544)
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            
            // Mapeo de auditoría según EntityBase
            .ForMember(dest => dest.usuarioCreacionId, 
                opt => opt.MapFrom(src => src.UsuarioId))
            
            // Ignoramos objetos de navegación para evitar conflictos en EF
            .ForMember(dest => dest.Campania, opt => opt.Ignore())
            .ForMember(dest => dest.Trabajador, opt => opt.Ignore());

        // 3. EDICIÓN (GET by ID)
        CreateMap<Padron, PadronDtoRequest>()
            .ForMember(dest => dest.UsuarioId, 
                opt => opt.MapFrom(src => src.usuarioCreacionId));
    }
}