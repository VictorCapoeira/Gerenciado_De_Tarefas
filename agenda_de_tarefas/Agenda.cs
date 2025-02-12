using System.Collections.Generic;
using Layout_console;
namespace Agenda
{
    public class Tarefa{
        public int Id {get; set;}
        public string Nome {get; set;}
        public bool Status {get; set;}
        public Tarefa(int i, string n){
            Id = i;
            Nome = n;
            Status = false;
        }
        public void Concluir(){
            Status = true;
        }
    }
    public class GerenciarTarefas{
        private List<Tarefa> tarefas = new List<Tarefa>();
        private int IdCount = 1;
        public void AdicionarTarefa(){
            LayoutWrite.Amarelo("\n\tNome da tarefa: ");
            string nome = Console.ReadLine();
            tarefas.Add(new Tarefa(IdCount, nome));
            LayoutWriteLine.Verde("\tTarefa adicionada!");
            IdCount++;
            
        }
        public void ListarTarefas(){
            if(tarefas.Count == 0)
                LayoutWriteLine.Vermelho("\tNão há tarefas!");
            else{
                LayoutWriteLine.Amarelo("\n\tLista de Tarefas: ");
                foreach( var tarefa in tarefas){
                    LayoutWriteLine.Cinza($"\t[{(tarefa.Status ? "X" : " ")}] ID: {tarefa.Id.ToString()} - {tarefa.Nome}");
                }
            }
        }
        public void ConcluirTarefa(){
            LayoutWrite.Amarelo("\n\tInsira o ID: ");
            int i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefas.Find(t => t.Id == i);
            if(tarefa != null){
                tarefa.Concluir();
                LayoutWrite.Verde($"\tTarefa {tarefa.Id} Concluida! Digite para continuar...");
                Console.ReadKey();
                
            }else
                LayoutWrite.Vermelho("\tTarefa não encontrada!");
        }
        public void RemoverTarefa(){
            LayoutWrite.Amarelo("\n\tInsira o ID: ");
            int i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefas.Find(t => t.Id == i);
            if(tarefa != null){
                tarefas.Remove(tarefa);
                LayoutWrite.Verde($"\tTarefa {tarefa.Id} removida! Digite para continuar...");
                Console.ReadKey();
            }else
                LayoutWrite.Vermelho("\tTarefa não encontrada!");
        }
    }
}