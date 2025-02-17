﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace projektowanie_oprogramowania_final_project.Models
{
    public enum PaymentMethod
    {
        blik,
        PayU,
        bankTransfer
    }

    public class Reservation 
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public double Price { get; set; }

        public ICollection<ReservationSeat> ReservationSeats { get; set; }


        [Required]
        public PaymentMethod ChosenPayment { get; set; }

        public int? ShowingId { get; set; }

        public Showing Showing { get; set; }


        public string? UserId { get; set; }

        public IdentityUser User { get; set; }

    }
}
