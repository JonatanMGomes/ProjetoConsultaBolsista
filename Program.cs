using System.Globalization;
using System.Text;

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
                    var nome = colunas[0].Replace('/', ' ');
                    nome = nome.Replace('"', ' ');
                    var cpf = colunas[1].Replace('/', ' ');
                    cpf = cpf.Replace('"', ' ');
                    var entidadeDeEnsino = colunas[2].Replace('/', ' ');
                    entidadeDeEnsino = entidadeDeEnsino.Replace('"', ' ');
                    var valorDaBolsa = colunas[10].Replace('/', ' ');
                    valorDaBolsa = valorDaBolsa.Replace('"', ' ');
                    valorDaBolsa = valorDaBolsa.Replace(" ", "");
                    var anoQueRecebeu = colunas[4].Replace('/', ' ');
                    anoQueRecebeu = anoQueRecebeu.Replace('"', ' ');
                    anoQueRecebeu = anoQueRecebeu.Replace(" ", "");
                    bolsistas.Add(new Bolsista(nome, cpf, entidadeDeEnsino, double.Parse(valorDaBolsa), int.Parse(anoQueRecebeu)));
                }
                contador++;
            }
            string escolhaDoMenu;
            Console.WriteLine("Seja bem vindo ao nosso sistema!");
            do
            {
                Console.WriteLine("O que deseja fazer? Escolha uma das opções:");
                Console.WriteLine("1 = Consultar bolsista Zero do ano desejado.");
                Console.WriteLine("2 = Consultar valor médio das bolsas do ano desejado.");
                Console.WriteLine("3 = Consultar lista das 3 bolsas de maior e menor valor.");
                Console.WriteLine("4 = Consultar bolsista por nome.");
                Console.WriteLine("5 = Finalizar consultas e sair do programa.");

                escolhaDoMenu = Console.ReadLine();
                switch (escolhaDoMenu)
                {
                    case "1":
                        DescobreBolsistaZeroDoAno(bolsistas);
                        break;
                    case "2":
                        ValorMedioDasBolsasNoAno(bolsistas);
                        break;
                    case "3":
                        RankearBolsasTresMaisETresMenos(bolsistas);
                        break;
                    case "4":
                        BuscaBolsistaPorNome();
                        break;
                    case "5":
                        Console.WriteLine("Obrigado por utilizar nosso sistema!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (escolhaDoMenu != "5");
        }
        public static void DescobreBolsistaZeroDoAno(List<Bolsista> bolsistas)
        {
            Console.WriteLine("Deseja saber quem foi o bolsista zero de qual ano? Ex: 2015");
            int anoEscolhido;
            bool validacao = int.TryParse(Console.ReadLine(), out anoEscolhido);
            if (validacao == true)
            {
                if (bolsistas.Exists(bolsista => bolsista.AnoQueRecebeu == anoEscolhido))
                {
                    var bolsistaZero = bolsistas.Find(zero => zero.AnoQueRecebeu == anoEscolhido);
                    Console.WriteLine($"O bolsista zero no ano de {anoEscolhido} é:");
                    Console.WriteLine($"{bolsistaZero.Nome}, CPF: {bolsistaZero.CPF}, para estudar na: {bolsistaZero.EntidadeDeEnsino} e com uma bolsa no valor de R$ {bolsistaZero.ValorDaBolsa}");
                }
                else
                {
                    Console.WriteLine("Nenhum resultado encontrado para o ano informado.");
                }
            }
            else
            {
                Console.WriteLine("O ano informado é inválido ou foi escrito de maneira inválida.");
            }

        }
        public static void BuscaBolsistaPorNome()
        {
            Console.WriteLine("Qual o nome do Bolsista que deseja procurar? Pode ser completo ou não.");
            string nomeABuscar = Console.ReadLine();
            //Console.WriteLine(CriptografarNome(nomeABuscar));
            string nomeTeste = RemoveAcentos(nomeABuscar);
            Console.WriteLine(nomeTeste);
            //var bolsistaProcurado = bolsistas.Find(zero => zero.AnoQueRecebeu == anoEscolhido);
        }
        public static string CriptografarNome(string nomeACodificar)
        {
            string nomeCodificado;
            var nomeCodificando = nomeACodificar.ToCharArray();
            var nomeAntesDeCodificar = nomeACodificar.ToArray();
            var primeiraLetra = nomeCodificando[0];
            nomeCodificando[0] = nomeCodificando[nomeCodificando.Length - 1];
            nomeCodificando[nomeCodificando.Length - 1] = primeiraLetra;
            var nomeCodificandoInvertido = nomeCodificando;
            Array.Reverse(nomeCodificandoInvertido);
            if (nomeAntesDeCodificar != nomeCodificandoInvertido)
            {
                Array.Reverse(nomeCodificando);
                for (int contador = 0; contador < nomeCodificando.Length; contador++)
                {
                    if (nomeCodificando[contador] == 'Z')
                    {
                        nomeCodificando[contador] = 'A';
                    }
                    else
                    {
                        nomeCodificando[contador] = (char)(((int)nomeCodificando[contador]) + 1);
                    }
                }
            }
            else
            {
                for (int contador = 0; contador < nomeCodificando.Length; contador++)
                {
                    if (nomeCodificando[contador] == 'Z')
                    {
                        nomeCodificando[contador] = 'A';
                    }
                    else
                    {
                        nomeCodificando[contador] = (char)(((int)nomeCodificando[contador]) + 1);
                    }
                }
            }
            nomeCodificado = new String(nomeCodificando);
            return nomeCodificado;
        }
        public static void ValorMedioDasBolsasNoAno(List<Bolsista> bolsistas)
        {
            Console.WriteLine("Quer saber o valor médio das bolsas de que ano? Ex: 2016");
            int anoEscolhido;
            bool validacao = int.TryParse(Console.ReadLine(), out anoEscolhido);
            double valorTotal = 0;
            int qtdBolsistas = 0;
            if (validacao == true)
            {
                if (bolsistas.Exists(bolsista => bolsista.AnoQueRecebeu == anoEscolhido))
                {
                    for (int contador = 0; contador < bolsistas.Count(); contador++)
                    {
                        if (bolsistas[contador].AnoQueRecebeu == anoEscolhido)
                        {
                            valorTotal = valorTotal + (bolsistas[contador].ValorDaBolsa);
                            qtdBolsistas++;
                        }
                    }
                    Console.WriteLine($"O valor médio das bolsas no ano de {anoEscolhido} é de: R$ {valorTotal / qtdBolsistas}");
                }
                else
                {
                    Console.WriteLine("Nenhum resultado encontrado para o ano informado.");
                }

            }
            else
            {
                Console.WriteLine("O ano informado é inválido ou foi escrito de maneira inválida.");
            }


        }
        public static void RankearBolsasTresMaisETresMenos(List<Bolsista> bolsistas)
        {
            var bolsistasOrdemValorCrescente = bolsistas.OrderBy(bolsistasValor => bolsistasValor.ValorDaBolsa);
            Console.WriteLine("Os bolsistas com as 3 bolsas de menor valor são:");
            for (int contador = 0; contador < 3; contador++)
            {
                Console.WriteLine($"{bolsistasOrdemValorCrescente.ElementAt(contador).Nome}, com o valor de: R$ {bolsistasOrdemValorCrescente.ElementAt(contador).ValorDaBolsa}");
            }
            Console.WriteLine("Os bolsistas com as 3 bolsas de maior valor são:");
            for (int contador = (bolsistasOrdemValorCrescente.Count() - 1); contador >= (bolsistasOrdemValorCrescente.Count() - 3); contador--)
            {
                Console.WriteLine($"{bolsistasOrdemValorCrescente.ElementAt(contador).Nome}, com o valor de: R$ {bolsistasOrdemValorCrescente.ElementAt(contador).ValorDaBolsa}");
            }
        }
        static string RemoveAcentos(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}