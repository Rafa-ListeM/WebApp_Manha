using WebApp_Manha.Entidades;

namespace WebApp_Manha.Models

{
    public class NovoProdutoModelsView : Produtos
    {
        public NovoProdutoModelsView()
        {
            ListaCategorias = new List<Categoria>();
        }

        public List<Categoria>ListaCategorias { get; set; }
    }
}
