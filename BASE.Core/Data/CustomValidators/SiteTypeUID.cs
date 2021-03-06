/* Author: Mattlant Consulting
 * Creator: Steve Arbour
 * 
 * This source file is part of the BASE Web Framework System
 * Date: 18 August 2007
 * Copyright � 2007 BASE Web Systems Inc.
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
    public class SiteTypeUIDValidator : IValidator
    {

        public SiteTypeUIDValidator(string SiteTypeUID)
        {
            this._SiteTypeUID = Convert.ToInt32(SiteTypeUID);
        }

        private int _SiteTypeUID;
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

        public string SiteTypeUID
        {
            set { this._SiteTypeUID = Convert.ToInt32(value); }
            get { return Convert.ToString(this._SiteTypeUID); }
        }

        /// <summary>
        /// This method is used to validate an SiteTypeUID field.
        /// </summary>
        /// <param name="valdata">The data to validate</param>
        /// <returns>True if the data respect the rules, false if not.</returns>
        void IValidator.Validate()
        {

            if (this._SiteTypeUID <= 0)
            { // Greater or equal to 1 characters.
                this._isValid = false;
                this._errorMessage = "The Site Type Unique ID is invalid.";
                return;
            }

            if (this._SiteTypeUID > int.MaxValue)
            { // Smaller or equal to the maximum int value.
                this._isValid = false;
                this._errorMessage = "The Site Type Unique ID is invalid.";
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(this._SiteTypeUID), @"^[0-9]+$") == false)
            { // Containt only '0-9' characters.
                this._isValid = false;
                this._errorMessage = "The Site Type Unique ID is invalid.";
                return;
            }

            // Seem good.
            this._isValid = true;
            this._errorMessage = null;
            return;

        }
    }
}
