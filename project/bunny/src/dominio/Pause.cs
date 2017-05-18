using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace bunny.src.dominio
{
    class Pause
    {
        private String pathDirectory = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");

        public Pause()
        {
            Globals.label_pause.MouseUp += changeState;
            Globals.label_pause.MouseEnter += mouseEnter;
        }

        private void changeState(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void mouseEnter(object sender, EventArgs e)
        {
            Globals.label_pause.Cursor = Cursors.Hand;
        }
    }
}
