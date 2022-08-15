using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Footballers.Data.Models;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^([A-Za-z\t\f 0-9.-]+\s*)$")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }
        public int[] Footballers { get; set; }
    }
}

/*{
    "Name": "Brentford F.C.",
    "Nationality": "The United Kingdom",
    "Trophies": "5",
    "Footballers": [
    28,
    28,
    39,
    57
        ]
},*/
