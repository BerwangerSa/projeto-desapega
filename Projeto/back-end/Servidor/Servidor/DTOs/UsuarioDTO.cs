﻿namespace Servidor.DTOs
{
    public class UsuarioDTO
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Nome { get; set; }

        public bool? IsAdmin { get; set; }

        public string? Email { get; set; }
    }
}
