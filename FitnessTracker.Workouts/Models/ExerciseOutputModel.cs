using AutoMapper;
using FitnessTracker.Models;
using FitnessTracker.Workouts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Models
{
    public class ExerciseOutputModel : IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int CaloriesPerRep { get; set; }
        public string ExerciseCategory { get; set; }
        public string UserId { get; set; }
        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Exercise, ExerciseOutputModel>()
                .ForMember(ad => ad.ExerciseCategory, cfg => cfg
                    .MapFrom(ad => ad.ExerciseCategory.Name));
    }
}
