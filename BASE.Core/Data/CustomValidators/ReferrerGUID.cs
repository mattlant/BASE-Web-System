/* Author: Mattlant Consulting
 * Creator: Steve Arbour
 * 
 * This source file is part of the BASE Web Framework System
 * Date: 18 August 2007
 * Copyright © 2007 BASE Web Systems Inc.
 * This software and its source code is protected by international copyright laws.
 * Any violation of this copyright will result in prosecution to the fullest
 * permissible extent of the law
 */

using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Text;

namespace BASE.Data.CustomValidators
{
    public class ReferrerGUIDValidator : IValidator
    {
        private string _ReferrerGUID;
        private bool _isValid = false;
        private string _errorMessage = "";

        public ReferrerGUIDValidator(string ReferrerGUID)
        {
            this._ReferrerGUID = ReferrerGUID;
        }

        bool IValidator.IsValid
        {
            set { this._isValid = value; }
            get { return this._isValid; }
        }

        string IValidator.ErrorMessage
        {
            set { this._errorMessage = value; }
            get { return this._errorMessage; }
        }

        public string ReferrerGUID
        {
            set { this._ReferrerGUID = value; }
            get { return this._ReferrerGUID; }
        }

        /// <summary>
        /// This method is used to validate an ReferrerGUID field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {
            try
            {
                // Attempt.
                Guid newguid = new Guid(this._ReferrerGUID);
                // Seem good.
                this._isValid = true;
                this._errorMessage = null;
                return;
            }
            catch (Exception ex)
            {
                this._isValid = false;
                this._errorMessage = "The Referrer Global Unique ID is invalid.";
            }
        }
    }
}
