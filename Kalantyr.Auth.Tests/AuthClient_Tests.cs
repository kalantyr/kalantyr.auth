﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Kalantyr.Auth.Client;
using Kalantyr.Auth.Models;
using Moq;
using NUnit.Framework;

namespace Kalantyr.Auth.Tests
{
    [Explicit]
    public class AuthClient_Tests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactory = new();

        [Test]
        public async Task AuthClient_Test()
        {
            var cancellationToken = CancellationToken.None;

            _httpClientFactory
                .Setup(hcf => hcf.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:44374")
                });

            var authClient = new AuthClient(_httpClientFactory.Object, "asjdFbh67");
            var loginResult = await authClient.LoginByPasswordAsync(new LoginPasswordDto { Login = "admin1", Password = "qwerty1" }, cancellationToken);
            Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.Result.Value));

            var getUserIdResult = await authClient.GetUserIdAsync(loginResult.Result.Value, cancellationToken);
            Assert.IsNull(getUserIdResult.Error);

            var logoutResult = await authClient.LogoutAsync(loginResult.Result.Value, cancellationToken);
            Assert.IsTrue(logoutResult.Result);
        }
    }
}
