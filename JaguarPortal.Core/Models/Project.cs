using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Models
{
    /// <summary>
    /// Project
    /// </summary>
    [Table("projects")]
    public class Project
    {
        /// <summary>
        /// Project identifier
        /// </summary>
        [Key]
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
        public string? LastModifiedUser { get; set; }
    }
}
