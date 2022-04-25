using Domain.Core;
using System;
using Xunit;

namespace Entites.Test
{
    public class TaskModelTest
    {
        [Fact]
        public void ShouldUpdateTitle()
        {
            string newTitle = "nowy";
            var task = new TaskModel(null,"test",null);
            task.UpdateTitle(newTitle);
            Assert.Equal(newTitle, task.Title);
        }
        [Fact]
        public void ShouldThrowArgumentExceptionIfTitleIsNullOrEmpty()
        {
            string newTitleEmpty = "";
            string? newTitleNull = null;
            var task = new TaskModel(null, "test", null);
            Assert.Throws<ArgumentException>(()=>task.UpdateTitle(newTitleEmpty));
            Assert.Throws<ArgumentException>(() => task.UpdateTitle(newTitleNull));
        }

        [Fact]
        public void ShouldUpdateescription()
        {
            string newDescription = "nowy1";
            var task = new TaskModel(null, "test", null);
            task.UpdateDescription(newDescription);
            Assert.Equal(newDescription, task.Description);
        }
        [Fact]
        public void ShouldThrowArgumentExceptionIfDescriptionIsNullOrEmpty()
        {
            string emptyDescription = "";
            string? nullDescription = null;
            var task = new TaskModel(null, "test", null);
            Assert.Throws<ArgumentException>(() => { task.UpdateDescription(emptyDescription); });
            Assert.Throws<ArgumentException>(() => task.UpdateDescription(nullDescription));
        }

        [Fact]
        public void ShoulUpateCompleteStatus()
        {
            int status = 55;
            var task = new TaskModel(null, "test", null);
            task.UpdateCompleteStatus(status);
            Assert.Equal(status, task.CompleteStatus);
        }
        [Fact]
        public void ShouldThrowInvalidOperationExceptionIfStatusWillBeBiggerThan100andSmallerThan0()
        {
            int statusOver = 101;
            int statusDown = -1;
            var task = new TaskModel(null, "test", null);
            Assert.Throws<InvalidOperationException>(()=>task.UpdateCompleteStatus(statusOver));
            Assert.Throws<InvalidOperationException>(()=>task.UpdateCompleteStatus(statusDown));
        }

        [Fact]
        public void ShouldUpdateExpirtionDate()
        {
            DateTimeOffset? date = DateTimeOffset.Now.AddDays(1);
            var task = new TaskModel(null, "test", null);
            task.UpdateExpirationDate(date);
            Assert.Equal(date, task.ExpirationDate);
        }
        [Fact]
        public void ShouldThrowArgumentExceptionIfExpirationWillBeSmallerThanCreatedDate()
        {
            DateTimeOffset? date = DateTimeOffset.Now.AddDays(-1);
            var task = new TaskModel(null, "test", null);
            Assert.Throws<ArgumentException>(() => task.UpdateExpirationDate(date));


        }



    }
}