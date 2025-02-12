// See https://aka.ms/new-console-template for more information
using Agenda;
using Layout;
using Layout_console;

GerenciarTarefas tarefas = new GerenciarTarefas();
int escolha = 0;
do
{
    LayoutGerenciador.ExibirCabecalho("gerenciador de tarefas", true);
    Console.WriteLine("\t1 - Adicionar Tarefa");
    Console.WriteLine("\t2 - Listar Tarefas");
    Console.WriteLine("\t3 - Concluir Tarefa");
    Console.WriteLine("\t4 - Remover Tarefa");
    Console.WriteLine("\t0 - Sair");
    LayoutWrite.Amarelo("\tEscolha uma opção: ");
    if(!int.TryParse(Console.ReadLine(), out escolha)){
        LayoutWriteLine.Vermelho("\tInsira um valor válido! Digite para continuar...");
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
            case 5:
                LayoutWrite.Amarelo("\tPrograma encerrado!");
            break;
            default:
                Console.Clear();
                LayoutWrite.Vermelho("\tAção inválida!");
            break;
        }
    }
} while (escolha != 0);
