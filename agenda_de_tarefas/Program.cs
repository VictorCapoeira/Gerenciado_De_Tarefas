// See https://aka.ms/new-console-template for more information
using System.Text;
using Agenda;
using Layout;
using Layout_console;
Console.Clear();
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

GerenciarTarefas tarefas = new GerenciarTarefas();
GerenciarTarefas tarefas_antigas = new GerenciarTarefas();
int escolha = 0;
do
{
Return1:
    LayoutGerenciador.ExibirCabecalho("gerenciador de tarefas", true);
    Console.WriteLine("\t1 - Adicionar Tarefa");
    Console.WriteLine("\t2 - Listar Tarefas");
    Console.WriteLine("\t3 - Concluir Tarefa");
    Console.WriteLine("\t4 - Remover Tarefa");
    Console.WriteLine("\t5 - Salvar Tarefas");
    Console.WriteLine("\t6 - Tarefas antigas");
    Console.WriteLine("\t0 - Sair");
    LayoutWrite.Amarelo("\tEscolha uma opção: ");
    if (!int.TryParse(Console.ReadLine(), out escolha))
    {
        LayoutWriteLine.Vermelho("\tInsira um valor válido! Digite para continuar...");
        Console.ReadKey();
        Console.Clear();
        goto Return1;
    }
    else
    {
        switch (escolha)
        {
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
                Console.Clear();
                tarefas.ListarTarefas();
                break;
            case 4:
                Console.Clear();
                tarefas.ListarTarefas();
                tarefas.RemoverTarefa();
                Console.Clear();
                tarefas.ListarTarefas();
                break;
            case 5:
                Console.Clear();
                tarefas.SalvarTarefas();
                break;
             case 6:
                Console.Clear();
                tarefas_antigas.ListarTarefasAntigas();
                break;
            case 0:
                Console.Clear();
                LayoutWrite.Amarelo("\n\tPrograma encerrado!");
                break;
            default:
                Console.Clear();
                LayoutWrite.Vermelho("\tAção inválida!");
                break;
        }
    }
} while (escolha != 0);
