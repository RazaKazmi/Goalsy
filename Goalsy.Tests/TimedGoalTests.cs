using System;
using System.Collections.Generic;
using Goalsy.Components;
using Goalsy.Objectives;
using Xunit;

namespace Goalsy.Tests
{
    public class TimedGoalTests
    {
        [Theory]
        [InlineData("Get whiter teeth")]
        [InlineData("s")]
        [InlineData("!@#$%^&*()-_=+,./?<>~`")]
        [InlineData("1234567890")]
        public void Description_SetValid_ShouldWork(string goalName)
        {
            // Arrange
            string expected = goalName;

            // Act
            IObjective exampleGoal = new TimedGoal(goalName);
            var actual = exampleGoal.Description;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Description_SetInvalid_ThrowsArugmentException()
        {

        }

        [Fact]
        public void AttachComponent_NonAttachedComponentType_ShouldWork()
        {
            // Arrange
            string goalName = "Get whiter teeth";
            IObjective timedGoal = new TimedGoal(goalName);
            IComponent priorityComponent = new Priority(Priority.PriorityLevel.Low);
            var attachedComponents = timedGoal.GetAllComponents();

            // Act
            timedGoal.AttachComponent(priorityComponent);

            // Assert
            Assert.True(attachedComponents.Count == 2);
            Assert.Equal(priorityComponent, timedGoal.GetComponentByType(ComponentType.Priority));
        }

        [Fact]
        public void AttachComponent_AlreadyAttachedComponentType_ShouldFail()
        {
            // Arrange
            string goalName = "Get whiter teeth";
            IObjective timedGoal = new TimedGoal(goalName);
            IComponent timerComponent = new CountdownTimer(0, 10, 0);
            var attachedComponents = timedGoal.GetAllComponents();

            // Act
            timedGoal.AttachComponent(timerComponent);

            // Assert
            Assert.True(attachedComponents.Count == 1);
            Assert.NotEqual(timerComponent, attachedComponents[0]);
        }

        [Fact]
        public void DetachComponent_AnyAttachedComponentType_ShouldWork()
        {
            // Arrange
            IObjective timedGoal = new TimedGoal("Get whiter teeth");
            IComponent priorityComponent = new Priority(Priority.PriorityLevel.Low);
            timedGoal.AttachComponent(priorityComponent);
            var attachedComponents = timedGoal.GetAllComponents();

            // Act
            timedGoal.DetachComponent(priorityComponent);

            // Assert
            Assert.True(attachedComponents.Count == 1);
        }

        [Fact]
        public void DetachComponent_NonAttachedComponentType_ReturnsInvalidOperationException()
        {
            // Arrange
            IObjective timedGoal = new TimedGoal("Get whiter teeth");
            IComponent priorityComponent = new Priority(Priority.PriorityLevel.Low);

            // Assert
            Assert.Throws<InvalidOperationException>(() => timedGoal.DetachComponent(priorityComponent));
        }

        [Fact]
        public void DetachComponent_MandatoryComponents_ShouldFail()
        {
            // Arrange
            IObjective timedGoal = new TimedGoal("Get whiter teeth");
            var attachedComponents = timedGoal.GetAllComponents();

            // Act
            timedGoal.DetachComponent(timedGoal.GetComponentByType(ComponentType.Timer));

            // Assert
            Assert.True(attachedComponents.Count == 1);

        }

        [Fact]
        public void AddTask_BasicTask_ShouldWork()
        {
            // Arrange
            Goal timedGoal = new TimedGoal("Get whiter teeth");
            var allAttachedTasks = timedGoal.GetAllTasks();

            // Act
            timedGoal.AddTask(new BasicTask("Brush teeth"));

            // Assert
            Assert.True(allAttachedTasks.Count == 1);
        }

        [Fact]
        public void RemoveTask_AnyAddedTask_ShouldWork()
        {
            // Arrange
            Goal timedGoal = new TimedGoal("Get whiter teeth");
            Task exampleTask = new BasicTask("Brush teeth");
            timedGoal.AddTask(exampleTask);
            timedGoal.AddTask(new BasicTask("Floss"));
            var allAttachedTasks = timedGoal.GetAllTasks();

            // Act
            timedGoal.RemoveTask(exampleTask);

            // Assert
            Assert.True(allAttachedTasks.Count == 1);

        }

        [Fact]
        public void RemoveTask_NoTasksExistToRemove_ReturnsInvalidOperationException()
        {
            // Arrange 
            Goal timedGoal = new TimedGoal("Get whiter teeth");
            Task exampleTask = new BasicTask("Brush teeth");
            timedGoal.AddTask(new BasicTask("Floss"));
            var allAttachedTasks = timedGoal.GetAllTasks();

            // Assert
            Assert.Throws<InvalidOperationException>(() => timedGoal.RemoveTask(exampleTask));

        }

        [Fact]
        public void RemoveAllTasks_ClearsAllTasks_ShouldWork()
        {
            // Arrange
            Goal timedGoal = new TimedGoal("Get whiter teeth");
            timedGoal.AddTask(new BasicTask("Brush teeth"));
            timedGoal.AddTask(new BasicTask("Brush teeth"));
            timedGoal.AddTask(new BasicTask("Brush teeth"));
            var allAttachedTasks = timedGoal.GetAllTasks();

            // Act
            timedGoal.RemoveAllTasks();

            // Assert
            Assert.True(allAttachedTasks.Count == 0);

        }

        [Fact]
        public void GetComponentByType_AttachedComponent_ShouldWork()
        {
            // Arrange 
            Goal timedGoal = new TimedGoal("Get whiter teeth");
            IComponent expectedPriorityComponent = new Priority(Priority.PriorityLevel.Low);
            timedGoal.AttachComponent(expectedPriorityComponent);

            // Act
            var actualComponent = timedGoal.GetComponentByType(ComponentType.Priority);

            // Assert
            Assert.Equal(expectedPriorityComponent, actualComponent);
        }

        [Fact]
        public void GetComponentByType_NonAttachedComponent_ReturnsInvalidOperationException()
        {
            // Arrange
            Goal timedGoal = new TimedGoal("Get whiter teeth");

            // Assert
            Assert.Throws<InvalidOperationException>(() => timedGoal.GetComponentByType(ComponentType.Priority));
        }
    }
}