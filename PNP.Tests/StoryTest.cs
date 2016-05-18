using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PNP.Models;

namespace PNP.Tests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class StoryTest
    {
        [Fact]
        public void GetStoryDescriptionTest()
        {
            //Arrange
            var story = new Story();
            story.Content = "Great story";
            //Act
            var result = story.Content;

            //Assert
            Assert.Equal("Great story", result);
        }
    }
}
