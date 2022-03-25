﻿using Kalantyr.Web;

namespace Kalantyr.Auth.Models
{
    public static class Errors
    {
        public static Error WrongPassword { get; } = new Error
        {
            Code = nameof(WrongPassword),
            Message = "Incorrect password"
        };

        public static Error LoginNotFound { get; } = new Error
        {
            Code = nameof(LoginNotFound),
            Message = "This login was not found"
        };

        public static Error TokenNotFound { get; } = new Error
        {
            Code = nameof(TokenNotFound),
            Message = "Token was not found"
        };

        public static Error WrongAppKey { get; } = new Error
        {
            Code = nameof(WrongAppKey),
            Message = "Incorrect application key"
        };

    }
}
