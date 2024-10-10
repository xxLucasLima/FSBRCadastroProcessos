namespace FSBRCadastroProcessos.API.Domain.Entities
{
    public class Cadastro
    {
        public int Id { get; set; }
        public string? NomeProcesso { get; set; }
        public string? NPU { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? UF { get; set; }
        public string? Municipio { get; set; }
    }
}
