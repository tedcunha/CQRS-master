﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab.Application.ViewModels
{
    public class OrganizerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF é requerido")]
        [StringLength(11)]
        public string Document { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }
    }
}
