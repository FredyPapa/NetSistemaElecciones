using AutoMapper;
using SistemaElecciones.Dto.Request;
using SistemaElecciones.Dto.Response;
using SistemaElecciones.Entities;

namespace SistemaElecciones.Services.Profiles;

public class VotacionProfile : Profile
{
    public VotacionProfile()
    {
        // 1. LECTURA (GET)
        CreateMap<Votacion, VotacionDtoResponse>()
            .ForMember(dest => dest.CampaniaDenominacion, 
                opt => opt.MapFrom(src => src.Campania.Denominacion))
            .ForMember(dest => dest.CandidatoNombreCompleto, 
                opt => opt.MapFrom(src => $"{src.Candidato.Trabajador.Nombres} {src.Candidato.Trabajador.ApellidoPaterno}"))
            .ForMember(dest => dest.FechaVoto, 
                opt => opt.MapFrom(src => src.FechaCreacion));

        // 2. GUARDAR (POST)
        CreateMap<VotacionDtoRequest, Votacion>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Evita error IDENTITY_INSERT
            .ForMember(dest => dest.usuarioCreacionId, 
                opt => opt.MapFrom(src => src.UsuarioId))
            .ForMember(dest => dest.Campania, opt => opt.Ignore())
            .ForMember(dest => dest.Candidato, opt => opt.Ignore());
    }
}