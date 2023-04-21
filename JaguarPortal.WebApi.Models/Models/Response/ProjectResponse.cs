using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.WebApi.Models.Response
{
    /// <summary>
    /// Project
    /// </summary>
    public class ProjectResponse
    {
        /// <summary>
        /// Project identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Created date project
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// User perform create project
        /// </summary>
        public string CreatedUser { get; set; }
        /// <summary>
        /// Last Date Modified project
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// User perform last modify
        /// </summary>
        public string LastModifiedUser { get; set; }
    }
}
