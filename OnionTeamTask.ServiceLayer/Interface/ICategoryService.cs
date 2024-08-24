using OnionTeamTask.DomainLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTeamTask.ServiceLayer.Interface
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
    }
}
