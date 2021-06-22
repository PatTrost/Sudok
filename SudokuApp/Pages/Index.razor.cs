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

        bool _drawerOpen = false;

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            SudokuBoard.KeyboardEventHandler(args);
        }

        void CheckSudoku()
        {
            SudokuBoard.CheckValues();
        }

    }

}