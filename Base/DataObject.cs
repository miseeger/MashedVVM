/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * This code is licensed under the Creative Commons Attribution 3.0 License  *
 * (http://creativecommons.org/licenses/by/3.0/de/).                         *
 * ************************************************************************* */

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MashedVVM.Base.Contracts;
using MashedVVM.Base.Enum;

namespace MashedVVM.Base
{

    public abstract class DataObject: NotifyableObject, IDataObject // , IEditableObject, IDataErrorInfo
    {
        
        // ----- ctor ---------------------------------------------------------

        protected DataObject()
            : this(DataObjectStatus.Original)
        {

        }


        protected DataObject(DataObjectStatus objectStatus)
        {
            ObjectStatus = objectStatus;
            ObjectStatusIgnoringProperties = new List<string>() { "IsBusy", "IsDirty", "HasErrors" };
            PropertyChanged += (o, e) =>
            {
                if (ObjectStatus == DataObjectStatus.Original
                    && (!e.PropertyName.Equals(ExtractPropertyName(() => ObjectStatus))
                        || ObjectStatusIgnoringProperties.Contains(e.PropertyName)))
                {
                    ObjectStatus = DataObjectStatus.Modified;
                }
            };
            
        }


        // ----- implementation of IDataObject --------------------------------

        public IEnumerable<string> ObjectStatusIgnoringProperties { get; set; }
        

        private DataObjectStatus _objectStatus = DataObjectStatus.Original;
        public DataObjectStatus ObjectStatus
        {
            get { return _objectStatus; }
            set
            {
                if (_objectStatus != value)
                {
                    _objectStatus = value;
                    RaisePropertyChanged(() => ObjectStatus);
                }
            }
        }


        public virtual void Validate()
        {
            
        }
        
     
        // ----- implementaion of IEditableObject -----------------------------

        private Dictionary<string, object> _memento;

        public void BeginEdit()
        {
            _memento = new Dictionary<string, object>();
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                // ignore R/O properties!
                if (pi.CanWrite)
                {
                    _memento.Add(pi.Name, pi.GetValue(this, null));    
                }
            }
        }


        public void EndEdit()
        {
            _memento = null;
        }


        public void CancelEdit()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(this, _memento[pi.Name], null);
                }
            }
            EndEdit();
        }


        // ----- implementaion of IDataErrorInfo ------------------------------

        public virtual string Error
        {
            get { return string.Empty; }
        }


        public virtual string this[string columnName]
        {
            get { return string.Empty; }
        }

    }

}
