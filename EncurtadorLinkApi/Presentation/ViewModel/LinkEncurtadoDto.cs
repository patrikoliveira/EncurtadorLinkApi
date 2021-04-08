namespace EncurtadorLinkApi.Presentation.ViewModel
{
    public class LinkEncurtadoDto
    {
        public string Domain { get; set; }
        public string Resource { get; set; }
        public string UserId { get; set; }
        public string Hash { get; set; }
    }
}