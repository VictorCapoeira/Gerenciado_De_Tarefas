// See https://aka.ms/new-console-template for more information
using Agenda;
using Layout;
using Layout_console;

GerenciarTarefas tarefas = new GerenciarTarefas();
int escolha = 0;
do
{
    LayoutGerenciador.ExibirCabecalho("gerenciador de tarefas", true);
    Console.WriteLine("1 - Adicionar Tarefa");
    Console.WriteLine("2 - Listar Tarefas");
    Console.WriteLine("3 - Concluir Tarefa");
    Console.WriteLine("4 - Remover Tarefa");
    Console.WriteLine("0 - Sair");
    LayoutWrite.Amarelo("Escolha uma opção: ");
    if(!int.TryParse(Console.ReadLine(), out escolha)){
        LayoutWriteLine.Vermelho("Insira um valor válido! Digite para continuar...");
        Console.ReadKey();
        Console.Clear();
    }else{
        switch(escolha){
            case 1:
                Console.Clear();
                tarefas.AdicionarTarefa();
            break;
            case 2:
                Console.Clear();
                tarefas.ListarTarefas();
            break;
            case 3:
                Console.Clear();
                tarefas.ListarTarefas();
                tarefas.ConcluirTarefa();
            break;
            case 4:
                Console.Clear();
                tarefas.ListarTarefas();
                tarefas.RemoverTarefa();
            break;

        }
    }
} while (escolha != 0);
