using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow
{
    [Binding]
    public sealed class StepDefinition1
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
       
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
        
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
        }


    }
}
