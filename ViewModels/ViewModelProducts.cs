using AnywayStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.ViewModels
{
    public class ViewModelProducts
    {
        public ClassEntityProducts EntityProducts { get; set; }
        public int[] CategoriesId { get; set; }
        public int[] SizesId { get; set; }
    }
}