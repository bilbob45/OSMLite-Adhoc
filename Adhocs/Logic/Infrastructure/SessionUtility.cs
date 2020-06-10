using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.ComponentModel.DataAnnotations;

namespace Adhocs.Logic.Infrastructure
{
    public class SessionUtility : Page
    {
        public String Key { get; set; }
        public String Value { get; set; }

        /// <summary>
        /// Initialize the session management utility
        /// </summary>
        /// <param name="key">session key</param>
        /// <param name="value">session value</param>
        public SessionUtility(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key) && string.IsNullOrWhiteSpace(value))
                throw new NullReferenceException("Session key and value are required");
            else
            {
                this.Key = key;
                this.Value = value;
            }
        }

        public SessionUtility()
        {

        }

        /// <summary>
        /// Save an value to session using a specified key
        /// </summary>
        /// <param name="key">session key</param>
        /// <param name="value">session value</param>
        public void Save(string key, string value)
        {
            this.Key = key;
            this.Value = value;
            if (Session[key].ToString() == null || Session[key].ToString() == key)
                throw new Exception("Session key already exists");
            else
                Session[key] = value;
        }

        public void Save()
        {
            if (string.IsNullOrWhiteSpace(this.Key) && string.IsNullOrWhiteSpace(this.Value))
                throw new NullReferenceException("Session key and value are required");
            else
                Save(this.Key, this.Value);

        }

        /// <summary>
        /// Get a specified value from session using the specified key
        /// </summary>
        /// <param name="key">session key</param>
        /// <returns></returns>
        public String Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new NullReferenceException("Session key is required");
            else
            {
                if (Session[key] == null)
                    return String.Empty;
                else
                    return Session[key].ToString();
            }
        }
    }
}