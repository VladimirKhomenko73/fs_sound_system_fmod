using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoundConstructor
{
   static class SoundConstructorMain
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Window view = new Window();
         Presenter presenter = new Presenter(view);
         Application.Run(view);
      }
   }
}
