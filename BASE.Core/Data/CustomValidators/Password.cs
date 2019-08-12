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
    public class PasswordValidator : IValidator
    {

        public PasswordValidator(string password)
        {
            this._password = password;
        }

        private string _password;
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

        public string Password
        {
            set { this._password = value; }
            get { return this._password; }
        }

        /// <summary>
        /// This method is used to validate an Password field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {

            if (this._password.Length <= 0)
            { // not Greater than 0.
                this._isValid = false;
                this._errorMessage = "The password is missing.";
                return;
            }

            if (this._password.Length < 6)
            { // not Greater or equal to 6 characters.
                this._isValid = false;
                this._errorMessage = "The password contain less than five (6) characters.";
                return;
            }

            if (this._password.Length > 50)
            { // not Smaller or equal to 50 charaters.
                this._isValid = false;
                this._errorMessage = "The password contain more than fifty (50) characters.";
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(this._password, @"^[a-zA-Z0-9]{6,50}$") == false)
            { // not Contain only 'a-z', 'A-Z', '0-9' characters.
                this._isValid = false;
                this._errorMessage = "The password contain invalid characters.";
                return;
            }

            // Seem good.
            this._isValid = true;
            this._errorMessage = null;
            return;

        }
    }
}
