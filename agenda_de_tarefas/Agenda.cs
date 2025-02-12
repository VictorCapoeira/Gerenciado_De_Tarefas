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
        public void AdicionarTarefa(string nome){
            LayoutWrite.Amarelo("Nome da tarefa: ");
            nome = Console.ReadLine();
            tarefas.Add(new Tarefa(IdCount, nome));
            LayoutWrite.Verde("Tarefa adicionada!");
            IdCount++;
            
        }
        public void ListarTarefas(){
            if(tarefas.Count == 0)
                LayoutWrite.Vermelho("Não há tarefas!");
            else{
                LayoutWriteLine.Amarelo("Lista de Tarefas: ");
                foreach( var tarefa in tarefas){
                    LayoutWriteLine.Cinza("ID: " + tarefa.Id.ToString());
                    LayoutWriteLine.Cinza(tarefa.Nome);
                    if(tarefa.Status)
                        LayoutWriteLine.Cinza("[x]");
                    else
                        LayoutWriteLine.Cinza("[ ]");
                    LayoutLinha.Meia();
                }
            }
        }
        public void ConcluirTarefa(int i){
            LayoutWrite.Amarelo("Insira o ID: ");
            i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefas.Find(t => t.Id == i);
            if(tarefa != null){
                tarefa.Concluir();
            }else
                LayoutWrite.Vermelho("Tarefa não encontrada!");
        }
        public void RemoverTarefa(int i){
            LayoutWrite.Amarelo("Insira o ID: ");
            i = int.Parse(Console.ReadLine());
            Tarefa tarefa = tarefas.Find(t => t.Id == i);
            if(tarefa != null){
                tarefas.Remove(tarefa);
                LayoutWrite.Verde("Tarefa removida!");
            }else
                LayoutWrite.Vermelho("Tarefa não encontrada!");
        }
    }
}