using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.UI.ViewModel
{
    public abstract class ViewModelBase : IDataErrorInfo
    {
        protected readonly List<string> validatablePropertyCollection = new List<string>();

        protected virtual bool IsValid
        {
            get
            {
                foreach (string property in this.validatablePropertyCollection)
                {
                    if (!string.IsNullOrEmpty(this.GetValidationError(property)))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        protected abstract string GetValidationError(string property);

        string IDataErrorInfo.this[string property]
        {
            get
            {
                string error = this.GetValidationError(property);
                return error;
            }
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }
    }
}
