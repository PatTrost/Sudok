using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SudokuApp.Shared;
using SudokuApp.Components;

namespace SudokuApp.Pages
{
    partial class Index
    {
        [Parameter]
        public string Givens { get; set; }

        private SudokuBoard sudokuBoard;

        public SudokuBoard SudokuBoard => sudokuBoard;

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