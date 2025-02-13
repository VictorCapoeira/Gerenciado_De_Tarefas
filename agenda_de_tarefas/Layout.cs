using Layout_console;
namespace Layout
{
    public class LayoutGerenciador
    {
        public static void ExibirCabecalho(string titulo, Boolean maiusculo = false)
        {
                int largura = Console.WindowWidth;
                char[] letraMais = titulo.ToCharArray();
                letraMais[0] = char.ToUpper(letraMais[0]);
                string tituloMais = new string(letraMais);
                
                string linhaSuperior = $"╔{new string('═', titulo.Length + 2)}╗";
                string linhaMeio = $"║ {(maiusculo ? titulo.ToUpper() : tituloMais )} ║";
                string linhaInferior = $"╚{new string('═', titulo.Length + 2)}╝";

                
                int posX = (largura - linhaSuperior.Length) / 2;

                
                int posY = Console.CursorTop;

                
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine(linhaSuperior);

                Console.SetCursorPosition(posX, posY + 1);
                Console.WriteLine(linhaMeio);

                Console.SetCursorPosition(posX, posY + 2);
                Console.WriteLine(linhaInferior);
        }
    }
}