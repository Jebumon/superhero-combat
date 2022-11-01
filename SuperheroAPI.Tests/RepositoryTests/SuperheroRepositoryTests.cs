using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperheroAPI.Repository;
using SuperheroAPI.Models;
using System.Collections;

namespace SuperheroAPI.Tests.RepositoryTests
{
    internal class SuperheroRepositoryTests
    {
        private SuperheroCombatRepository _repository;
        private Contestant _contestant;

        [SetUp]
        public void Setup()
        {
            _repository = new SuperheroCombatRepository();

        }


        [Test]
        public void Test_GetContestants_Superman_FromAPI()
        {
            Hashtable _inputContestants = new Hashtable();
            _inputContestants.Add("Superman", "");

            _contestant = new Contestant("Superman", "Clark Kent", 85, 100, 94, 100, 100, 100);
            List<Contestant> expectedOutput = new List<Contestant>();
            expectedOutput.Add(_contestant);

            var result = _repository.GetContestants(_inputContestants);
            result.Should().BeEquivalentTo(expectedOutput);

        }

        [Test]
        public void Test_GetContestants_SpiderMan_FromAPI_without_RealName()
        {
            Hashtable _inputContestants = new Hashtable();
            _inputContestants.Add("Spider-Man", "");

            _contestant = new Contestant("Spider-Man", "Peter Parker", 85, 75, 90, 74, 67, 55);
            List<Contestant> expectedOutput = new List<Contestant>();
            expectedOutput.Add(_contestant);

            var result = _repository.GetContestants(_inputContestants);
            result.Should().BeEquivalentTo(expectedOutput);

        }

        [Test]
        public void Test_GetContestants_Batman_FromAPI_with_RealName()
        {
            Hashtable _inputContestants = new Hashtable();
            _inputContestants.Add("Batman", "Bruce Wayne");

            List<Contestant> expectedOutput = new List<Contestant>();
            _contestant = new Contestant("Batman", "Bruce Wayne", 100, 50, 100, 47, 27, 26);
            expectedOutput.Add(_contestant);
            

            var result = _repository.GetContestants(_inputContestants);
            result.Should().BeEquivalentTo(expectedOutput);

        }

        [Test]
        public void Test_GetContestants_SpiderMan_and_Batman_FromAPI_with_RealName()
        {
            Hashtable _inputContestants = new Hashtable();
            _inputContestants.Add("Spider-Man", "Peter Parker");
            _inputContestants.Add("Batman", "Bruce Wayne");

            List<Contestant> expectedOutput = new List<Contestant>();
            _contestant = new Contestant("Batman", "Bruce Wayne", 100, 50, 100, 47, 27, 26);
            expectedOutput.Add(_contestant);
            _contestant = new Contestant("Spider-Man", "Peter Parker", 85, 75, 90, 74, 67, 55);
            expectedOutput.Add(_contestant);

            var result = _repository.GetContestants(_inputContestants);
            result.Should().BeEquivalentTo(expectedOutput);

        }

        [Test]
        public void Test_GetContestants_SpiderMan_Batman_FromAPI_without_RealName_ExceptionThrowing()
        {
            Hashtable _inputContestants = new Hashtable();
            _inputContestants.Add("Spider-Man", "");
            _inputContestants.Add("Batman", "");

            var ex = Assert.Throws<AggregateException>(() => _repository.GetContestants(_inputContestants));
            Assert.That(ex.Message, Is.EqualTo($"One or more errors occurred. (There is more than one 'Batman'!! Please enter their Real name)"));
        }

        [Test]
        public void Test_GetAllNamed_Batman_FromAPI()
        {
            List<Contestant> expectedOutput = new List<Contestant>();
            _contestant = new Contestant("Batman", "Terry McGinnis", 90, 55, 81, 63, 29, 40);
            expectedOutput.Add(_contestant);
            _contestant = new Contestant("Batman", "Bruce Wayne", 100, 50, 100, 47, 27, 26);
            expectedOutput.Add(_contestant);

            var result = _repository.GetAllNamed("Batman");
            result.Should().BeEquivalentTo(expectedOutput);
        }

        [Test]
        public void Test_GetAllNamed_SpiderMan_FromAPI()
        {
            List<Contestant> expectedOutput = new List<Contestant>();
            _contestant = new Contestant("Spider-Man", "Peter Parker", 85, 75, 90, 74, 67, 55);
            expectedOutput.Add(_contestant);

            var result = _repository.GetAllNamed("Spider-Man");
            result.Should().BeEquivalentTo(expectedOutput);
        }

        /*[Test]
        public void Test_GetAllNamed_Ammo_FromAPI()
        {
            var ex = Assert.Throws<AggregateException>(() => _repository.GetAllNamed("Ammo"));
            Assert.That(ex.Message, Is.EqualTo($"One or more errors occurred. ($"{ tempName} / { tempRealName}Powerstat zero error")"));
        }*/
    }
}
