using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Grocery.Service.Client.UAT
{
    [Binding]
    public class ConnectionTest : TestBase
    {
        [Given("User try to connect the server")]
        public void Connect()
        {
            try
            {
                this.frontServiceClient.ConnectAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }

        [When("it will be successful")]
        [When("User try to disconnect the server")]
        public void Disconnect()
        {
            try
            {
                this.frontServiceClient.DisconnectAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }

        [Then("it will be successful")]
        public void ResultRight()
        {
            Assert.IsTrue(this.ex == null);
        }

        [Then("it will be failed")]
        public void ResultWrong()
        {
            Assert.IsFalse(this.ex == null);
        }
    }
}
