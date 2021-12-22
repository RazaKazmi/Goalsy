using System;
using Goalsy.Objectives;
using Goalsy.Components;
using Xunit;

namespace Goalsy.Tests
{
    public class BasicTaskTests
    {
        [Fact]
        public void ParentObjective_AnyAttachedTask_ReturnsCorrectGoal()
        {
            // Arrange
            Goal goal = new TimedGoal("Get whiter teeth");
            Task task = new BasicTask("Floss");

            // Act
            goal.AddTask(task);

            // Assert
            Assert.Equal(goal,task.ParentObjective);
        }

       [Fact]
       public void AttachComponent_NonAttachedComponentType_ShouldWork()
        {
            // Arrange
            Task task = new BasicTask("Floss");
            var tasksComponents = task.GetAllComponents();

            // Act
            task.AttachComponent(new Priority(Priority.PriorityLevel.Low));

            // Assert
            Assert.True(tasksComponents.Count == 1);
        }

        [Fact]
        public void AttachComponent_AlreadyAttachedComponentType_ShouldFail()
        {
            // Arange
            Task task = new BasicTask("Floss");
            var tasksComponents = task.GetAllComponents();

            // Act
            task.AttachComponent(new Priority(Priority.PriorityLevel.Low));
            task.AttachComponent(new Priority(Priority.PriorityLevel.Low));

            // Assert
            Assert.True(tasksComponents.Count == 1);
        }

        [Fact]
        public void DetachComponent_AttachedComponentType_ShouldWork()
        {
            // Arrange
            Task task = new BasicTask("Floss");
            var tasksComponents = task.GetAllComponents();
            task.AttachComponent(new Priority(Priority.PriorityLevel.Low));
            task.AttachComponent(new CountdownTimer(0,10,0));
            var componentToDetach = task.GetComponentByType(ComponentType.Priority);

            // Act
            task.DetachComponent(componentToDetach);

            // Assert
            Assert.True(tasksComponents.Count == 1);

        }

        [Fact]
        public void DetachComponent_NonAttachedComponentType_ReturnsInvalidOperationException()
        {
            // Arrange
            IObjective task = new BasicTask("Floss");
            IComponent priorityComponent = new Priority(Priority.PriorityLevel.Low);

            // Assert
            Assert.Throws<InvalidOperationException>(() => task.DetachComponent(priorityComponent));
        }
    }
}
