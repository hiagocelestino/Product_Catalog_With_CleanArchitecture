using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
             mb.Sql(@"
                INSERT INTO ""Products""
                    (""Name"", ""Description"", ""Price"", ""Stock"", ""Image"", ""CategoryId"")
                VALUES
                    ('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno.jpg', 1),
                    ('Estojo escolar', 'Estojo escolar cinza', 5.65, 70, 'estojo1.jpg', 1),
                    ('Borracha escolar', 'Borracha branca pequena', 3.00, 80, 'borracha1.jpg', 1),
                    ('Calculadora escolar', 'Calculadora simples', 10.99, 15, 'calculadora1.jpg', 2)
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
