using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibraryDomain.Entities
{
    public class Sexo 
    {
        public int SexoId { get; set; }
        public string Descricao { get; set; }


        [JsonIgnore]
        public ICollection<Usuario> Usuario { get; set; }
    }
}
