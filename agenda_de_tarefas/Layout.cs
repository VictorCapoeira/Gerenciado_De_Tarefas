using Layout_console;
namespace Layout
{
    public class LayoutGerenciador
    {
        public static void ExibirCabecalho(string titulo, Boolean estado = false)
        {
            if (estado)
            {

                int largura = Console.WindowWidth;

                // Criando o cabeçalho com bordas
                string linhaSuperior = $"╔{new string('═', titulo.Length + 2)}╗";
                string linhaMeio = $"║ {titulo.ToUpper()} ║";
                string linhaInferior = $"╚{new string('═', titulo.Length + 2)}╝";

                // Calcula a posição X (centralizado horizontalmente)
                int posX = (largura - linhaSuperior.Length) / 2;

                // Obtém a posição atual do cursor para centralizar na mesma linha
                int posY = Console.CursorTop;

                // Posiciona e escreve no console
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine(linhaSuperior);

                Console.SetCursorPosition(posX, posY + 1);
                Console.WriteLine(linhaMeio);

                Console.SetCursorPosition(posX, posY + 2);
                Console.WriteLine(linhaInferior);
            }
            else
            {
                char[] letraMais = titulo.ToCharArray();
                letraMais[0] = char.ToUpper(letraMais[0]);
                string tituloMais = new string(letraMais);
                Centralizar($"╔{new string('═', titulo.Length + 2)}╗");
                Centralizar($"║{new string(' ', 1)}{tituloMais}{new string(' ', 1)}║");
                Centralizar($"╚{new string('═', titulo.Length + 2)}╝");
            }

        }
    }
}