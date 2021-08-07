namespace Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Bills = new HashSet<Bill>();
            MessageOnHolds = new HashSet<MessageOnHold>();
        }

        public int Id { get; set; }

        [StringLength(300)]
        public string FullName { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(300)]
        public string HouseNumber_StreetName { get; set; }

        [StringLength(300)]
        public string Ward { get; set; }

        [StringLength(300)]
        public string District { get; set; }

        [StringLength(300)]
        public string City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageOnHold> MessageOnHolds { get; set; }
    }
}
