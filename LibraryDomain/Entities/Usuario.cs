using Newtonsoft.Json;
using System;

namespace LibraryDomain.Entities
{
    public class Usuario 
    {
        public int UsuarioId { get; set; }
        public int SexoId { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public bool Ativo { get; set; }


        [JsonIgnore]
        public virtual Sexo Sexo { get; set; }

    }
}
