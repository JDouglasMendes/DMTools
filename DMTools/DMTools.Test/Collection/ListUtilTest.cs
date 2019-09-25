using System;
using System.Collections.Generic;
using System.Text;
using DMTools.Collection;
using Xunit;

namespace DMTools.Test.Collection
{
    public class ListUtilTest
    {
        [Fact]
        public void CopyTest()
        {
            var list = new List<int>{1,2,3,4,5,6,7,8,9,10};
            var newList = list.Copy();
            Assert.True(newList.Count == list.Count);                        
        }

        [Fact]
        public void CopyReferenceTypeTest()
        {
            var listPerson = new List<Person>()
            {
                new Person() {Name = "Name"},
                new Person() {Name = "Name 2"},
                new Person() {Name = "Name 3"},
            };
            var newList = listPerson.CopyReferenceType<Person>();
            Assert.True(newList.Count == listPerson.Count);
        }

        [Fact]
        public void CopyCloneableTypeTest()
        {
            var listPerson = new List<Person>()
            {
                new Person() {Name = "Name"},
                new Person() {Name = "Name 2"},
                new Person() {Name = "Name 3"},
            };
            var newList = listPerson.CopyCloneableType();
            Assert.True(newList.Count == listPerson.Count);
        }
    }
}
