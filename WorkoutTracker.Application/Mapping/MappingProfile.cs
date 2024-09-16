using AutoMapper;
using WorkoutTracker.Application.DTOs.Exercises;
using WorkoutTracker.Core.Entities;

namespace WorkoutTracker.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Exercise Mapping
            CreateMap<Exercise, ExerciseDto>().ReverseMap();

        }
    }
}
