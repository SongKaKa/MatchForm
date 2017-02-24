using System.Windows.Forms;
using MatchForms.Controller;

namespace MatchForms
{
    public partial class MatchForm : Form
    {
        private readonly GameController _gameController;

        public MatchForm()
        {
            InitializeComponent();

            _gameController = new GameController(this);
        }
    }
}