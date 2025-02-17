using System.Collections.Generic;
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
            string arquivo = Path.Combine("..\\Debug",caminhoPasta, $"Tarefas_{data_Atual}.txt");
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
        public void ListarTarefasAntigas(){
            
        }
    }
}