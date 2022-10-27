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
        private Hashtable _inputContestants = new Hashtable();

        [SetUp]
        public void Setup() 
        {
            _repository = new SuperheroCombatRepository();
            
        }

        
        [Test]
        public void Test_GetContestants_Superman_FromAPI() 
        {
            _inputContestants.Add("Superman", "");

            _contestant = new Contestant("Superman", "Clark Kent", 85, 100, 94, 100, 100, 100);
            List<Contestant> expectedOutput = new List<Contestant>();
            expectedOutput.Add(_contestant);

            var result = _repository.GetContestants(_inputContestants);
            result.Should().BeEquivalentTo(expectedOutput);
           
        }
    }
}
