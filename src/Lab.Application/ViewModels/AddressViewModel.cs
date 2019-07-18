using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab.Application.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            Id = Guid.NewGuid();
        }
        public SelectList Estados()
        {
            return new SelectList(StateViewModel.ListStates(), "UF", "Nome");
        }

        [Key]
        public Guid Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string CEP { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public Guid MeetupId { get; set; }

        public override string ToString()
        {
            return Street + ", " + Number + " - " + Neighborhood + ", " + City + " - " + State;
        }
    }
}