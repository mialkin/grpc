using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Server.Greet.API;
using Grpc.Server.Models;
using Item = Grpc.Server.Greet.API.Item;

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
