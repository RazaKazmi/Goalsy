using System;
using System.Collections.Generic;
using Goalsy.Components;
using Goalsy.Objectives;
using Xunit;

namespace Goalsy.Tests
{
    public class TimedGoalTests
    {
        [Fact]
        public void Description_SetValid_ShouldWork()
        {

        }

        [Fact]
        public void Description_SetInvalid_ThrowsException()
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
        public void DetachComponent_NonAttachedComponentType_ReturnsArgumentOutOfRangeException()
        {
            // Arrange
            IObjective timedGoal = new TimedGoal("Get whiter teeth");
            IComponent priorityComponent = new Priority(Priority.PriorityLevel.Low);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => timedGoal.DetachComponent(priorityComponent));
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
            timedGoal.AddTask(new BasicTask("Brush teeth"));
            var allAttachedTasks = timedGoal.GetAllTasks();

            // Act
            //timedGoal.RemoveTask();

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
        public void RemoveTask_NoTasksExistToRemove_ReturnsException()
        {

        }
    }
}