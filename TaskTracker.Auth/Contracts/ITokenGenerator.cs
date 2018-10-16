using DotNetAuth.OAuth1a;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Model.Auth;

namespace TaskTracker.Auth.Contracts
{
   public interface ITokenGenerator
    {
        Auth.Models.ValidateClientResult ValidateClient(AuthTokenParameters authTokenParameters, OAuth10aStateManager oAuth10AStateManager);
        bool ValidateUserActionAndGenerateUserSession(AuthTokenParameters authTokenParameters, OAuth10aStateManager oAuth10AStateManager);
    }
}
