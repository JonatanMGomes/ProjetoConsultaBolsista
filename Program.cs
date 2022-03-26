namespace ProjetoConsultaBolsista
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bolsistas = new List<Bolsista>();
            var arquivoCSV = new StreamReader(File.OpenRead(@"C:\Users\jonat\OneDrive\Área de Trabalho\Dev\arquivosExercicioDell\Amostragem120.csv"));
            int contador = 0;
            while (!arquivoCSV.EndOfStream)
            {
                var linha = arquivoCSV.ReadLine();
                if (contador >= 1)
                {
                    var colunas = linha.Split(",");
                    var nome = colunas[0];
                    var nome2 = nome.Split();
                    var cpf = colunas[1];
                    var entidadeDeEnsino = colunas[2];
                    var valorDaBolsa = double.Parse(colunas[10]);
                    var anoQueRecebeu = int.Parse(colunas[4]);
                    bolsistas.Add(new Bolsista(nome, cpf, entidadeDeEnsino, valorDaBolsa, anoQueRecebeu));
                }
                contador++;
            }
        }
    }
}