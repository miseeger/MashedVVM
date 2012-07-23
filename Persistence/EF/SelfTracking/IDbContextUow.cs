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

using System;
using System.Data.Entity;
using MashedVVM.Base.Contracts;

namespace MashedVVM.Persistence.EF.Selftracking
{
    public interface IDbContextUow
    {
        void Save(Action finishAction);
        void ResetSession();
        void ReLoadFromDb<T>(DbSet<T> dbSet) where T : IDataObject;
    }
}