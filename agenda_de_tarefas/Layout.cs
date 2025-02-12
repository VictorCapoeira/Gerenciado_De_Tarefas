using Layout_console;
namespace Layout
{
    public class LayoutGerenciador{
        public static void ExibirCabecalho(string titulo, Boolean estado = false){
            if(estado){
                LayoutPosicao.Centralizar($"╔{new string('═', titulo.Length + 2)}╗");
                LayoutPosicao.Centralizar($"║{new string(' ', 1)}{titulo.ToUpper()}{new string(' ', 1)}║");
                LayoutPosicao.Centralizar($"╚{new string('═', titulo.Length + 2)}╝");
            }else{
                LayoutPosicao.Centralizar($"╔{new string('═', titulo.Length + 2)}╗");
                LayoutPosicao.Centralizar($"║{new string(' ', 1)}{titulo}{new string(' ', 1)}║");
                LayoutPosicao.Centralizar($"╚{new string('═', titulo.Length + 2)}╝");
            }
            
        }
    }
}