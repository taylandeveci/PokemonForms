using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonForms.Models;

namespace PokemonForms.Models
{
    internal class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string OwnerName { get; set; }
        public string CategoryName { get; set; }
    }
}
