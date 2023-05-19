﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    /// <summary>
    /// Cross-reference table mapping products and product photos.
    /// </summary>
    [Table("ProductProductPhoto", Schema = "Production")]
    public partial class ProductProductPhoto
    {
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// </summary>
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        /// <summary>
        /// Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.
        /// </summary>
        [Key]
        [Column("ProductPhotoID")]
        public int ProductPhotoId { get; set; }
        /// <summary>
        /// 0 = Photo is not the principal image. 1 = Photo is the principal image.
        /// </summary>
        public bool Primary { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductProductPhoto")]
        public virtual Product Product { get; set; }
        [ForeignKey("ProductPhotoId")]
        [InverseProperty("ProductProductPhoto")]
        public virtual ProductPhoto ProductPhoto { get; set; }
    }
}