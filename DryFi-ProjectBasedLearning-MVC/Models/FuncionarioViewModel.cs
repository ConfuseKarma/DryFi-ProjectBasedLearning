namespace DryFi_ProjectBasedLearning_MVC.Models
{
    public class FuncionarioViewModel : PadraoViewModel
    {
        public string Nome { get; set; }
        public int CargoId { get; set; }
        public string Email  { get; set; }
        public string DescricaoCategoria { get; set; }
        /// Imagem recebida do form pelo controller
        /// </summary>
        public IFormFile Imagem { get; set; }
        /// <summary>
        /// Imagem em bytes pronta para ser salva
        /// </summary>
        public byte[] ImagemEmByte { get; set; }
        /// <summary>
        /// Imagem usada para ser enviada ao form no formato para ser exibida
        /// </summary>
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }

    }

}
