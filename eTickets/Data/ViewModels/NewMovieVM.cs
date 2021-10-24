using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewMovieVM
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Price In $")]
        public double Price { get; set; }

        [Display(Name = "Poster URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select A Category")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select Actor(s)")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select A Cinema")]
        public int CinemaId { get; set; }

        [Display(Name = "Select A Director")]
        public int DirectorId { get; set; }
    }
}
