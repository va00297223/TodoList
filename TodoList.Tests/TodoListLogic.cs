using TodoList.Models;

namespace TodoList.Tests
{
    [TestClass]
    public class TodoListLogic
    {
        [TestMethod]
        public void Todo_Intialize()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 1,
                DueDate = DateTime.Now.AddDays(6),
                Description = "Hello Reader..!"
            };

            // Act

            // Assert
            Assert.AreEqual(1, todoItem.Id);
            Assert.AreEqual(DateTime.Now.AddDays(6).Date, todoItem.DueDate.Date);
            Assert.IsNull(todoItem.CompletedDate);
            Assert.AreEqual("abc", todoItem.Description);
        }

        [TestMethod]
        public void TodoCompleteTask()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 2,
                DueDate = DateTime.Now.AddDays(4),
                Description = "Good Morning..!"
            };

            // Act
            todoItem.CompletedDate = DateTime.Now;

            // Assert
            Assert.IsNotNull(todoItem.CompletedDate);
            Assert.AreEqual(DateTime.Now.Date, todoItem.CompletedDate.Value.Date);
        }

        [TestMethod]
        public void Todo_CompletedDateNullBy()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 3,
                DueDate = DateTime.Now.AddDays(5),
                Description = "Join Zoom..!"
            };

            Assert.IsNull(todoItem.CompletedDate);
        }

        [TestMethod]
        public void TodoUpdateTask()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 4,
                DueDate = DateTime.Now.AddDays(3),
                Description = "dicussion forum"
            };

            // Act
            todoItem.Description = "Unit Tests";

            // Assert
            Assert.AreEqual("Unit Tests", todoItem.Description);
        }
    }
}