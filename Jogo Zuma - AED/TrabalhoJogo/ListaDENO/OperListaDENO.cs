using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaDENO
{
    public class Elemento
    {
        public string Cor;
        public Elemento Prox = null;
        public Elemento Ant = null;

        public Elemento()                   // Construtor da Classe
        {
            Cor = "";
            Prox = null;
            Ant = null;
        }
    }

    public class Lista
    {
        private Elemento Inicio;            // Primeiro elemento da lista
        private Elemento Fim;               // Último elemento da lista
        private Elemento Aux;               // Objeto auxiliar

        public int Tamanho;                 // Número de Elementos da Lista
        public int Pontuacao = 0;

        public Lista()                      // Construtor da Classe
        {
            Inicio = null;
            Fim = null;
            Tamanho = 0;
        }

        // Função para inserir um elemento no Inicio da lista
        public void InserirInicio(string Valor)
        {
            Elemento Novo = new Elemento();     // Alocação Dinâmica - Novo Elemento para a Lista

            Novo.Cor = Valor;                   // Insere o valor do elemento na lista

            if (Inicio == null)                 // A lista está vazia? Primeiro elemento...
            {
                Inicio = Novo;                  // O elemento inserido é o primeiro e o último. Guarda o endereço dele.
                Fim = Novo;

                Novo.Prox = null;               // O ponteiro para o próximo elemento passa a ser nulo
                Novo.Ant = null;                // O ponteiro para o elemento anterior passa a ser nulo
            }
            else                                // A lista já possui elementos?
            {
                Novo.Prox = Inicio;             // O elemento Novo aponta para o elemento que já havia sido inserido anteriormente
                Inicio.Ant = Novo;              // O ponteiro anterior do elemento já existente aponta para o novo elemento
                Novo.Ant = null;                // Já que é o primeiro, o ponteiro anterior aponta para null
                Inicio = Novo;                  // e o Inicio passa a ter o endereço do elemento Novo que acabou de ser inserido
            }

            Tamanho++;                          // O elemento entrou na lista
        }

        // Função para inserir um elemento no final da lista
        public void InserirFinal(string Valor)
        {
            Elemento Novo = new Elemento();     // Alocação Dinâmica - Novo Elemento para a Lista

            Novo.Cor = Valor;                   // Insere o valor do elemento na lista

            if (Inicio == null)                 // A lista está vazia? Primeiro elemento...
            {
                Inicio = Novo;                  // O elemento inserido é o primeiro e o último. Guarda o endereço dele.
                Fim = Novo;

                Novo.Prox = null;               // O ponteiro para o próximo elemento passa a ser nulo
                Novo.Ant = null;                // O ponteior para o elemento anterior para a ser nulo
            }
            else                                // A lista já possui elementos?
            {
                Fim.Prox = Novo;                // O elemento que era o último da lista aponta para o elemento inserido
                Novo.Ant = Fim;                 // O ponteiro anterior do novo elemento aponta para o que já existia
                Novo.Prox = null;               // O ponteiro próximo do novo elemento aponta para nada, já que ele é o último
                Fim = Novo;                     // Atualiza o último: o elemento final passa a ser o novo elemento inserido
            }

            Tamanho++;                          // O elemento entrou na lista
        }

        //Função para mostrar todos os elementos da lista do Inicio ao Fim
        public void MostraListaINIFIM()
        {
            Console.Clear();            // Limpa a tela

            if (Inicio == null)         // Se não tem elemento na lista...
            {
                Console.WriteLine("Não há elementos na lista.");
            }
            else                        // Se a lista tem pelo menos um elemento
            {
                Console.WriteLine("Elementos da Lista: {0}\n", Tamanho);
                Console.WriteLine("Pontuação: " + Pontuacao + "\n");

                int cont = 1;
                Aux = Inicio;           // Pega o primeiro elemento

                while (Aux != null)     // Enquanto a lista tiver elementos que apontam para outro elemento da lista
                {
                    ConsoleUtils.ChangeConsoleColor(Aux.Cor);
                    Console.WriteLine("{0} {1,5}", cont, Aux.Cor);        // Mostra o elemento,
                    Aux = Aux.Prox;                             // aponta para o próximo elemento e volta
                    cont++;
                }
            }

            ConsoleUtils.ChangeConsoleColor();
        }

       
        //Função para retirar um elemento da lista
        public void RetiraElemento(string Valor)
        {
            Console.Clear();                        // Limpa a tela

            if (Inicio == null)                     // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");        // Mostra
                Console.ReadKey();
            }
            else                                    // A lista não está vazia
            {
                Aux = Inicio;                       // Pega o endereço do primeiro elemento

                int Achou = 0;                      // Variável para contar quantas vezes o elemento é encontrado na lista

                while (Aux != null)                 // Enquanto a lista tiver elementos que apontam para outro elemento da lista
                {
                    if (Aux.Cor == Valor)           // O número digitado foi encontrado na lista
                    {
                        Achou++;                    // Conta ocorrência

                        if (Aux == Inicio)                  // O número a ser removido é o primeiro da lista?
                        {
                            Inicio = Aux.Prox;              // O primeiro elemento foi removido e ele ganha o endereço do da frente

                            if (Inicio != null)             // Se o elemento existe
                            {
                                Inicio.Ant = null;          // O ponteiro anterior dele não aponta para nada, já que ele é o primeiro
                            }

                            Aux = Inicio;                   // Armazena o endereço dele para o próximo uso

                            Tamanho--;                      // Diminui o tamanho da lista
                        }
                        else if (Aux == Fim)                // O número a ser removido é o último da lista?
                        {
                            Fim = Fim.Ant;                  // Ele ganha o endereço do último
                            Fim.Prox = null;                // e o ponteiro próximo aponta para nada, já que ele é o último
                            Aux = null;                     // O Aux agora também aponta para nada

                            Tamanho--;                      // Diminui o tamanho da lista
                        }
                        else                                // O número a ser removido está no meio da lista?
                        {
                            // Um pouco mais confuso...

                            // O endereço próximo do elemento anterior ao elemento atual (que será removido)
                            // terá o endereço do elemento posterior ao elemento atual
                            Aux.Ant.Prox = Aux.Prox;

                            // O endereço anterior do elemento posterior ao elemento atual
                            // terá o endereço do elemento anterior ao elemento atual
                            Aux.Prox.Ant = Aux.Ant;

                            Aux = Aux.Prox;                 // Próximo elemento

                            Tamanho--;                      // Diminui o tamanho da lista
                        }
                    }
                    else                                    // reposiciona para o próximo elemento da lista
                    {
                        Aux = Aux.Prox;
                    }
                }                                           // e volta para nova pesquisa
            }
        }

        //Função para esvaziar toda a lista
        public void EsvaziarLista()
        {
            if (Inicio == null)                     // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");        // Mostra
                Console.ReadKey();
            }
            else                                    // A lista não está vazia
            {
                Inicio = null;                      // O Inicio da Lista não aponta para ninguém...
                Fim = null;
                Tamanho = 0;
            }
        }
        public void InserirPosicao(string Valor, int Posicao)
        {
            Elemento Novo = new Elemento();
            Lista ListAux = new Lista();

            Novo.Cor = Valor;

            if (Posicao == Tamanho + 1)             //Utiliza o TAD para inserir no final
            {
                this.InserirFinal(Valor);
            }
            else if (Posicao == 1)
            {
                this.InserirInicio(Valor);          //Utiliza o TAD para inserir no início
            }
            else if (Inicio == null)                //Se não houver elementos na lista, início e fim se tornam "Novo"
            {
                Inicio = Novo;
                Fim = Novo;

                Novo.Prox = null;
                Novo.Ant = null;
                Tamanho++;
            }                                       //Caso a posicão seja intermediária na lista.
            else
            {
                int cont = Tamanho + 1;
                Aux = Fim;                           //Percorre a lista original, do Fim até o Início
                while (Aux != null)                  
                {
                    if(cont == Posicao)             //Quando encontrar a posição que o usuário solicitou para a inserção, insere-se na lista auxiliar
                    {                                               //destá forma, a lista auxiliar terá um elemento a mais, do que a lista original, na posição desejada.
                        ListAux.InserirInicio(Novo.Cor);
                        Tamanho++;
                    }
                    ListAux.InserirInicio(Aux.Cor);
                    Aux = Aux.Ant;          
                    cont--;
                }
                this.EsvaziarLista();                          //Esvazia a lista original
                ListAux.Aux = ListAux.Fim;                     //Percorre a lista auxiliar de Fim até Início
                while (ListAux.Aux != null)                    //Preenche a lista original com todos os elementos da lista auxiliar, inclusive o inserido pelo usuário.
                {
                    this.InserirInicio(ListAux.Aux.Cor);
                    ListAux.Aux = ListAux.Aux.Ant;
                }
            }

        }

        public void VerificarPontos()               //Metodo para verificar se há 3 ou mais elementos em sequência
        {
            bool isTrue = false;
            
            isTrue = VerificaInicio();              //Utiliza de 3 técnicas diferentes, elementos em sequência a partir do Início
            if (isTrue == false)
            {
                isTrue = VerificaFim();             //Elementos em sequência a partir do Fim, e suas anteriores.
            }
            if (isTrue == false)
            {
                isTrue = VerificaIntermedios();     //Elementos em sequência no meio da lista.
            }
        }
        public bool VerificaInicio()
        {
            int cont = 1;
            Aux = Inicio;

            if (Aux.Prox != null)
            {
                if(Inicio.Prox == null)
                {
                    return false;
                }
                while (Aux.Prox != null && Aux.Cor == Aux.Prox.Cor)         //Verifica se 3 ou mais elementos a partir do Início são iguais.
                {
                    cont++;
                    Aux = Aux.Prox;
                }
                if (cont >= 3)                                             //O contador indica se tem 3 ou mais.
                {
                    for (int i = 0; i < cont; i++)                         //Percorre a quantidade de elementos, fazendo com que Início avance uma posicão
                    {                                                      //Removendo o antigo Início
                        Inicio = Inicio.Prox;                               
                        if (Inicio != null)
                        {
                            Inicio.Ant = null;
                        }
                        Tamanho--;                                        //Diminui o tamanho da lista.
                    }
                    if (cont == 3)                                        //Soma a pontuação
                    {
                        Pontuacao += 2;
                    }
                    else if (cont > 3)
                    {
                        Pontuacao += 3;
                    }
                    Aux = null;
                    return true;                                            //Retorna-se true, para não verificar os outros casos.
                }
            }
            Aux = null;
            return false;
        }
        public bool VerificaFim()
        {
            Aux = Fim;
            int cont = 1;
            if (Aux.Ant != null)
            {
                if (Fim.Ant == null)
                {
                    return false;
                }

                while (Aux.Ant != null && Aux.Cor == Aux.Ant.Cor)           //Verifica se 3 ou mais elementos anteriores ao Fim são iguais.
                {
                    cont++;
                    Aux = Aux.Ant;
                }
                if (cont >= 3)                                           //O contador indica se tem 3 ou mais.
                {
                    for (int i = 0; i < cont; i++)                      //Percorre a quantidade de elementos, fazendo com que Fim retroceda uma posicão
                    {                                                   //Removendo o antigo Fim
                        Fim = Fim.Ant;
                        if (Fim != null)
                        {
                            Fim.Prox = null;
                        }
                        Tamanho--;                                       //Diminui o tamanho da lista
                    }

                    if (cont == 3)                                      //Soma a pontuação
                    {
                        Pontuacao += 2;
                    }
                    else if (cont > 3)
                    {
                        Pontuacao += 3;
                    }
                    Aux = null;
                    return true;                                        //Retorna-se true, para não verificar os outros casos.
                }
            }
            Aux = null;
            return false;
        }
        public bool VerificaIntermedios()
        {
            Lista ListaAux = new Lista();                               //Lista auxiliar para receber apenas o elementos desejados.
            int cont = 1, cont2 = 1;
            int PosiInicial = 1;
            bool primeiraEntrada = false;

            Aux = Inicio;

            if (Aux.Prox == null)
            {
                return false;
            }

            while (Aux != null)
            {
                if(Aux.Prox != null)
                {
                    if(Aux.Cor != Aux.Prox.Cor && cont >= 3)             //Verifica se o próximo elemento é diferente do atual, caso seja true, verifica se o contador
                    {                                                    // de elementos é maior ou igual a 3, caso seja temos o tamanho da sequencia e podemos sair do loop
                        break;                                           
                    }
                    if(Aux.Cor == Aux.Prox.Cor)                         //Caso o proximo elemento tenha a mesma cor do atual.                   
                    {
                        if (primeiraEntrada == false)                   //Caso seja a primeira vez que isso ocorre, salva a posição inicial da sequência de elementos.
                        {
                            PosiInicial = cont2;
                            primeiraEntrada = true;                     //Torna a variável bool em true, para não altera a posicao inicial da sequência.
                        }
                        cont++;                                         //Incrementa a quantidade de elementos da mesma cor em sequência.
                    }
                    else
                    {
                        primeiraEntrada = false;                        //Torna a variável bool em false, para caso encontre-se uma sequencia de elementos de cor igual
                        cont = 1;                                       //salve a posição do primeiro elemento
                    }
                }
                Aux = Aux.Prox;
                cont2++;                                                //contador para contar cada posição da lista.
            }

            if (cont >= 3)                                              //Caso haja 3 ou mais elementos em sequência.
            {
                cont2 = Tamanho;
                Aux = Fim;
                while (Aux != null)
                {
                    if (cont2 < PosiInicial || cont2 > PosiInicial + (cont - 1))        //Verifica se a posicão atual é diferente dos elementos em sequência.
                    {
                        ListaAux.InserirInicio(Aux.Cor);                                //Caso seja insere o elemento na lista auxiliar.
                    }
                    Aux = Aux.Ant;
                    cont2--;
                }
                this.EsvaziarLista();                                   //Esvazia a lista original.
                ListaAux.Aux = ListaAux.Fim;
                while (ListaAux.Aux != null)                            //Passa todos os elementos da lista auxiliar para a lista original.
                {
                    this.InserirInicio(ListaAux.Aux.Cor);
                    ListaAux.Aux = ListaAux.Aux.Ant;
                }

                if (cont == 3)                                          //Calcula a pontuação
                {
                    Pontuacao += 2;
                }
                else if (cont > 3)
                {
                    Pontuacao += 3;
                }
                Aux = null;
                return true;                                            //Retorna true, para não se realizar as outras verificações.
            }
            Aux = null;
            return false;
        }
    }
}       

