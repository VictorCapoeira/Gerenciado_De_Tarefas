using Layout_console;
namespace Layout
{
    public class LayoutGerenciador{

        public static void Centralizar(string texto){
            int largura = Console.WindowWidth;
            int altura = Console.WindowHeight;
        }
        public static void ExibirCabecalho(string titulo, Boolean estado = false){
            if(estado){

                LayoutPosicao.Centralizar($"╔{new string('═', titulo.Length + 2)}╗");
                LayoutPosicao.Centralizar($"║{new string(' ', 1)}{titulo.ToUpper()}{new string(' ', 1)}║");
                LayoutPosicao.Centralizar($"╚{new string('═', titulo.Length + 2)}╝");
            }else{
                char [] letraMais = titulo.ToCharArray();
                letraMais[0] = char.ToUpper(letraMais[0]);
                string tituloMais = new string(letraMais);
                LayoutPosicao.Centralizar($"╔{new string('═', titulo.Length + 2)}╗");
                LayoutPosicao.Centralizar($"║{new string(' ', 1)}{tituloMais}{new string(' ', 1)}║");
                LayoutPosicao.Centralizar($"╚{new string('═', titulo.Length + 2)}╝");
            }
            
        }
    }
}