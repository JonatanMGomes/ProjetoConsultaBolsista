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
                    var nome = colunas[0].Replace('/',' ');
                    nome = nome.Replace('"', ' ');
                    var cpf = colunas[1].Replace('/',' ');
                    cpf = cpf.Replace('"', ' ');
                    var entidadeDeEnsino = colunas[2].Replace('/',' ');
                    entidadeDeEnsino = entidadeDeEnsino.Replace('"', ' ');
                    var valorDaBolsa = colunas[10].Replace('/',' ');
                    valorDaBolsa = valorDaBolsa.Replace('"', ' ');
                    valorDaBolsa = valorDaBolsa.Replace(" ", "");
                    var anoQueRecebeu = colunas[4].Replace('/',' ');
                    anoQueRecebeu = anoQueRecebeu.Replace('"', ' ');
                    anoQueRecebeu = anoQueRecebeu.Replace(" ", "");
                    bolsistas.Add(new Bolsista(nome, cpf, entidadeDeEnsino, double.Parse(valorDaBolsa), int.Parse(anoQueRecebeu)));
                }
                contador++;
            }
        }
        public static void DescobreBolsistaZeroDoAno(List<Bolsista> bolsistas){
            Console.WriteLine("Deseja saber quem foi o bolsista zero de qual ano? Ex: 2015");
            int anoEscolhido = int.Parse(Console.ReadLine());
            var bolsistaZero = bolsistas.Find(zero => zero.AnoQueRecebeu == anoEscolhido);
            Console.WriteLine($"O bolsista zero no ano de {anoEscolhido} é:");
            Console.WriteLine($"{bolsistaZero.Nome}, CPF: {bolsistaZero.CPF}, para estudar na: {bolsistaZero.EntidadeDeEnsino} e com uma bolsa no valor de {bolsistaZero.ValorDaBolsa}");
        }
        public static void CriptografarNome(){

        }
        public static void ValorMedioDasBolsasNoAno(){

        }
        public static void RankearBolsasTresMaisETresMenos(){

        }

    }
}