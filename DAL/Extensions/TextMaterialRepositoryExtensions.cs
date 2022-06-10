using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class TextMaterialRepositoryExtensions
    {
        public static IQueryable<TextMaterial> SearchByTitle(this IQueryable<TextMaterial> textMaterials, string searchTitle)
        {
            if (string.IsNullOrEmpty(searchTitle))
            {
                return textMaterials;
            }

            var lowerCaseTerm = searchTitle.Trim().ToLower();
            return textMaterials.Where(tm => tm.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<TextMaterial> SearchByCategory(this IQueryable<TextMaterial> textMaterials, string searchCategory)
        {
            if (string.IsNullOrEmpty(searchCategory))
            {
                return textMaterials;
            }

            var lowerCaseTerm = searchCategory.Trim().ToLower();
            return textMaterials.Where(tm => tm.TextMaterialCategory.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}
