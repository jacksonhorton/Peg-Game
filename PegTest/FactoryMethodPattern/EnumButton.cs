/*
 * @file: EnumButton.cs
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: This file contains the EnumButton enum.
 * 
 * This file contains EnumButton which is used to declare the enum values
 * used to determine button functionality.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegTest
{
    public enum EnumButton
    {
        QUIT, //quit button
        RESET, //reset button
        PLAY, //play button
        PAUSE, //pause button
        HELP, //help button
        UNDO, //undo button
        MENU, //menu button
        RESUME, //resume button
        SAVE // save button
    }
}
