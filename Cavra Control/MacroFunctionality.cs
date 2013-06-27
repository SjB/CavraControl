﻿using System;
using System.IO;
using System.Text;
using System.Media;
using System.Collections.Generic;

using Eto.Drawing;
using Eto.Forms;

namespace Cavra_Control
{
    class MacroFunctionality
    {
        //TextBox userinput_txt;
        string macroData;
        ImageMenuItem Macro_btn;
        MenuBar menu;

        public Dialog AskUserForMacroName_Dialog()
        {
            var dialog = new Dialog();
            dialog.ClientSize= new Size(400, 200);
            dialog.WindowState = WindowState.Normal;

            var layout = new DynamicLayout(AskUserForMacroName_Dialog());
            
            var instructions_lbl = new Label();
            
            instructions_lbl.Text = "Enter the Desired Macro Name and Information Below. NOTE: Existing Macros with the Same Name will be Replaced.";
            
            userinput_MacroName_txt = new TextBox();
            userinput_MacroName_txt.PlaceholderText = "Enter Name of Macro.";
            userinput_RightSlider_txt = new TextBox();
            userinput_RightSlider_txt.PlaceholderText = "Enter Right Slider Value.";
            userinput_LeftSlider_txt = new TextBox();
            userinput_LeftSlider_txt.PlaceholderText = "Enter Left Slider Value.";
            
            //Create a string that will contain data representing above values.
            macroData = userinput_MacroName_txt.Text + "___" + userinput_RightSlider_txt.Text + "___" + userinput_LeftSlider_txt.Text; 

            var OK_btn = new Button();
            OK_btn.Text = "OK";
            
            layout.AddCentered(instructions_lbl);
            layout.AddCentered(userinput_MacroName_txt);
            layout.AddRow(userinput_RightSlider_txt, userinput_LeftSlider_txt);
            layout.AddCentered(OK_btn);

            OK_btn.Click += delegate { dialog.DialogResult = DialogResult.Ok; };
            
            return dialog;
        }

        public void CreateNewMacro()
        {
            int numberOfMenuItems = 0; //important later.

            string fileName = userinput_MacroName_txt.Text;
            
            string FULL_fileName = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (Directory.GetCurrentDirectory().Contains(FULL_fileName) == false)
            {
                File.WriteAllText(FULL_fileName, macroData);
            }
            else
            {
                File.WriteAllText(FULL_fileName, macroData);
                //could be useful for later, otherwise if/else statement will be abolished.
            }
            var GeneratedMacroButton = new ImageMenuItem();
            GeneratedMacroButton.Text = fileName;

            numberOfMenuItems++;

            if (numberOfMenuItems >= 7)
            {
                menu.MenuItems.RemoveAt(7);
                numberOfMenuItems--;
            }

            Macro_btn.MenuItems.Add(GeneratedMacroButton);
            
        }

        public TextBox userinput_RightSlider_txt { get; set; }

        public TextBox userinput_LeftSlider_txt { get; set; }
    
        public  TextBox userinput_MacroName_txt { get; set; }
    }
}