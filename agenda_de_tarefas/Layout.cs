using Layout_console;
namespace Layout
{
    public class LayoutGerenciador{
        public static void ExibirCabecalho(string titulo){
            LayoutPosicao.Centralizar($"╔{new string('═', titulo.Length + 2)}╗");
            LayoutPosicao.Centralizar($"║{new string(' ', 1)}{titulo}{new string(' ', 1)}║");
            LayoutPosicao.Centralizar($"╚{new string('═', titulo.Length + 2)}╝");
        }
    }
}