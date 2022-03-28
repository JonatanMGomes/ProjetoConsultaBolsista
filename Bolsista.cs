namespace ProjetoConsultaBolsista
{
    public class Bolsista
    {
        public string Nome { get; }
        public string CPF { get; }
        public string  EntidadeDeEnsino { get; }
        public double ValorDaBolsa { get; }
        public int AnoQueRecebeu { get; }
        public bool CodificarNome { get; private set; }
        public Bolsista(string nome, string cpf, string entidadeDeEnsino, double valorDaBolsa, int anoQueRecebeu){
            Nome = nome;
            CPF = cpf;
            EntidadeDeEnsino = entidadeDeEnsino;
            ValorDaBolsa = valorDaBolsa;
            AnoQueRecebeu = anoQueRecebeu; 
        }
        public void PrecisaCodificarNome(){
            CodificarNome = true;
        }
    }
}