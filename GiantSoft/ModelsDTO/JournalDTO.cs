﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.ModelsDTO
{
    /// <summary>
    /// When adding new Journal to database i dont need Id, ProductDTO, UserDTO fields
    /// </summary>
    public class CreateJournalDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Type { get; set; }
    }
    /// <summary>
    /// When updating record in Journals table we need same fields
    /// as in creation. This class inherits from CreateJournalDTO
    /// </summary>
    public class UpdateJournalDTO : CreateJournalDTO
    {

    }
    /// <summary>
    /// When getting records from Journals table i want Id, and if included get
    /// UserDTO, ProductDTO details
    /// be there if its included. This class inherits from CreateJournalDTO
    /// </summary>
    public class JournalDTO : CreateJournalDTO
    {
        public int Id { get; set; }
        public UserDTO ApiUser { get; set; }
        public ProductDTO Product { get; set; }
    }
}
