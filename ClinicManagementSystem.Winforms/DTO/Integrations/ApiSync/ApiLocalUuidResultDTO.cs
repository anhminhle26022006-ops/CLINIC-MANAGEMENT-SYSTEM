using System;

namespace DTO
{
    public class ApiLocalUuidResultDTO
    {
        public Guid Uuid { get; set; }
        public bool Inserted { get; set; }
        public bool Generated { get; set; }
    }
}
