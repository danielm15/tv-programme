using System;
using AutoMapper;
using TVP.Models.Entities;
using TVP.Models.Dtos;

namespace TVP.Common.Mappings
{
    public class MappingProfile : Profile
    {
        // This mapping profile maps one class to another, 
        // these mapping profiles map our entity classes to our DTO's
        public MappingProfile()
        {
            CreateMap<ProgrammeItem, ProgrammeItemDto>()
                .ForMember(src => src.ChannelName, opt => opt.MapFrom(src => src.midill_heiti))
                .ForMember(src => src.Date, opt => opt.MapFrom(src => src.dagsetning))
                .ForMember(src => src.StartTime, opt => opt.MapFrom(src => src.upphaf))
                .ForMember(src => src.Title, opt => opt.MapFrom(src => src.titill))
                .ForMember(src => src.IslTitle, opt => opt.MapFrom(src => src.isltitill))
                .ForMember(src => src.SubTitle, opt => opt.MapFrom(src => src.undirtitill))
                .ForMember(src => src.SeriesNumber, opt => opt.MapFrom(src => src.seria))
                .ForMember(src => src.EpisodeNumber, opt => opt.MapFrom(src => src.thattur))
                .ForMember(src => src.NumberOfEpisodes, opt => opt.MapFrom(src => src.thattafjoldi))
                .ForMember(src => src.Category, opt => opt.MapFrom(src => src.flokkur))
                .ForMember(src => src.PgRating, opt => opt.MapFrom(src => src.bannad))
                .ForMember(src => src.Description, opt => opt.MapFrom(src => src.lysing));

            CreateMap<RuvProgrammeItem, RuvProgrammeItemDto>()
                .ForMember(src => src.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(src => src.Duration, opt => opt.MapFrom(src => src.duration))
                .ForMember(src => src.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(src => src.StartTime, opt => opt.MapFrom(src => src.startTime))
                .ForMember(src => src.EpisodeNumber, opt => opt.MapFrom(src => src.series.episode))
                .ForMember(src => src.SeriesNumber, opt => opt.MapFrom(src => src.series.series));
        }
    }
}