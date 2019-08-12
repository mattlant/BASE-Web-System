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
    public class EmailValidator : IValidator
    {

        public EmailValidator(string email)
        {
            this._email = email;
        }

        private string _email;
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

        public string Email
        {
            set { this._email = value; }
            get { return this._email; }
        }

        /// <summary>
        /// This method is used to validate an Email field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {

            if (this._email.Length <= 0)
            { // not Greater than 0.
                this._isValid = false;
                this._errorMessage = "The email is missing.";
                return;
            }

            if (this._email.Length < 5)
            { // not Greater or equal to 5 characters. An email even local need at least 5 character.. a@b.c
                this._isValid = false;
                this._errorMessage = "The email address is not valid.";
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(this._email, @"^[^@%*<> ]+@[^@%*<> ]{2,255}\.[^@%*<> ]{2,5}$") == false)
            { // not Contain only valid email address.
                this._isValid = false;
                this._errorMessage = "The email address is not valid.";
                return;
            }

            // Seem good.
            this._isValid = true;
            this._errorMessage = null;
            return;

        }
    }
}