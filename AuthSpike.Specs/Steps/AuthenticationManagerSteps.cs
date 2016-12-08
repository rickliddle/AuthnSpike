using System;
using TechTalk.SpecFlow;
using AuthnSpike.Lib;
using TechTalk.SpecFlow.Assist;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Authentication;

namespace AuthnSpike.Specs.Steps
{
    [Binding]
    public class AuthenticationManagerSteps
    {
        [Given(@"I have an instance of the authentication manager")]
        public void GivenIHaveAnInstanceOfTheAuthenticationManager()
        {
            ScenarioContext.Current.Set<IAuthenticationManager>(new AuthenticationManager());
        }

        [When(@"I call authenticate with these credentials")]
        public void WhenICallAuthenticateWithTheseCredentials(Table table)
        {
            var authenticationCredentials = table.CreateInstance<AuthenticationCredentials>();
            IAuthenticationManager authenticationManager;
            if (ScenarioContext.Current.TryGetValue<IAuthenticationManager>(out authenticationManager))
            {
                try
                {
                    var authenticationToken = authenticationManager.Authenticate(authenticationCredentials);
                    ScenarioContext.Current.Set<AuthenticationToken>(authenticationToken);
                }
                catch (Exception ex)
                {
                    ScenarioContext.Current.Set<Exception>(ex);
                }
            }
            else
            {
                Assert.Fail("Failed getting authenticationManager");
            }
        }

        [Then(@"I should receive a token")]
        public void ThenIShouldReceiveAToken()
        {
            AuthenticationToken authenticationToken;
            ScenarioContext.Current.TryGetValue<AuthenticationToken>(out authenticationToken);
            Assert.IsNotNull(authenticationToken);            
        }

        [Then(@"I should not receive a token")]
        public void ThenIShouldNotReceiveAToken()
        {
            AuthenticationToken authenticationToken;
            ScenarioContext.Current.TryGetValue<AuthenticationToken>(out authenticationToken);
            Assert.IsNull(authenticationToken);

        }

        [Then(@"An exception should be thrown")]
        public void ThenAnExceptionShouldBeThrown()
        {
            Exception exception;
            ScenarioContext.Current.TryGetValue<Exception>(out exception);
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AuthenticationException));
        }

        [Then(@"an exception should not be thrown")]
        public void ThenAnExceptionShouldNotBeThrown()
        {
            Exception exception;
            ScenarioContext.Current.TryGetValue<Exception>(out exception);
            Assert.IsNull(exception);
        }
    }
}