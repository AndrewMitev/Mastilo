﻿namespace Mastilo.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Image : BaseModel<int>
    {
        public byte[] ImageData { get; set; }

        public string ImageName { get; set; }

        public string ImageSrc { get; set; }

        public bool IsActive { get; set; }
    }
}
