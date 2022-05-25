/********************************************************************************************
 *                                                                                          *
 *  File:        Program.cs                                                                 *
 *  Copyright:   (c) 2022, Curpan Robert, Istrate Sebastian, Toma Catalin                   *
 *  E-mail:      robert-gabriel.curpan@student.tuiasi.ro                                    *
 *  Website:     https://github.com/Tudisie/MP3-Player                                      *
 *  Description: Program that starts the whole MP3 Player app (runs and displays the UI)    *     
 *               that the client can interact with.                                         *                                          
 *                                                                                          *
 *******************************************************************************************/


using System;
using System.Windows.Forms;

namespace MP3Player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mp3Form());
        }
    }
}
