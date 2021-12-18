using System;
using Goalsy.Objectives;
using Goalsy.Components;
using Xunit;

namespace Goalsy.Tests
{
    public class BasicTaskTests
    {
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
        public void DetachComponent_NonAttachedComponentType_ShouldFail()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
