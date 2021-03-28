using Castle.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCollections.Tests
{
    [TestClass]
    public class EnumerableKnownReceiveTests
    {
        private readonly ILogger _logger;

        public EnumerableKnownReceiveTests()
        {
            _logger = Substitute.For<ILogger>();
        }

        public IEnumerable<Person> GetFriendsFromDatabase()
        {
            var database = new[] { "Felix", "Tom", "Fatou", "Amine", "Jackito" };
            _logger.Debug("Resolving Enumerable");
            foreach (var name in database)
            {
                yield return new Person(name);
            }
        }

        public IEnumerable<Person> AddDeferredOperations(IEnumerable<Person> friends)
        {
            return friends
                .Where(friend => friend.Name.StartsWith("F"))
                .OrderBy(friend => friend.Name);
        }

        [TestMethod]
        public void Receive_Deferred_AddDeferred_NoEnumeration()
        {
            var allFriends = GetFriendsFromDatabase();
            var someFriendsUnresolved = AddDeferredOperations(allFriends);
            CheckEnumerations(requiredNumberOfCalls: 0);
            var resolvedFriends = someFriendsUnresolved.ToArray();
            CheckEnumerations(requiredNumberOfCalls: 1);

            Check.That(resolvedFriends.Extracting("Name")).ContainsExactly("Fatou", "Felix");
            CheckEnumerations(requiredNumberOfCalls: 1);
        }

        [TestMethod]
        public int AddImmediateOperation(IEnumerable<Person> friends)
        {
            return friends.Count();
        }

        [TestMethod]
        public void Receive_Deferred_AddImmediate_Enumerates()
        {
            var allFriends = GetFriendsFromDatabase();
            var numberOfFriends = AddImmediateOperation(allFriends);
            CheckEnumerations(requiredNumberOfCalls: 1);
            
            Check.That(numberOfFriends).IsEqualTo(5);
            CheckEnumerations(requiredNumberOfCalls: 1);
        }


        private void DoSomethingForEach(IEnumerable<Person> friends)
        {
            foreach (var friend in friends)
            {
                _logger.Debug("Applying operation");
            }
        }


        [TestMethod]
        public void Receive_Deferred_Foreach_Enumerates()
        {
            const int numberOfFriends = 5;
            var allFriends = GetFriendsFromDatabase();
            CheckEnumerations(requiredNumberOfCalls: 0);
            DoSomethingForEach(allFriends);
            CheckEnumerations(requiredNumberOfCalls: 1);

            CheckOperations(numberOfFriends);
        }

        private ILookup<char, Person> GroupByInitial(IEnumerable<Person> friends)
        {
            return friends.ToLookup(friend => friend.Name[0]);
        }

        [TestMethod]
        public void Receive_Deferred_Transform_Enumerates()
        {
            var allFriends = GetFriendsFromDatabase();
            CheckEnumerations(requiredNumberOfCalls: 0);
            var byInitial = GroupByInitial(allFriends);
            CheckEnumerations(requiredNumberOfCalls: 1);
            Check.That(byInitial.Extracting("Key")).ContainsExactly('F', 'T', 'A', 'J');
        }

        private void CheckOperations(int requiredNumberOfOperations)
        {
            _logger.Received(requiredNumberOfOperations).Debug("Applying operation");
        }

        private void CheckEnumerations(int requiredNumberOfCalls)
        {
            _logger.Received(requiredNumberOfCalls).Debug("Resolving Enumerable");
        }
    }
}