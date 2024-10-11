using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Server.Models;

namespace Grpc.Server.AutoMapperProfiles;

public class GrpcMappingProfile : Profile
{
    public GrpcMappingProfile()
    {
        CreateMap<Greeting, GetGreetingResponse>()
            .ForMember(x => x.OrderDate, x => x.MapFrom(y => Timestamp.FromDateTime(y.OrderDate)));
        CreateMap<Grpc.Server.Models.Item, Item>();
    }
}
