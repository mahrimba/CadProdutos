using System;
using System.Collections.Generic;

namespace CadProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastrando produto...");
            Console.Write("Digite 'C' para Cadastrar, 'L' para Listar, 'A' para realizar uma atualização ou 'D' para deletar um produto:");
            string command = Console.ReadLine();
            string nameFilter;
            ProductRepository pr = new ProductRepository();
            Product item = new Product();
            Product prod;

            switch(command.ToUpper())
            {
                case "C":
                Console.Write("Digite o nome do produto:");
                item.Nome = Console.ReadLine();

                Console.Write("Digite o nome do fabricante:");
                item.Fabricante = Console.ReadLine();

                Console.Write("Digite o valor do produto:");
                item.Preco = Convert.ToDecimal(Console.ReadLine());

                pr.Insert(item);
                break;

                case "L":
                Console.WriteLine("Digite o filtro de pesquisa, se desejar:");
                nameFilter = Console.ReadLine();
                List<Product> lista = pr.Query(nameFilter);
                foreach(Product p in lista)
                {
                    Console.WriteLine(p.ToString());
                }
                break;

                case "A":
                prod = new Product();
                Console.Write("Digite o Id do produto a ser atualizado:");
                prod.Id = int.Parse(Console.ReadLine());

                Console.Write("Digite o novo nome do produto:");
                prod.Nome = Console.ReadLine();

                Console.Write("Digite o novo fabricante do produto:");
                prod.Fabricante = Console.ReadLine();

                Console.Write("Digite o novo preço do produto:");
                prod.Preco = Decimal.Parse(Console.ReadLine());

                Console.Write("O produto está disponível? [s/n]");
                prod.Disponivel = (Console.ReadLine().ToLower() == "s");

                pr.Update(prod);
                break;

                case "D":
                prod = new Product();
                Console.Write("Digite o Id do produto a ser deletado:");
                prod.Id = int.Parse(Console.ReadLine());

                pr.Delete(prod);
                break;

                default:
                Console.WriteLine("Comando Inválido.");
                break;
            }
        }
    }
}
