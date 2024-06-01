namespace DryFi_ProjectBasedLearning_MVC.Models
{
    public class MaquinaViewModel : PadraoViewModel
    {
        public int MaqStatus { get; set; }
        public string DescricaoStatus { get; set; }
        public string Endereco { get; set; }
        public int IdCliente {  get; set; }
        public string NomeCliente { get; set; }
    }
}
