﻿using AutoMapper;
using WorkoutTracker.Application.DTOs.Exercises;
using WorkoutTracker.Application.DTOs.WorkoutPlans;
using WorkoutTracker.Core.Entities;

namespace WorkoutTracker.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Exercise Mapping
            CreateMap<Exercise, ExerciseDto>().ReverseMap();

            //WorkoutPlan Mapping
            CreateMap<WorkoutPlan, WorkoutPlanDto>().ReverseMap();
            CreateMap<WorkoutPlan, WorkoutPlanDetailDto>().ReverseMap();

        }
    }
}
