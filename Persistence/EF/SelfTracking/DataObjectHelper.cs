/* ************************************************************************* *
 * MashedVVM.Persistence                                                     *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

using MashedVVM.Base;
using MashedVVM.Base.Contracts;
using MashedVVM.Base.Enum;

namespace MashedVVM.Persistence.EF.Selftracking
{
    
    public static class DataObjectHelper
    {


        public static void ApplyObjectStatuss<T>(this ICollection<T> entities, DbContext dbContext) where T : DataObject
        {
            foreach (var e in entities.ToArray())
            {
                ApplyObjectStatus(e, dbContext);
            }
        }


        public static void ApplyObjectStatus<T>(this T entity, DbContext dbContext) where T : DataObject
        {
            switch (entity.ObjectStatus)
            {
                case DataObjectStatus.Added:
                    dbContext.Entry<T>(entity).State = System.Data.EntityState.Added;
                    break;
                case DataObjectStatus.Modified:
                    dbContext.Entry<T>(entity).State = System.Data.EntityState.Modified;
                    break;
                case DataObjectStatus.Deleted:
                    dbContext.Entry<T>(entity).State = System.Data.EntityState.Deleted;
                    break;
            }
        }

        
        public static IQueryable<T> ResetObjectStatuss<T>(this IQueryable<T> entities) where T : IDataObject
        {
            var deleted = new List<T>();

            foreach (var e in entities)
            {
                if (e.ObjectStatus != DataObjectStatus.Deleted)
                {
                    ResetObjectStatus(e);
                }
            }

            return entities;
        }


        public static ObservableCollection<T> ResetObjectStatuss<T>(this ObservableCollection<T> entities) where T : IDataObject
        {
            var deleted = new List<T>();

            foreach (var e in entities)
            {
                if (e.ObjectStatus != DataObjectStatus.Deleted)
                {
                    ResetObjectStatus(e);
                }
            }

            return entities;
        }


        public static void ResetObjectStatus<T>(this T entity) where T : IDataObject
        {
            entity.ObjectStatus = DataObjectStatus.Original;
        }


        public static void LoadAndResetObjectStatuss<T>(this IQueryable<T> source) where T: IDataObject
        {
            source.Load();
            source.ResetObjectStatuss();
        }

    }
}