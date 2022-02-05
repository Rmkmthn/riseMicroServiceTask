using System;
using System.Collections.Generic;

namespace Rise.Shared
{
    public class ReturnObject<T> 
    {
        private T _resultobject;
        private Dictionary<string, string> _errors;

        private bool _IsValid;
        private bool _IsDeleted;
        public bool ConfirmRequired { get; set; }
        public string InfoMessage { get; set; }

        public T ResultObject
        {
            get { return _resultobject; }
            set { _resultobject = value; }
        }

        public ReturnObject()
        {
            _IsValid = true;
            _IsDeleted = false;
        }

        public bool IsValid
        {
            get
            {
                return _IsValid;
            }
        }
        public void AddError(string strKey, string strError)
        {

            if (_errors == null)
                _errors = new Dictionary<string, string>();
            if (!_errors.ContainsKey(strKey))
                _errors.Add(strKey, strError);
            _IsValid = false;

        }

        public bool IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                _IsDeleted = value;
            }
        }
        public Dictionary<string, string> Errors
        {
            get
            {
                return _errors;
            }
        }

    }
}
