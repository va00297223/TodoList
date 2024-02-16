using TodoList.Models;

namespace TodoList.Tests
{
    [TestClass]
    public class TodoListLogic
    {
        [TestMethod]
        public void TodoItem_Initialization_Success()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 1,
                DueDate = DateTime.Now.AddDays(6),
                Description = "abc"
            };

            // Act

            // Assert
            Assert.AreEqual(1, todoItem.Id);
            Assert.AreEqual(DateTime.Now.AddDays(6).Date, todoItem.DueDate.Date);
            Assert.IsNull(todoItem.CompletedDate);
            Assert.AreEqual("abc", todoItem.Description);
        }



        [TestMethod]
        public void TodoItem_CompleteTask_Success()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 2,
                DueDate = DateTime.Now.AddDays(3),
                Description = "xyz"
            };

            // Act
            todoItem.CompletedDate = DateTime.Now;

            // Assert
            Assert.IsNotNull(todoItem.CompletedDate);
            Assert.AreEqual(DateTime.Now.Date, todoItem.CompletedDate.Value.Date);
        }

        [TestMethod]
        public void TodoItem_CompletedDate_NullByDefault()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 3,
                DueDate = DateTime.Now.AddDays(5),
                Description = "Attend meeting"
            };

            // Act

            // Assert
            Assert.IsNull(todoItem.CompletedDate);
        }

        [TestMethod]
        public void TodoItem_UpdateDescription_Success()
        {
            // Arrange
            TodoItem todoItem = new TodoItem
            {
                Id = 4,
                DueDate = DateTime.Now.AddDays(2),
                Description = "dicussion forum"
            };

            // Act
            todoItem.Description = "discussion quiz";

            // Assert
            Assert.AreEqual("discussion quiz", todoItem.Description);
        }
    }
}