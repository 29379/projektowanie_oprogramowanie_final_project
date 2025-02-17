﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace projektowanie_oprogramowania_final_project.Models
{

    public enum LanguageVersion
    {
        dubbing,
        subtitles
    }

    public enum TechnologyVersion
    {
        _2D,
        _3D
    }

    public class Showing
    {
        [Key]
        public int ShowingId { get; set; }

        public int? FilmId { get; set; }

        public Film Film { get; set; }

        public int? CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public int? RoomId { get; set; }

        public Room Room { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Showtime { get; set; }

        [Required]
        public LanguageVersion Language { get; set; }

        [Required]
        public TechnologyVersion Technology { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The value has to be bigger than 0")]
        public double Price { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public override string ToString()
        {
            return Film + ", " + Technology + ", " + Language + ", " + Showtime;
        }
    }
}
