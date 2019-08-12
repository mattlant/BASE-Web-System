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

using BASE.Logging;
using BASE.Data;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.LLDAL.DatabaseSpecific;

namespace BASE.Data.CustomValidators
{
    public class UsernameValidator : IValidator {

        public UsernameValidator(string username)
        {
            this._username = username;
        }

        private string _username;
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

        public string Username
        {
            set { this._username = value; }
            get { return this._username; }
        }

        /// <summary>
        /// This method is used to validate an Username field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {

            if (this._username.Length <= 0)
            { // not Greater than 0.
                this._isValid = false;
                this._errorMessage = "The username is missing.";
                return;
            }

            if (this._username.Length < 5)
            { // not Greater or equal to 5 characters.
                this._isValid = false;
                this._errorMessage = "The username contain less than five (5) characters.";
                return;
            }
            
            if (this._username.Length > 250)
            { // not Smaller or equal to 250 charaters.
                this._isValid = false;
                this._errorMessage = "The username contain more than two hundred and fifty (250) characters.";
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(this._username, @"^[a-zA-Z0-9]{5,250}$") == false)
            { // Contain not only 'a-z', 'A-Z', '0-9' characters.
                this._isValid = false;
                this._errorMessage = "The username contain invalid characters.";
                return;
            }

            EntityCollection<UserEntity> col = BASE.Data.Helpers.UserDataHelper.SelectByUsername(this._username);
            if (col.Count > 0)
            { // Username already exist
                this._isValid = false;
                this._errorMessage = "The username is already in use.";
                return;
            }

            // Seem good.
            this._isValid = true;
            this._errorMessage = null;
            return;
            
        }
    }
}
