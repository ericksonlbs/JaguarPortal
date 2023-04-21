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
    public class UserUpdateRequest : UserBaseRequest
    {
        /// <summary>
        /// Enabled user authenticate on WebAPI
        /// </summary>
        [Required]
        public bool EnabledAPI { get; set; }
        /// <summary>
        /// Enabled user authenticate on Web Portal
        /// </summary>
        [Required]
        public bool EnabledPortal { get; set; }
    }
}
