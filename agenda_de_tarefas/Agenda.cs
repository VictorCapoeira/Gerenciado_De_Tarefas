using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Layout_console;
namespace Agenda
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public Tarefa(int i, string n)
        {
            Id = i;
            Nome = n;
            Status = false;
        }
        public void Concluir()
        {
            Status = true;
        }
    }
    public class GerenciarTarefas
    {
        private List<Tarefa> tarefas = new List<Tarefa>();
        private int IdCount = 1;
        public void AdicionarTarefa()
        {
            static string LerEntradaComBackspace()
            {
                StringBuilder input = new StringBuilder();
                while (true)
                {
                    // Captura a tecla pressionada
                    var key = Console.ReadKey(intercept: true);

                    // Se pressionar Enter, finaliza a captura de entrada
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    // Se pressionar Backspace, apaga o último caractere
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input.Remove(input.Length - 1, 1);
                        Console.Write("\b \b"); // Apaga o caractere na tela
                    }
                    else
                    {
                        // Adiciona o caractere ao texto
                        input.Append(key.KeyChar);
                        Console.Write(key.KeyChar); // Exibe o caractere digitado
                    }
                }

                return input.ToString();
            }
            LayoutWrite.Amarelo("\n\tNome da tarefa: ");
            string nome = LerEntradaComBackspace();
            tarefas.Add(new Tarefa(IdCount, nome));
            LayoutWriteLine.Verde("\tTarefa adicionada!");
            IdCount++;

        }
        public void ListarTarefas()
        {
            if (tarefas.Count == 0)
                LayoutWriteLine.Vermelho("\tNão há tarefas!");
            else
            {
                LayoutWriteLine.Amarelo("\n\tLista de Tarefas: ");
                foreach (var tarefa in tarefas)
                {
                    LayoutWriteLine.Cinza($"\t[{(tarefa.Status ? "X" : " ")}] ID: {tarefa.Id.ToString()} - {tarefa.Nome}");
                }
            }
        }
        public void ConcluirTarefa()
        {
            LayoutWrite.Amarelo("\n\tInsira o ID: ");
            int i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefas.Find(t => t.Id == i);
            if (tarefa != null)
            {
                tarefa.Concluir();
                LayoutWrite.Verde($"\tTarefa {tarefa.Id} Concluida! Digite para continuar...");
                Console.ReadKey();

            }
            else
                LayoutWrite.Vermelho("\tTarefa não encontrada!");
        }
        public void RemoverTarefa()
        {
            LayoutWrite.Amarelo("\n\tInsira o ID: ");
            int i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefas.Find(t => t.Id == i);
            if (tarefa != null)
            {
                tarefas.Remove(tarefa);
                LayoutWrite.Verde($"\tTarefa {tarefa.Id} removida! Digite para continuar...");
                Console.ReadKey();
            }
            else
                LayoutWrite.Vermelho("\tTarefa não encontrada!");
        }
        public void SalvarTarefas()
        {
            string data_Atual = DateTime.Now.ToString("dd-MM-yyyy");
            string diretórioAplicativo = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string nomePasta = "tarefas";
            string caminhoPasta = Path.Combine(diretórioAplicativo, nomePasta);
            string arquivo = Path.Combine("..\\Debug", caminhoPasta, $"Tarefas_{data_Atual}.txt");
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }
            using (StreamWriter sw = new StreamWriter(arquivo))
            {
                foreach (var tarefa in tarefas)
                {
                    sw.WriteLine($"\t[{(tarefa.Status ? "X" : " ")}] ID: {tarefa.Id.ToString()} - {tarefa.Nome}");
                }
            }
            LayoutWriteLine.Verde("\tTarefas salvas!");
        }
    }
    public class GerenciarTarefasAntigas
    {

        private List<Tarefa> tarefasAntigas = new List<Tarefa>();
        public string data_antiga = "";
        public void ListarArquivosAntigas()
        {
            string pastaTarefas = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "tarefas");
            if (!Directory.Exists(pastaTarefas))
            {
                LayoutWriteLine.Vermelho("\n\t O caminho do arquivo pode estar errado!");
                LayoutWriteLine.Vermelho("\n\t Confira se a pasta 'tarefas' está na raiz da pasta do programa!");
                return;
            }
            string[] arquivos = Directory.GetFiles(pastaTarefas, "Tarefas*.txt");
            if (arquivos.Length == 0)
            {
                LayoutWriteLine.Vermelho("\n\tNenhum arquivo de tarefas foi encontrado!");
                return;
            }

            LayoutWriteLine.Amarelo("\n\t Arquivos de Tarefas passadas: ");

            foreach (string tarefa in arquivos)
            {

                string nomeArquivo = Path.GetFileNameWithoutExtension(tarefa);
                string arquivoData = nomeArquivo.Replace("Tarefas_", "");
                LayoutWriteLine.Verde("\t  " + arquivoData);
            }

        }
        public void CarregarTarefas()
        {
            string pastaTarefas = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "tarefas");
            string[] arquivos = Directory.GetFiles(pastaTarefas, "Tarefas*.txt");
        Return3:
            ListarArquivosAntigas();
            Console.WriteLine("Dataaaaa " + arquivos[0]);
            LayoutWriteLine.Amarelo("\n\tInsira a data que deseja listar (dia-mês-ano): ");
            String dataEscolhida = Console.ReadLine();
            data_antiga =  dataEscolhida;
            dataEscolhida = $"C:\\Users\\Alunos\\OneDrive\\Documentos\\Nada_Oculto_permance\\Git_clones\\Gerenciado_De_Tarefas\\agenda_de_tarefas\\tarefas\\Tarefas_{dataEscolhida}.txt";
            if (!arquivos.Contains(dataEscolhida))
            {
                LayoutWriteLine.Vermelho("\n\tDigite uma data listada!");
                goto Return3;
            }
            using (StreamReader arquivo_string = new StreamReader(dataEscolhida))
            {
                String teste;
                while ((teste = arquivo_string.ReadLine()) != null)
                {
                    var partes_coletadas = teste.Split(new[] { " ID: ", " - " }, StringSplitOptions.None);

                    Console.WriteLine(partes_coletadas[0].Trim());
                    Console.WriteLine(partes_coletadas[1].Trim());
                    Console.WriteLine(partes_coletadas[2].Trim());
                    tarefasAntigas.Add(new Tarefa(int.Parse(partes_coletadas[1].Trim()), partes_coletadas[2].Trim()));
                    Tarefa tarefa = tarefasAntigas.Find(t => t.Id == int.Parse(partes_coletadas[1].Trim()));
                    tarefa.Status = partes_coletadas[0] == "[X]" ? true : false;
                }
            }
        }
        public void ListarTarefasAntigas()
        {
            if (tarefasAntigas.Count == 0)
                LayoutWriteLine.Vermelho("\tNão há tarefas!");
            else
            {
                LayoutWriteLine.Amarelo("\n\tLista de Tarefas: ");
                foreach (var tarefa in tarefasAntigas)
                {
                    LayoutWriteLine.Cinza($"\t[{(tarefa.Status ? "X" : " ")}] ID: {tarefa.Id.ToString()} - {tarefa.Nome}");
                }
            }
        }
        public void ConcluirTarefaAntigas()
        {
            LayoutWrite.Amarelo("\n\tInsira o ID: ");
            int i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefasAntigas.Find(t => t.Id == i);
            if (tarefa != null)
            {
                tarefa.Concluir();
                LayoutWrite.Verde($"\tTarefa {tarefa.Id} Concluida! Digite para continuar...");
                Console.ReadKey();

            }
            else
                LayoutWrite.Vermelho("\tTarefa não encontrada!");
        }
        public void RemoverTarefaAntigas()
        {
            LayoutWrite.Amarelo("\n\tInsira o ID: ");
            int i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefasAntigas.Find(t => t.Id == i);
            if (tarefa != null)
            {
                tarefasAntigas.Remove(tarefa);
                LayoutWrite.Verde($"\tTarefa {tarefa.Id} removida! Digite para continuar...");
                Console.ReadKey();

            foreach(string tarefa in arquivos){
                string nomeArquivo = Path.GetFileNameWithoutExtension(tarefa);
                string arquivoData = nomeArquivo.Replace("Tarefas_","");
                LayoutWriteLine.Verde(arquivoData);

            }
            else
                LayoutWrite.Vermelho("\tTarefa não encontrada!");
        }
        public void SalvarTarefasAntigas()
        {
            string diretórioAplicativo = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string nomePasta = "tarefas";
            string caminhoPasta = Path.Combine(diretórioAplicativo, nomePasta);
            string arquivo = Path.Combine("..\\Debug", caminhoPasta, $"Tarefas_{data_antiga}.txt");
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }
            using (StreamWriter sw = new StreamWriter(arquivo))
            {
                foreach (var tarefa in tarefasAntigas)
                {
                    sw.WriteLine($"\t[{(tarefa.Status ? "X" : " ")}] ID: {tarefa.Id.ToString()} - {tarefa.Nome}");
                }
            }
            LayoutWriteLine.Verde("\tTarefas salvas!");
        }
    }
}