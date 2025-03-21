﻿namespace KnightsOfTheFallenCrown.Models.Knights
{
    public class KnightImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid? KnightID { get; set; }
    }
}
