using AutoMapper;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;

namespace SistemaElecciones.Services.Profiles;

public class CandidatoProfile : Profile
{
    public CandidatoProfile()
    {
        // 1. ESCENARIO: LECTURA (GET / GET ALL)
        CreateMap<Candidato, CandidatoDtoResponse>()
            // Mapeo de la Campaña
            .ForMember(dest => dest.CampaniaDenominacion, 
                       opt => opt.MapFrom(src => src.Campania.Denominacion))
            
            // Mapeo del Trabajador (Concatenación de nombres)
            .ForMember(dest => dest.TrabajadorNombreCompleto, 
                       opt => opt.MapFrom(src => $"{src.Trabajador.Nombres} {src.Trabajador.ApellidoPaterno} {src.Trabajador.ApellidoMaterno}"))
            
            // Otros datos del Trabajador
            .ForMember(dest => dest.TrabajadorNroDocumento, 
                       opt => opt.MapFrom(src => src.Trabajador.NroDocumento))
            .ForMember(dest => dest.TrabajadorFotoUrl, 
                       opt => opt.MapFrom(src => src.Trabajador.FotoUrl));

        // 2. ESCENARIO: ESCRITURA (POST / PUT)

        CreateMap<CandidatoDtoRequest, Candidato>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorar el ID para evitar el error de IDENTITY
            .ForMember(dest => dest.usuarioCreacionId, opt => opt.MapFrom(src => src.UsuarioId))
            .ForMember(dest => dest.Campania, opt => opt.Ignore())
            .ForMember(dest => dest.Trabajador, opt => opt.Ignore());

        // 3. ESCENARIO: EDICIÓN (GET BY ID para cargar formulario)
        CreateMap<Candidato, CandidatoDtoRequest>()
            .ForMember(dest => dest.UsuarioId, 
                       opt => opt.MapFrom(src => src.usuarioCreacionId));
    }
    
}