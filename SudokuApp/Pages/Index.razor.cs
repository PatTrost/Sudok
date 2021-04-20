using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SudokuApp.Shared;

namespace SudokuApp.Pages
{
    partial class Index
    {
        public string Givens { get; set; }

        private string TempText = "";

        bool _drawerOpen = true;

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        private void MakeSudoku()
        {
            TempText = "Sudoku!";
        }
    }
}