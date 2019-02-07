using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestMoqExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace MSTestMoqExample.Tests
{
    [TestClass()]
    public class PersonHelperTests
    {
        private PersonHelper helper;

        [TestInitialize]
        public void Startup()
        {
            helper = new PersonHelper();
        }

        [TestMethod()]
        public void getCurrentYearTest()
        {
            Assert.AreEqual(helper.getCurrentYear(), 2019);
        }

        [TestMethod()]
        public void calculateAgeTest()
        {
            // create m mock object that can act as a person object
            var mockPerson = new Mock<IPerson>();
            // setup a a property on the mock object
            mockPerson.SetupGet(p => p.BirthYear).Returns(1975);

            Assert.IsTrue(helper.calculateAge(mockPerson.Object) == 44);
        }

        [TestMethod()]
        public void isMaleTest()
        {
            var mockPerson = new Mock<IPerson>();
            mockPerson.Setup(p => p.GetGender()).Returns(Person.Gender.male);

            Assert.IsTrue(helper.isMale(mockPerson.Object));
        }

    }
}