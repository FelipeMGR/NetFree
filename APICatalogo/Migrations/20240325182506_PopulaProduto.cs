using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome, Preco, Velocidade, Descricao, CategoriaId)" +
                "Values('Plano 200mb fidelidade', '89.90', 200, 'Plano de velocidade de 200 megas, com fidelidade de 12 meses', 1)");
            mb.Sql("Insert into Produtos(Nome, Preco, Velocidade, Descricao, CategoriaId)" +
                "Values('Plano 400 fidelidade', '99.90', 400, 'Plano de velocidade de 400 megas, com fidelidade de 12 meses', 1)");
            mb.Sql("Insert into Produtos(Nome, Preco, Velocidade, Descricao, CategoriaId)" +
                "Values('Plano 600mb fidelidade', '129.90', 600, 'Plano de velocidade de 600 megas, com fidelidade de 12 meses. Plano com promoção de R$99,90 por 06 meses!', 1)");
            mb.Sql("Insert into Produtos(Nome, Preco, Velocidade, Descricao, CategoriaId)" +
                "Values('Plano Ilimitado fidelidade', '139.90', 1000, 'Plano de velocidade de até 1GB, com fidelidade de 12 meses', 1)");

            mb.Sql("Insert into Produtos(Nome,Preco,Velocidade,Descricao,CategoriaId)" +
               "Values('Plano 100mb sem fidelidade','89.90', 100,'Plano de velocidade de 100 megas.',2)");
            mb.Sql("Insert into Produtos(Nome, Preco,Velocidade, Descricao, CategoriaId)" +
               "Values('Plano 300mb sem fidelidade','99.90',300,'Plano de velocidade de 300 megas.',2)");
            mb.Sql("Insert into Produtos(Nome, Preco, Velocidade, Descricao, CategoriaId)" +
               "Values('Plano 400mb sem fidelidade', '109.90', 400, 'Plano de velocidade de 400 megas.',2)");
            mb.Sql("Insert into Produtos(Nome, Preco, Velocidade, Descricao, CategoriaId)" +
               "Values('Plano 500mb sem fidelidade', '139.90', 500, 'Plano de velocidade de 500 megas.', 2)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produto");
        }
    }
}
