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
    public class UserBaseRequest
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
