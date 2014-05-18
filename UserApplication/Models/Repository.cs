using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class Repository
    {
        public IList<TEntity> FindBy(string key, string value)
        {
            IList<TEntity> result = new List<TEntity>();
            return result;
        }

        /// <summary>
        /// This method converts a list of database entries to its specific kind of entity
        /// using the EntityMappings configured for the repository
        /// </summary>
        /// <param name="list">The list of rows to be converted</param>
        /// <returns>The corresponding list of entities</returns>
        protected virtual IList<TEntity> ToEntity(IList<TRow> list)
        {
            IList<TEntity> entityList = new List<TEntity>();

            foreach (var item in list)
            {
                entityList.Add(Mapping.Create(item));
            }

            return entityList;
        }
    }
}