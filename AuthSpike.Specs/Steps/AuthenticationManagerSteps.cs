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
            var authenticationManager = ScenarioContext.Current.Get<IAuthenticationManager>();
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

        [Then(@"I should receive a token")]
        public void ThenIShouldReceiveAToken()
        {
            var authenticationToken = ScenarioContext.Current.Get<AuthenticationToken>();
            Assert.IsNotNull(authenticationToken);
        }

        [Then(@"An exception should be thrown")]
        public void ThenAnExceptionShouldBeThrown()
        {
            var exception = ScenarioContext.Current.Get<Exception>();
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(AuthenticationException));
        }
    }
}