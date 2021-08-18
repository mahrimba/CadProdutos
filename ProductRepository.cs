using System;
using System.Collections.Generic;
using MySqlConnector;

namespace CadProdutos
{
    public class ProductRepository
    {
          private const string connectionAddress = "Database=admprodutos;Data Source=localhost;User Id=root; Password=pokerus3";
        public void Insert(Product item) {
            MySqlConnection connection = new MySqlConnection(connectionAddress);
            connection.Open();

            string sqlInsert =
                "INSERT INTO produto (nome, fabricante, preco, dataCadastro, disponivel)"+
                "VALUES ('"+ item.Nome +"', '"+ item.Fabricante +"', "+ item.Preco +", NOW(), 1)";
            MySqlCommand command = new MySqlCommand(sqlInsert, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<Product> Query(string nameFilter) {
            MySqlConnection connection = new MySqlConnection(connectionAddress);
            connection.Open();
              string sqlSelect = "SELECT * FROM produto";

              if(!String.IsNullOrEmpty(nameFilter))
                sqlSelect = sqlSelect + $" WHERE nome LIKE '{nameFilter}%'";

                sqlSelect = sqlSelect + " ORDER BY nome";

            MySqlCommand commandQuery = new MySqlCommand(sqlSelect, connection);
            MySqlDataReader result = commandQuery.ExecuteReader();

            List<Product> listaProdutos = new List<Product>();

            while(result.Read())
            {
            Product item = new Product();
            item.Id = result.GetInt32("Id");
            item.Nome = result.GetString("nome");
            item.Fabricante = result.GetString("fabricante");
            item.Preco = result.GetDecimal("preco");
            item.Disponivel = result.GetBoolean("disponivel");
            item.DataCadastro = result.GetDateTime("dataCadastro");

            listaProdutos.Add(item);
            }
            result.Close();
            connection.Close();

            return listaProdutos;
        }

        public void Update(Product p) {
            MySqlConnection connection = new MySqlConnection(connectionAddress);
            connection.Open();

            string sqlUpdate =
                "UPDATE produto " +
                " SET nome = '"+ p.Nome +"', fabricante = '"+ p.Fabricante + "', " +
                " preco = "+ p.Preco.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +", "+
                " disponivel = " + (p.Disponivel ? 1 : 0) +
                " WHERE id="+ p.Id ;

            MySqlCommand command = new MySqlCommand(sqlUpdate, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(Product p) {
            MySqlConnection connection = new MySqlConnection(connectionAddress);
            connection.Open();

            string sqlDelete = "DELETE FROM produto WHERE id = " + p.Id;

            MySqlCommand command = new MySqlCommand(sqlDelete, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}