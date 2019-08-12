/* Author: Mattlant Consulting
 * Creator: Steve Arbour
 * 
 * This source file is part of the BASE Web Framework System
 * Date: 20 August 2007
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
    public class SMTPServerAddressValidator : IValidator
    {

        public SMTPServerAddressValidator(string InternetAddress)
        {
            this._InternetAddress = InternetAddress;
        }

        private string _InternetAddress;
        private bool _isValid = false;
        private string _addressType = "";
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

        public string InternetAddress
        {
            set { this._InternetAddress = value; }
            get { return this._InternetAddress; }
        }

        public string AddressType
        {
            set { this._addressType = value; }
            get { return this._addressType; }
        }

        /// <summary>
        /// This method is used to validate an InternetAddress field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {

            #region 1) Check for length.
            if (this._InternetAddress.Length <= 2)
            { // not Greater than 2.
                this._addressType = "Unknown";
                this._isValid = false;
                this._errorMessage = "The SMTP Server address is not valid.";
                return;
            }

            if (this._InternetAddress.Length > 250)
            { // not smaller than 250.
                this._addressType = "Unknown";
                this._isValid = false;
                this._errorMessage = "The SMTP Server address is not valid.";
                return;
            }
            #endregion

            #region 2) Checking for a valid IP address by regexp
            if (System.Text.RegularExpressions.Regex.IsMatch(this._InternetAddress, @"^\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b$") == false)
            { // The data is an IP Address and it is NOT valid by regexp. Therefore we need to check for a valid domain name.

                if (System.Text.RegularExpressions.Regex.IsMatch(this._InternetAddress, @"^([a-zA-Z0-9]{2,})(-([a-zA-Z0-9]+))*$") == false) 
                { // The data is not a valid domain name neither...
                    this._addressType = "Unknown";
                    this._isValid = false;
                    this._errorMessage = "The SMTP Server address is not valid.";
                    return;
                } else {
                    this._addressType = "Domain name";
                    this._isValid = true;
                    this._errorMessage = null;
                    return;
                }
            } else {
                // The data is an IP Address and it is valid by regexp.
                this._addressType = "IP Address";
                this._isValid = true;
                this._errorMessage = null;
                return;
            }
            #endregion

        }
    }
}