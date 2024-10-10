namespace FSBRCadastroProcessos.WebApp.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public  Microregiao Microregiao { get; set; }
        public  RegiaoImediata RegiaoImediata { get; set; }
    }

    public class Microregiao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class RegiaoImediata
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
