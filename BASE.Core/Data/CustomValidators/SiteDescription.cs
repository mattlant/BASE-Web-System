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

using BASE.Logging;
using BASE.Data;
using BASE.Data.LLDAL.EntityClasses;
using BASE.Data.LLDAL.HelperClasses;
using BASE.Data.LLDAL.DatabaseSpecific;

namespace BASE.Data.CustomValidators
{
    public class SiteDescriptionValidator : IValidator
    {

        public SiteDescriptionValidator(string SiteDescription)
        {
            this._SiteDescription = SiteDescription;
        }

        private string _SiteDescription;
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

        public string SiteDescription
        {
            set { this._SiteDescription = value; }
            get { return this._SiteDescription; }
        }

        /// <summary>
        /// This method is used to validate an SiteDescription field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {
            // Site Description cant be null, minimum 2 characters and maximum of 1000 characters.

            if (this._SiteDescription.Length <= 0)
            { // not greater or equal to 0 charaters.
                this._isValid = false;
                this._errorMessage = "The Site Description is missing.";
                return;
            }

            if (this._SiteDescription.Length < 2)
            { // not greater than 1 charaters.
                this._isValid = false;
                this._errorMessage = "The Site Description must have at least two (2) characters or more.";
                return;
            }

            if (this._SiteDescription.Length > 1000)
            { // not Smaller or equal to 1000 charaters.
                this._isValid = false;
                this._errorMessage = "The Site Description contain more than one thousand (1000) characters.";
                return;
            }

            // Seem good.
            this._isValid = true;
            this._errorMessage = null;
            return;

        }
    }
}
