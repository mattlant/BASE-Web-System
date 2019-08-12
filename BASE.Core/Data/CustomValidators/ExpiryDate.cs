/* Author: Mattlant Consulting
 * Creator: Steve Arbour
 * 
 * This source file is part of the BASE Web Framework System
 * Date: 17 August 2007
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
    public class ExpiryDateValidator : IValidator
    {

        public ExpiryDateValidator(string expirydate)
        {
            this._expirydate = expirydate;
        }

        private string _expirydate;
        private bool _isValid = false;
        private string _errorMessage = "";

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

        public string ExpiryDate
        {
            set { this._expirydate = value; }
            get { return this._expirydate; }
        }

        /// <summary>
        /// This method is used to validate an ExpiryDate field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {
            DateTime outtmp;
            if (System.DateTime.TryParse(this._expirydate, out outtmp) == false)
            { // Possible invalid date.
                this._isValid = false;
                this._errorMessage = "The expiry date date/time is invalid.";
                return;
            }

            // Seem good.
            this._isValid = true;
            this._errorMessage = null;
            return;

        }
    }
}
