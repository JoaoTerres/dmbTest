using dbm.Api.Models;
using dbm.Api.Repositories.Interfaces;

namespace dbm.Api.Services;


    public class ProdutoService
    {
        private readonly IProductRepository _produtoRepository;

        public ProdutoService(IProductRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Product> GetProdutoAsync(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProdutosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task AddProdutoAsync(Product produto)
        {
            await _produtoRepository.AddAsync(produto);
        }

        public async Task UpdateProdutoAsync(Product produto)
        {
            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }
    }

