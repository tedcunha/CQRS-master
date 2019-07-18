using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab.Application.ViewModels
{
    public class MeetupViewModel
    {
        public MeetupViewModel()
        {
            Id = Guid.NewGuid();
            Address = new AddressViewModel();
            Category = new CategoryViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome do Evento")]
        public string Name { get; set; }

        [Display(Name = "Descricao curta do Evento")]
        public string ShortDescription { get; set; }

        [Display(Name = "Descricao longa do Evento")]
        public string LongDescription { get; set; }

        [Display(Name = "Início do Evento")]
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime DateHome { get; set; }

        [Display(Name = "Fim do Evento")]
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Será gratuito?")]
        public bool Free { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Moeda em formato inválido")]
        public decimal MeetupValue { get; set; }

        [Display(Name = "Será online?")]
        public bool Online { get; set; }

        [Display(Name = "Empresa / Grupo Organizador")]
        public string CompanyName { get; set; }

        public AddressViewModel Address { get; set; }
        public CategoryViewModel Category { get; set; }
        public Guid CategoryId { get; set; }
        public Guid OrganizerId { get; set; }
    }
}
