﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Windows.Forms.IntegrationTests.Common;
using Xunit;
using Xunit.Abstractions;

namespace System.Windows.Forms.IntegrationTests
{
    public partial class WinformsControlsTest
    {
        private readonly ITestOutputHelper _output;
        private const string ProjectName = "WinformsControlsTest";
        private readonly string _exePath;

        public WinformsControlsTest(ITestOutputHelper output)
        {
            _output = output;
            _exePath = TestHelpers.GetExePath(ProjectName);
        }

        [WinFormsFact]
        public void Control_can_be_collected_by_GC()
        {
            for (int i = 0; i < 100; i++)
            {
                CreateCollectableControl();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(0, GCCollectionMode.Forced);
        }

        private void CreateCollectableControl()
        {
            var form = new Form();
            form.Show();

            var control = new CollectableControl { Logger = _output };
            control.Location = new Drawing.Point(8, 8);
            control.Size = new Drawing.Size(100, 100);
            control.Visible = true;
            form.Controls.Add(control);

            //form.Controls.Clear();
        }

        private class CollectableControl : Control
        {
            public ITestOutputHelper Logger { get; set; }

            public void EnsureHandleCreated() => CreateHandle();

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    throw new ApplicationException("Diposed by user");
                }
                else
                {
                    Logger.WriteLine("Collected by GC!");
                    //throw new ApplicationException("Collected by GC!");
                    base.Dispose(disposing);
                }
            }
        }

        [Fact]
        public void WinformsControlsTest_OpenAndClose()
        {
            Process process = TestHelpers.StartProcess(_exePath);

            Assert.NotNull(process);
            Assert.NotNull(Process.GetProcessById(process.Id));
            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_ButtonsTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);

            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.Buttons);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_CalendarTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.Calendar);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_MultipleControlsTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.MultipleControls);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_ComboBoxesTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.ComboBoxes);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_DateTimePickerTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.DateTimePickerButton);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        // FolderBrower

        [Fact]
        public void WinformsControlsTest_ThreadExceptionDialogTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.ThreadExceptionDialog);
            TestHelpers.PressEnterOnProcess(process);

            TestHelpers.PressTabsOnProcess(process, 2);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_DataGridViewTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.DataGridView);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_TreeViewAndImageListTest()
        {
            var process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, 2);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_ContentAlignmentTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.ContentAlignment);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_MenusTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.Menus);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_PanelsTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.Panels);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_SplitterTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.Splitter);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_MDIParentTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.MdiParent);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_PropertyGridTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.PropertyGrid);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        // [Fact]
        // Commenting this out until this is fixed
        // public void WinformsControlsTest_ListViewTest()
        // {
        //     var process = TestHelpers.StartProcess(GetPathToTestFromBin());
        //     TestHelpers.PressTabsOnProcess(process, 12);
        //     TestHelpers.PressEnterOnProcess(process);

        //     Assert.False(process.HasExited);

        //     process.Kill();
        //     process.WaitForExit();

        //     Assert.True(process.HasExited);
        // }

        [Fact]
        public void WinformsControlsTest_FontNameEditorTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.FontNameEditor);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_PropertyGrid_CollectionEditorTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.PropertyGrid);
            TestHelpers.PressEnterOnProcess(process);

            TestHelpers.PressTabOnProcess(process);
            TestHelpers.PressRightOnProcess(process); // once
            TestHelpers.PressRightOnProcess(process); // twice
            TestHelpers.PressTabsOnProcess(process, 2);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void WinformsControlsTest_RichTextBoxesTest()
        {
            Process process = TestHelpers.StartProcess(_exePath);
            TestHelpers.PressTabsOnProcess(process, MainFormControlsTabOrder.RichTextBoxes);
            TestHelpers.PressEnterOnProcess(process);

            Assert.False(process.HasExited);

            process.Kill();
            process.WaitForExit();

            Assert.True(process.HasExited);
        }

        [Fact]
        public void DataBindings_remove_should_unsubscribe_INotifyPropertyChanged_PropertyChanged_event()
        {
            var mainObject = new Mocks.MainObject();
            mainObject.Text = "Test text";
            Form form = new Form();
            TextBox textBox = new TextBox();
            Binding binding = new Binding("Text", mainObject, "Text");
            textBox.DataBindings.Add(binding);
            textBox.Parent = form;
            form.Show();

            // bindings set
            Assert.True(mainObject.IsPropertyChangedAssigned);

            // remove bindings
            textBox.DataBindings.Clear();

            // bindings unset
            Assert.False(mainObject.IsPropertyChangedAssigned);
        }
    }
}
