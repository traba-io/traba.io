using System;

namespace Domain.Abstract
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool IsNew { get => Id == 0; }
    }
}