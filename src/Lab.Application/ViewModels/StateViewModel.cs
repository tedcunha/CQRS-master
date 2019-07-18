using System.Collections.Generic;

namespace Lab.Application.ViewModels
{
    public class StateViewModel
    {
        public string UF { get; set; }
        public string Nome { get; set; }

        public static List<StateViewModel> ListStates()
        {
            return new List<StateViewModel>()
            {
                new StateViewModel() {UF = "AC", Nome = "Acre"},
                new StateViewModel() {UF = "AL", Nome = "Alagoas"},
                new StateViewModel() {UF = "AP", Nome = "Amapá"},
                new StateViewModel() {UF = "AM", Nome = "Amazonas"},
                new StateViewModel() {UF = "BA", Nome = "Bahia"},
                new StateViewModel() {UF = "CE", Nome = "Ceará"},
                new StateViewModel() {UF = "DF", Nome = "Distrito Federal"},
                new StateViewModel() {UF = "ES", Nome = "Espírito Santo"},
                new StateViewModel() {UF = "GO", Nome = "Goiás"},
                new StateViewModel() {UF = "MA", Nome = "Maranhão"},
                new StateViewModel() {UF = "MT", Nome = "Mato Grosso"},
                new StateViewModel() {UF = "MS", Nome = "Mato Grosso do Sul"},
                new StateViewModel() {UF = "MG", Nome = "Minas Gerais"},
                new StateViewModel() {UF = "PA", Nome = "Pará"},
                new StateViewModel() {UF = "PB", Nome = "Paraíba"},
                new StateViewModel() {UF = "PR", Nome = "Paraná"},
                new StateViewModel() {UF = "PE", Nome = "Pernambuco"},
                new StateViewModel() {UF = "PI", Nome = "Piauí"},
                new StateViewModel() {UF = "RJ", Nome = "Rio de Janeiro"},
                new StateViewModel() {UF = "RN", Nome = "Rio Grande do Norte"},
                new StateViewModel() {UF = "RS", Nome = "Rio Grande do Sul"},
                new StateViewModel() {UF = "RO", Nome = "Rondônia"},
                new StateViewModel() {UF = "RR", Nome = "Roraima"},
                new StateViewModel() {UF = "SC", Nome = "Santa Catarina"},
                new StateViewModel() {UF = "SP", Nome = "São Paulo"},
                new StateViewModel() {UF = "SE", Nome = "Sergipe"},
                new StateViewModel() {UF = "TO", Nome = "Tocantins"}
            };
        }
    }
}