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
            IdCount++;
        }
    }
}