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
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using MashedVVM.Base;
using MashedVVM.Base.Contracts;
using MashedVVM.Base.Enum;

 namespace MashedVVM.Persistence.EF.Selftracking
{
    public class DbContextUow<TDbContext> : IDisposable, IDbContextUow where TDbContext : DbContext, new()
    {

        public TDbContext Session { get; private set; }
        public TDbContext S { get { return Session; } }
        public TDbContext this[int index] { get { return Session; } }


        public DbContextUow()
        {
            Session = new TDbContext();
        }


        private void DisposeSession()
        {
            if (Session != null)
            {
                if (Session.Database.Connection.State != ConnectionState.Closed)
                {
                    Session.Database.Connection.Close();
                }
                Session.Dispose();
            }
            GC.SuppressFinalize(true);
        }


        public void Save(Action finishAction)
        {
            bool saveFailed = false;

            do
            {
                saveFailed = false;
                try
                {
                    Session.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }

            } while (saveFailed);

            if (finishAction != null)
            {
                finishAction();
            }
        }


        public void ResetSession()
        {
            DisposeSession();
            Session = new TDbContext();
        }


        public void ReLoadFromDb<T>(DbSet<T> dbSet) where T : DataObject
        {
            foreach (var entity in dbSet.Local)
            {
                var entry = Session.Entry(entity);
                entry.CurrentValues.SetValues(entry.GetDatabaseValues());
                entry.Property("ObjectStatus").CurrentValue = DataObjectStatus.Original;
            }
        }


        public void Dispose()
        {
            DisposeSession();
        }
    }

}
