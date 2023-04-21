using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.WebApi.Models.Response
{
    /// <summary>
    /// Project
    /// </summary>
    public class UserResponse
    {
        public long Id { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Id do acess WebAPI
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Enabled user authenticate on WebAPI
        /// </summary>
        public bool EnabledAPI { get; set; }
        /// <summary>
        /// Enabled user authenticate on Web Portal
        /// </summary>
        public bool EnabledPortal { get; set; }
    }
}
