using FluentAssertions;
using Microsoft.AspNetCore.Routing;
using TodoWebAPI.Entities;

namespace TodoWebAPI.Tests.Entities
{
    public class TodoItemTests
    {
        [Fact]
        public void TitleShouldNotBeEmpty()
        {
            Assert.Throws<ArgumentException>(() => new TodoItem(""));
        }

        [Fact]
        public void TitleMaximumLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TodoItem(new string('a', 101)));
        }

        [Fact]
        public void TodoCreatedShouldBeNow()
        {
            var todoItem = new TodoItem("some title");
            Assert.NotEqual(todoItem.Created, new DateTime());
        }

        [Fact]
        public void TodoItemDefaultValues()
        {
            var todoItem = new TodoItem("some title");
            todoItem.Done.Should().BeFalse();
            todoItem.Title.Should().Be("some title");
            todoItem.Description.Should().BeEmpty();
            todoItem.Created.Should().NotBe(new DateTime());
        }
    }
}
