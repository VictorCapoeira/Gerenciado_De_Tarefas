namespace Agenda
{
    public class Tarefas{
        public int Id {get; set;}
        public string Nome {get; set;}
        public bool Status {get; set;}
        public Tarefas(int i, string n){
            Id = i;
            Nome = n;
            Status = false;
        }
    }
}