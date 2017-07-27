using System;

namespace TelegramAlbionFarmAlert.Db.Model
{
    public class Island
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Island()
        {
            
        }
        
        public Island(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}