using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanches.Web.Migrations {
    public partial class PopulaDb : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Lanche Natural','Lanche feito com ingredientes integrais e naturais')");
            migrationBuilder.Sql ("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Lanche Normal','Lanche feito com ingredientes normais')");

            migrationBuilder.Sql ("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoLonga,EmEstoque,ImagemThumbnailUrl,ImgUrl,IsFavorite,Nome,Preco) VALUES((SELECT TOP 1 CategoriaId FROM Categorias WHERE CategoriaNome = 'Lanche Normal'),'Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',1, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql ("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoLonga,EmEstoque,ImagemThumbnailUrl,ImgUrl,IsFavorite,Nome,Preco) VALUES((SELECT TOP 1 CategoriaId FROM Categorias WHERE CategoriaNome = 'Lanche Normal'),'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0,'Misto Quente', 8.00)");
            migrationBuilder.Sql ("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoLonga,EmEstoque,ImagemThumbnailUrl,ImgUrl,IsFavorite,Nome,Preco) VALUES((SELECT TOP 1 CategoriaId FROM Categorias WHERE CategoriaNome = 'Lanche Natural'),'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',1,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0,'Cheese Burger', 11.00)");
            migrationBuilder.Sql ("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoLonga,EmEstoque,ImagemThumbnailUrl,ImgUrl,IsFavorite,Nome,Preco) VALUES((SELECT TOP 1 CategoriaId FROM Categorias WHERE CategoriaNome = 'Lanche Natural'),'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',1,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',0,'Lanche Natural Peito Peru', 15.00)");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("DELETE FROM Categorias");
            migrationBuilder.Sql ("DELETE FROM Lanches");
        }
    }
}