using MongoDB.Driver;
using WebIVBackend.Domain.Models;

namespace WebIVBackend.Domain.Repositories
{
    public class MenuRepository
    {
        private IMongoCollection<Menu> _menus;

        public MenuRepository()
        {
            
        }
    }
}