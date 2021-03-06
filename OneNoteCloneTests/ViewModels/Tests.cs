﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNoteClone.Models;
using OneNoteClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNoteClone.ViewModels.Tests
{
    [TestClass()]
    public class NoteVMTests
    {
        [TestMethod()]
        public void CreateNewNoteTest()
        {
            Note test = new Note()
            {
                Title = "test",
                ContainerId = 0,
                UpdateDate = new DateTime(2019, 1, 1, 0, 00, 00),
                CreationDate = new DateTime(2019, 1, 1, 0, 00, 00)
            };
            Assert.AreEqual(test.Title, "test");
            Assert.AreEqual(test.ContainerId, 0);
            Assert.AreEqual(test.UpdateDate, new DateTime(2019, 1, 1, 0, 00, 00));
            Assert.AreEqual(test.CreationDate, new DateTime(2019, 1, 1, 0, 00, 00));
        }

        [TestMethod()]
        public void CreateNewContainerTest()
        {
            NoteContainer test = new NoteContainer()
            {
                Name = "Test"
            };
        }
    }
}