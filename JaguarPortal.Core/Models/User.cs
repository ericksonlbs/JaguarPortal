using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Models
{
    [Table("users")]
    public class User
    {
        [Key]
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
        /// Password sha256
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Secret to access WebAPI
        /// </summary>
        public string ClientSecret { get; set; }
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
