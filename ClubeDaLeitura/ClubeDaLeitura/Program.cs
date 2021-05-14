using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                TelaPrincipal tela = new TelaPrincipal();
                tela.SelecionarTela();
            }

        }
    }

    public class ControladorBase
    {
        public static int CAPACIDADE_CADASTROS = 100;

        const int CAPACIDADE_REGISTROS = 100;

        protected object[] cadastros;

        public ControladorBase()
        {
            cadastros = new object[CAPACIDADE_REGISTROS];
        }

        public int ObterPosicaoOcupada(object obj)
        {
            int posicao = 0;

            for (int i = 0; i < cadastros.Length; i++)
            {
                if (cadastros[i] != null && cadastros[i].Equals(obj)) 
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }

        public int ObterPosicaoVaga()
        {
            int posicao = 0;

            for (int i = 0; i < cadastros.Length; i++)
            {
                if (cadastros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }

        public int QuantidadeCadastros()
        { 
            int numeroCadastros = 0;

            for (int i = 0; i < cadastros.Length; i++)
            {
                if (cadastros[i] != null)
                {
                    numeroCadastros++;
                }
            }

            return numeroCadastros;
        }

    }

    class ControladorRevista : ControladorBase
    {           

        public string GravarRevista(int id, string coleção, string numero, string ano)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Cadastrando nova revista...");
            Console.ResetColor();

            Revista revista = null;

            int posicao;

             if (id == 0)
             {
                 revista = new Revista();
                 posicao = ObterPosicaoVaga();
             }
             else
             {
                 posicao = ObterPosicaoOcupada(new Revista(id));
                 revista = (Revista)cadastros[posicao];
             } 


            revista.coleção = coleção;
            revista.numeroEdição = numero;
            revista.anoRevista = ano;

            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "CADASTRO_VALIDO")
                cadastros[posicao] = revista;           

            return resultadoValidacao; 
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistasAux = new Revista[QuantidadeCadastros()];

            Array.Copy(SelecionarTodasRevistas(), revistasAux, revistasAux.Length);

            return revistasAux;
        }


    }

    class ControladorAmigo : ControladorBase
    {
        public string GravarAmiguinho(int id, string nomeAmiguinho, string nomeResponsável, string telefone, string local)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Cadastrando novo amiguinho...");
            Console.ResetColor();

            Amigo amiguinho = null;

            int posicao;

            if (id == 0)
            {
                amiguinho = new Amigo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amigo(id));
                amiguinho = (Amigo)cadastros[posicao];
            }


            amiguinho.nomeAmiguinho = nomeAmiguinho;
            amiguinho.nomeResponsavel = nomeResponsável;
            amiguinho.telefone = telefone;
            amiguinho.local = local;
            

            string resultadoValidacao = amiguinho.Validar();

            if (resultadoValidacao == "CADASTRO_VALIDO")
                cadastros[posicao] = amiguinho;

            return resultadoValidacao;
        }

        public Amigo[] SelecionarTodosAmiguinhos()
        {
            Amigo[] amigosAux = new Amigo[QuantidadeCadastros()];

            Array.Copy(SelecionarTodosAmiguinhos(), amigosAux, amigosAux.Length);

            return amigosAux;
        }
    }

    class ControladorCaixa : ControladorBase
    {
        public string GravarCaixa(int id, string cor, string etiqueta, string numero)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Cadastrando nova caixa...");
            Console.ResetColor();

            Caixa caixa = null;

            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)cadastros[posicao];
            }


            caixa.cor = cor;
            caixa.etiquetaCaixa = etiqueta;
            caixa.numeroCaixa = numero;


            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CADASTRO_VALIDO")
                cadastros[posicao] = caixa;

            return resultadoValidacao;
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixasAux = new Caixa[QuantidadeCadastros()];

            Array.Copy(SelecionarTodasCaixas(), caixasAux, caixasAux.Length);

            return caixasAux;
        }

    }

    class ControladorEmpréstimo : ControladorBase
    {
       
        public string GravarEmpréstimo(int id, DateTime data, DateTime devolução)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Cadastrando novo empréstimo...");
            Console.ResetColor();

            Empréstimo empréstimo = null;

            int posicao;

            if (id == 0)
            {
                empréstimo = new Empréstimo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Empréstimo(id));
                empréstimo = (Empréstimo)cadastros[posicao];
            }

            empréstimo.dataEmpréstimo = data;
            empréstimo.dataDevolução = devolução;            

            string resultadoValidacao = empréstimo.Validar();

            if (resultadoValidacao == "CADASTRO_VALIDO")
                cadastros[posicao] = empréstimo;

            return resultadoValidacao;
        }

        public Empréstimo[] SelecionarTodosEmpréstimos()
        {
            Empréstimo[] empAux = new Empréstimo[QuantidadeCadastros()];

            Array.Copy(SelecionarTodosEmpréstimos(), empAux, empAux.Length);

            return empAux;
        }

    }

    class TelaBase
    {
        ControladorBase controlador = new ControladorBase();

        public virtual void InserirNovoCadastro()
        {
            
        }

        virtual public void SelecionarTela() 
        {
            Console.WriteLine("Menu Clube da Leitura 1.0");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Opção 1 - Menu de Revistas");
            Console.WriteLine("Opção 2 - Menu de Amiguinhos");
            Console.WriteLine("Opção 3 - Menu de Caixas");
            Console.WriteLine("Opção 4 - Menu de empréstimos");
            Console.WriteLine(" ");
            Console.WriteLine("Digite s para finalizar a aplicação.");
            string opção = Console.ReadLine();

            if(opção == "1")
            {
                TelaRevista telaRevista = new TelaRevista();
                telaRevista.MenuRevista();
            }
            if(opção == "2")
            {
                TelaAmiguinho telaAmiguinho = new TelaAmiguinho();
                telaAmiguinho.MenuAmiguinho();
            }
            if(opção == "3")
            {
                TelaCaixa telaCaixa = new TelaCaixa();
                telaCaixa.MenuCaixa();
            }
            if(opção == "4")
            {
                TelaEmpréstimo telaEmpréstimo = new TelaEmpréstimo();
                telaEmpréstimo.MenuEmpréstimo();
            }
            if(opção.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }

        }

        virtual public void MenuRevista()
        {
            TelaRevista tela = new TelaRevista();

            Console.Clear();
            Console.WriteLine("Menu de Revistas 1.0");
            Console.WriteLine("Opção 1 - Cadastrar nova revista");
            Console.WriteLine("Opção 2 - Visualizar revistas cadastradas");
            string opção = Console.ReadLine();

            if (opção == "1")
            {                
                tela.InserirNovoCadastro();
            }
            if (opção == "2")
            {
                tela.VisualizarRevistas();
            } 

        }

        virtual public void MenuAmiguinho()
        {
            TelaAmiguinho tela = new TelaAmiguinho();

            Console.Clear();
            Console.WriteLine("Menu de Amiguinhos 1.0");
            Console.WriteLine("Opção 1 - Cadastrar novo amiguinho");
            Console.WriteLine("Opção 2 - Visualizar amiguinhos cadastrados");
            string opção = Console.ReadLine();

            if (opção == "1")
            {
                tela.InserirNovoCadastro();
            }
            if (opção == "2")
            {
                tela.VisualizarAmiguinhos();
            }
        }

        virtual public void MenuCaixa()
        {
            TelaCaixa tela = new TelaCaixa();

            Console.Clear();
            Console.WriteLine("Menu de Caixas 1.0");
            Console.WriteLine("Opção 1 - Cadastrar nova caixa");
            Console.WriteLine("Opção 2 - Visualizar caixas cadastradas");
            string opção = Console.ReadLine();

            if (opção == "1")
            {
                tela.InserirNovoCadastro();
            }
            if (opção == "2")
            {
                tela.VisualizarCaixas();
            }
        }

        virtual public void MenuEmpréstimo()
        {
            TelaEmpréstimo tela = new TelaEmpréstimo();

            Console.Clear();
            Console.WriteLine("Menu de Empréstimos 1.0");
            Console.WriteLine("Opção 1 - Cadastrar novo empréstimo");
            Console.WriteLine("Opção 2 - Visualizar impréstimos cadastrados");
            string opção = Console.ReadLine();

            if (opção == "1")
            {
                tela.InserirNovoCadastro();
            }
            if (opção == "2")
            {
                tela.VisualizarEmpréstimos();
            }
        }

        protected void ApresentarMensagem(string mensagem, TipoMensagem tm)
        {
            switch (tm)
            {
                case TipoMensagem.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case TipoMensagem.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case TipoMensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }
                        
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        protected void ConfigurarTela(string subtitulo)
        {
            Console.Clear();                      

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }
    }

    class TelaPrincipal : TelaBase
    {        

        override public void SelecionarTela() 
        {
            base.SelecionarTela();
        }
    }

    class TelaRevista : TelaBase
    {
        ControladorRevista controlador = new ControladorRevista();

        override public void MenuRevista()
        {
            base.MenuRevista();
        }

        public override void InserirNovoCadastro()
        {
            Console.Clear();
            ConfigurarTela("Cadastrando uma nova revista...");

            bool conseguiuGravar = CadastroRevista(0);

            if (conseguiuGravar)
                ApresentarMensagem("Revista cadastrada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar cadastrar a revista", TipoMensagem.Erro);
                InserirNovoCadastro();
            }            
        }

        public bool CadastroRevista(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.WriteLine("Insira a coleção da revista: ");
            string coleção = Console.ReadLine();

            Console.WriteLine("Insira o número da edição: ");
            string numero = Console.ReadLine();

            Console.WriteLine("Insira o ano de publicação da revista: ");
            string ano = Console.ReadLine();

            Console.Clear();

            resultadoValidacao = controlador.GravarRevista(id, coleção, numero, ano);


            if (resultadoValidacao != "CADASTRO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;           

        }

        
       public void VisualizarRevistas()
            {
                ConfigurarTela("Visualizando revistas...");

                Revista[] revistas = controlador.SelecionarTodasRevistas();

                if (revistas.Length == 0)
                {
                    ApresentarMensagem("Nenhuma revista cadastrada!", TipoMensagem.Atencao);
                    return;
                }

                for (int i = 0; i < revistas.Length; i++)
                {
                    Console.WriteLine(revistas.ToString());
                }

            }     
    }

    class TelaAmiguinho : TelaBase
    {
        ControladorAmigo controlador = new ControladorAmigo();

        override public void MenuAmiguinho()
        {
            base.MenuAmiguinho();
        }

        public void VisualizarAmiguinhos()
        {
            ConfigurarTela("Visualizando amiguinhos...");

            Amigo[] amiguinhos = controlador.SelecionarTodosAmiguinhos();

            if (amiguinhos.Length == 0)
            {
                ApresentarMensagem("Nenhum amiguinho cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < amiguinhos.Length; i++)
            {
                Console.WriteLine(amiguinhos.ToString());
            }

        }

        public bool CadastroAmiguinho(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.WriteLine("Insira o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira o nome do responsável: ");
            string responsável = Console.ReadLine();

            Console.WriteLine("Insira o telefone do responsável: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Insira o endereço: ");
            string local = Console.ReadLine();

            Console.Clear();

            resultadoValidacao = controlador.GravarAmiguinho(id, nome, responsável, telefone, local);

            if (resultadoValidacao != "CADASTRO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        public override void InserirNovoCadastro()
        {
            ConfigurarTela("Cadastrando um novo amiguinho...");

            bool conseguiuGravar = CadastroAmiguinho(0);

            if (conseguiuGravar)
                ApresentarMensagem("Amiguinho cadastrado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar cadastrar o amiguinho", TipoMensagem.Erro);
                InserirNovoCadastro();
            }
        }

    }

    class TelaCaixa : TelaBase
    {
        ControladorCaixa controlador = new ControladorCaixa();

        override public void MenuCaixa()
        {
            base.MenuCaixa();
        }

        public bool CadastroCaixa(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.WriteLine("Insira a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Insira a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("Insira o número da caixa: ");
            string numero = Console.ReadLine();
            

            Console.Clear();

            resultadoValidacao = controlador.GravarCaixa(id, cor, etiqueta, numero);

            if (resultadoValidacao != "CADASTRO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
        
        public override void InserirNovoCadastro()
        {
            ConfigurarTela("Cadastrando uma nova caixa...");

            bool conseguiuGravar = CadastroCaixa(0);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa cadastrada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar cadastrar a caixa", TipoMensagem.Erro);
                InserirNovoCadastro();
            }
        }

        public void VisualizarCaixas()
        {
            ConfigurarTela("Visualizando caixas...");

            Caixa[] caixas = controlador.SelecionarTodasCaixas();

            if (caixas.Length == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrada!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.WriteLine(caixas.ToString());
            }

        }

    }

    class TelaEmpréstimo : TelaBase
    {
        ControladorEmpréstimo controlador = new ControladorEmpréstimo();

        override public void MenuEmpréstimo()
        {
            base.MenuEmpréstimo();
        }

        public bool CadastroEmpréstimo(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.WriteLine("Insira a data do empréstimo: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Insira a data de devolução ");
            DateTime devolução = Convert.ToDateTime(Console.ReadLine());          


            Console.Clear();

            resultadoValidacao = controlador.GravarEmpréstimo(id, data, devolução);

            if (resultadoValidacao != "CADASTRO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        public override void InserirNovoCadastro()
        {
            ConfigurarTela("Cadastrando um novo empréstimo...");

            bool conseguiuGravar = CadastroEmpréstimo(0);

            if (conseguiuGravar)
                ApresentarMensagem("Empréstimo cadastrado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar cadastrar o empréstimo", TipoMensagem.Erro);
                InserirNovoCadastro();
            }
        }

        public void VisualizarEmpréstimos()
        {
            ConfigurarTela("Visualizando caixas...");

            Empréstimo[] empréstimos = controlador.SelecionarTodosEmpréstimos();

            if (empréstimos.Length == 0)
            {
                ApresentarMensagem("Nenhum empréstimo cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < empréstimos.Length; i++)
            {
                Console.WriteLine(empréstimos.ToString());
            }

        }



    }

    class Revista
    {     

        public int idRevista;
        public string coleção;
        public string numeroEdição;
        public string anoRevista;
        public Caixa caixa;

        public Revista()
        {
            idRevista = GeradorIDs.GeradorIDRevista();
        }

        public Revista(int idSelecionado)
        {
            idRevista = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";            

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CADASTRO_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return $"ID: {idRevista}, Revista: {coleção}, edição: {numeroEdição}, do ano: {anoRevista}";
        }

    }

    class Amigo
    {
      public int idAmiguinho;
      public string nomeAmiguinho;
      public string nomeResponsavel;
      public string telefone;
      public string local;        

        public Amigo()
        {
            idAmiguinho = GeradorIDs.GeradorIDRevista();
        }

        public Amigo(int idSelecionado)
        {
            idAmiguinho = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CADASTRO_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return $"ID: {idAmiguinho}, Nome: {nomeAmiguinho}, responsável: {nomeResponsavel}, telefone: {telefone}, localidade: {local}";
        }

    }

    class Caixa
    {
      public int idCaixa;
      public string cor;
      public string etiquetaCaixa;
      public string numeroCaixa;
      public Revista[] revistas;


        public Caixa()
        {
            idCaixa = GeradorIDs.GeradorIDRevista();
        }

        public Caixa(int idSelecionado)
        {
            idCaixa = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CADASTRO_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return $"ID: {idCaixa}, cor: {cor}, {etiquetaCaixa}, número: {numeroCaixa}";
        }
    }

    class Empréstimo
    {
      public int idEmpréstimo;
      public DateTime dataEmpréstimo;
      public DateTime dataDevolução;
      public Amigo amiguinho;
      public Revista revista;

        public Empréstimo()
        {
            idEmpréstimo = GeradorIDs.GeradorIDRevista();
        }

        public Empréstimo(int idSelecionado)
        {
            idEmpréstimo = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CADASTRO_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return $"ID: {idEmpréstimo}, data de empréstimo: {dataEmpréstimo}, devolução: {dataDevolução}, " +
                $"amiguinho: {amiguinho}, revista: {revista}";
        }
    }

    class GeradorIDs
    {
        public static int idRevista;
        public static int idAmiguinho;
        public static int idCaixa;
        public static int idEmpréstimo;

        public static int GeradorIDRevista()
        {
            return idRevista++;
        }

        public static int GeradorIDAmiguinho()
        {
            return idAmiguinho++;
        }

        public static int GeradorIDCaixa()
        {
            return idCaixa++;
        }

        public static int GeradorIDEmpréstimo()
        {
            return idEmpréstimo++;
        }

    }
    public enum TipoMensagem
    {
        Sucesso, Atencao, Erro
    }
}
