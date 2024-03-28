using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categoria(Nome, ImagemUrl) " +
                "Values('Plao Fidelidade', 'planofidelidade.netfree')");
            mb.Sql("Insert into Categoria(Nome, ImagemUrl) " +
                "Values('Plano s/ Fidelidade', 'semfidelidade.netfree')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categoria");
        }
    }
}
