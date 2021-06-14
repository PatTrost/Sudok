using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SudokuApp.Shared;
using SudokuApp.Components;
using MudBlazor;

namespace SudokuApp.Pages
{
    partial class Index
    {
        [Parameter]
        public string Givens { get; set; }

        private SudokuBoard sudokuBoard;

        public SudokuBoard SudokuBoard => sudokuBoard;

        private ElementReference _element;

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

        public void OnClick()
        {
            _element.FocusAsync();
            
        }

        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            SudokuBoard.KeyboardEventHandler(args);
        }

    }

}