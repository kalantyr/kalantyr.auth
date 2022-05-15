﻿using System.ComponentModel.DataAnnotations;

namespace Kalantyr.Auth.DbRepositories.Entities
{
    public class User
    {
        public uint Id { get; set; }

        [MaxLength(64)]
        public string Login { get; set; }
    }
}
