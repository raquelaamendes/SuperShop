using SuperShop.Data.Entities;
using SuperShop.Models;
using System;

namespace SuperShop.Helpers
{
    public interface IConverterHelper
    {
        Product ToProduct(ProductViewModel model, string path, bool isNew);

        ProductViewModel ToProductViewModel(Product product);
    }
}
