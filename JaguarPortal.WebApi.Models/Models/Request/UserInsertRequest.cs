using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.WebApi.Models.Request
{
    /// <summary>
    /// Project
    /// </summary>
    public class UserInsertRequest : UserBaseRequest
    {
        /// <summary>
        /// Login
        /// </summary>
        [Required]
        public string Login { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
