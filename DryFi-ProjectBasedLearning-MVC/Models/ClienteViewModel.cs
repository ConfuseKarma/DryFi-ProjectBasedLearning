namespace DryFi_ProjectBasedLearning_MVC.Models
{
    public class ClienteViewModel : PadraoViewModel
    {
        public string NomeCliente { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int TipoClienteId { get; set; }
    }
}
