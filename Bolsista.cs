namespace ProjetoConsultaBolsista
{
    public class Bolsista
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string  EntidadeDeEnsino { get; set; }
        public double ValorDaBolsa { get; set; }
        public int AnoQueRecebeu { get; set; }
        public Bolsista(string nome, string cpf, string entidadeDeEnsino, double valorDaBolsa, int anoQueRecebeu){
            Nome = nome;
            CPF = cpf;
            EntidadeDeEnsino = entidadeDeEnsino;
            ValorDaBolsa = valorDaBolsa;
            AnoQueRecebeu = anoQueRecebeu; 
        }
    }
}