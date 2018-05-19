using AutoMapper;
using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetViewModel>();

            CreateMap<Priorities, PrioritiesDTO>();
            CreateMap<UserFitnessGoals, UserFitnessGoalsDTO>();
        }
    }
}